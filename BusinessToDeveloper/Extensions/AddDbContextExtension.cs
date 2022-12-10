using BusinessToDeveloper.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BusinessToDeveloper.Extensions
{
    public static class AddDbContextExtension
    {
        public static void AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BusinessToDeveloperDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("BusinessToDeveloperConnection")));
        }
    }
}
