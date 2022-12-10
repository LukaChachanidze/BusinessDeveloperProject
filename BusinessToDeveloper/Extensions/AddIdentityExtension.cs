using BusinessToDeveloper.Core.Entities;
using BusinessToDeveloper.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusinessToDeveloper.Extensions
{
    public static class AddIdentityExtension
    {
        public static void AddAppIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BusinessToDeveloperDbContext>()
                .AddDefaultTokenProviders();

            // Other identity configurations...
        }
    }
}
