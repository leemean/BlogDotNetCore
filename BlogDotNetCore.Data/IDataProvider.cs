using System;
using System.Collections.Generic;
using System.Text;
using BlogDotNetCore.Data.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogDotNetCore.Data
{
    public interface IDataProvider
    {
        DataProvider Provider { get; }

        IServiceCollection RegisterDbContext(IServiceCollection services, string connectionString);

        IBaseDB CreateDBContext(string connectionString);
    }
}
