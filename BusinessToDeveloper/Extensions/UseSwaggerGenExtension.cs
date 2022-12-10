using Microsoft.OpenApi.Models;

namespace BusinessToDeveloper.Extensions
{
    public static class SwaggerGenExtensions
    {
        public static void AddSwaggerGenWithJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                // Configure the Swagger UI...

                // Enable JWT authentication in the Swagger UI
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    Description = "Enter 'Bearer' followed by a space and your JWT token in the text input below. Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {   
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
                });
            });
        }
    }
}
    

