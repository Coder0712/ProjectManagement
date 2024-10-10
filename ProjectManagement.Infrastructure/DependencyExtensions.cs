using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Infrastructure.Options;
using ProjectManagement.Domain.Common;

namespace ProjectManagement.Infrastructure
{
    public static class DependencyExtensions
    {
        /// <summary>
        /// Registers all components of the persistence project.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureOptions<DatabaseOptionsSetup>();
            services.AddDbContext<IDbContext, ManagementDbContext>(options =>
                options.UseNpgsql(GetConnectionString(configuration)));

            return services;
        }

        /// <summary>
        ///  Gets the connection string of the database.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        /// <returns>The connection string.</returns>
        public static string GetConnectionString(IConfiguration configuration)
        {
            var option = new DatabaseOptions();

            var optionsSetup = new DatabaseOptionsSetup(configuration);

            optionsSetup.Configure(option);

            return option.ConnectionString;
        }
    }
}
