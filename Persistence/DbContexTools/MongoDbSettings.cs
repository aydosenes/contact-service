using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DbContexTools
{
    public static class MongoDbSettings
    {
        public static IServiceCollection AddMongoDbSettings(this IServiceCollection services,
        IConfiguration configuration)
        {
            return services.Configure<DbSetting>(options =>
            {
                options.ConnectionString = configuration
                    .GetSection("DbSettings")["ConnectionString"];
                options.DatabaseName = configuration
                    .GetSection("DbSettings")["DatabaseName"];
            });
        }
    }
}
