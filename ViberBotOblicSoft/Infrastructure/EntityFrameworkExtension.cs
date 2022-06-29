using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ViberBotOblicSoft.Data;

namespace ViberBotOblicSoft.Infrastructure
{
    public static class EntityFrameworkExtension
    {
        public static void AddEFSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            string ConnectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ViberBotDbContext>(
                options => options.UseSqlServer(
                    ConnectionString, 
                    builder => builder.MigrationsAssembly(typeof(ViberBotDbContext).Assembly.GetName().Name)));
        }
    }
}
