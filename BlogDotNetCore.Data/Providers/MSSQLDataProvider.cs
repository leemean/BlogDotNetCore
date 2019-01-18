using System;
using System.Collections.Generic;
using System.Text;
using BlogDotNetCore.Data.Configuration;
using BlogDotNetCore.Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BlogDotNetCore.Data.Providers
{
    public class MSSQLDataProvider : IDataProvider
    {
        public DataProvider Provider => DataProvider.MSSQL;

        public IBaseDB CreateDBContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFCoreDB>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EFCoreDB(optionsBuilder.Options);
        }

        public IServiceCollection RegisterDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IBaseDB,EFCoreDB>(options => options.UseSqlServer(connectionString));
            services.AddSingleton<IEFCoreUnitOfWork, EFCoreUnitOfWork>();
            return services;
        }
    }
}
