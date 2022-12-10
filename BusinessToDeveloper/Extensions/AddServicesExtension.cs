using BusinessToDeveloper.Repositories.Repository;
using BusinessToDeveloper.Repositories.UOW;
using BusinessToDeveloper.Services.Projects;

namespace BusinessToDeveloper.Extensions
{
    public static class AddServicesExtension
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProjectService, ProjectService>();
        }
    }
}
