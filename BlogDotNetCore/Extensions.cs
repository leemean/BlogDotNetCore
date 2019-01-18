using AutoMapper;
using BlogDotNetCore.Data.Domain;
using BlogDotNetCore.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDotNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var hostingEnvironment = services.BuildServiceProvider().GetService<IHostingEnvironment>();

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile(new ApiAutoMapperProfile());
                cfg.AddProfile(new DomainAutoMapperProfile());
                //cfg.AddProfile(new ReportingAutoMapperProfile());

                //foreach (var profile in AppLoader.Instance(hostingEnvironment).AppAssemblies.GetImplementationsOf<Profile>())
                //{
                //    cfg.AddProfile(profile);
                //}
            });

            services.AddSingleton(sp => autoMapperConfig.CreateMapper());

            return services;
        }
    }
}
