using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogDotNetCore.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

using BlogDotNetCore.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Autofac;
using System.Reflection;
using Autofac.Extras.DynamicProxy;
using Autofac.Extensions.DependencyInjection;

namespace BlogDotNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            //var sqlConnection = Configuration.GetConnectionString("SqlServerConnection");
            //services.AddDbContext<EFCoreDB>(option => option.UseSqlServer(sqlConnection));

            services.Configure<BlogDotNetCore.Data.Configuration.Data>(x =>
            {
                x.Provider = (Data.Configuration.DataProvider)Enum.Parse(
                    typeof(Data.Configuration.DataProvider),
                    Configuration.GetSection("Data")["Provider"]);
            });

            services.Configure<BlogDotNetCore.Data.Configuration.ConnectionStrings>(
                    Configuration.GetSection("ConnectionStrrings")
                );

            services.AddEntityFrameworkCore(Configuration);


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region Swagger

            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info{
                    Version = "v0.1.0",
                    Title = "BlogDotNetCore API",
                    Description = "接口文档",
                    TermsOfService = "None",
                    Contact = new Contact{
                        Name = "liming",
                        Email = "leemeany@qq.com",
                        Url = ""
                    }
                });
                
                //  Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "BlogDotNetCore.xml");
                x.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改
            });

            #endregion

            services.AddAutoMapper();

            var builder = new ContainerBuilder();

            //service
            var servicesfile = Path.Combine(basePath, "BlogDotNetCore.Services.dll");
            var serviceassemblies = Assembly.LoadFile(servicesfile);
            builder.RegisterAssemblyTypes(serviceassemblies)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors();

            //repository
            var repositoryfile = Path.Combine(basePath, "BlogDotNetCore.Repository.dll");
            var repositoryasemblies = Assembly.LoadFile(repositoryfile);
            builder.RegisterAssemblyTypes(repositoryasemblies).AsImplementedInterfaces();

            builder.Populate(services);

            var ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                #region Swagger

                app.UseSwagger();
                app.UseSwaggerUI(x => {
                    x.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                    //x.RoutePrefix = "";//路径配置，设置为空，表示直接访问该文件，
                                       //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，
                                       //这个时候去launchSettings.json中把"launchUrl": "swagger/index.html"去掉， 然后直接访问localhost:8001/index.html即可
                });


                #endregion
            }
            else
            {
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
