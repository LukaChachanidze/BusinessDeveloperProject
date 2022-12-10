using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BusinessToDeveloper.Extensions
{
    public static class JwtAuthenticationExtension
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure JWT authentication
            var jwtSection = configuration.GetSection("Jwt");
            var jwtOptions = new JwtBearerOptions();

            // Create a signing key using the Key value from the Jwt configuration section
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Key"]));

            // Set the TokenValidationParameters to specify how the JWT should be validated
            jwtOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = jwtSection["Audience"],
                ValidateIssuer = true,
                ValidIssuer = jwtSection["Issuer"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateLifetime = true
            };

            // Set the Events property and register event handlers
            jwtOptions.Events = new JwtBearerEvents
            {
                OnTokenValidated = context =>
                {
                    try
                    {
                        Console.WriteLine("JWT validated: {0}", context.SecurityToken);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception while validating JWT: {0}", ex.Message);
                    }

                    return Task.CompletedTask;
                },

                OnAuthenticationFailed = context =>
                {
                    try
                    {
                        Console.WriteLine("JWT authentication failed: {0}", context.Exception.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception while handling JWT authentication failure: {0}", ex.Message);
                    }

                    return Task.CompletedTask;
                }
            };

            // Pass the jwtOptions object to the AddJwtBearer method using a delegate
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = jwtOptions.TokenValidationParameters;
                    options.Events = jwtOptions.Events;
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireRole("Admin");
                });

                options.AddPolicy("Manager", policy =>
                {
                    policy.RequireRole("Manager");
                });
            });
        }
    }
}

