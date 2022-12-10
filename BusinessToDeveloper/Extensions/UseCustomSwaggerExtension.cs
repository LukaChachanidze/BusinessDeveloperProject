using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace BusinessToDeveloper.Extensions
{
    public static class UseCustomSwaggerExtension
    {
        public static IApplicationBuilder UseCustomSwaggerUI(this IApplicationBuilder app, IConfiguration config)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.OAuthClientId("myClientId");
                c.OAuthClientSecret("myClientSecret");
                c.OAuthRealm("myRealm");
                c.OAuthAppName("My API");

                var oauthConfig = new OAuthConfigObject
                {
                    ClientId = "myClientId",
                    ClientSecret = "myClientSecret",
                    Realm = "myRealm",
                    AppName = "My API"
                };
                c.OAuthConfigObject = oauthConfig;

                // Initialize the AdditionalQueryStringParams property
                c.OAuthConfigObject.AdditionalQueryStringParams = new Dictionary<string, string>();

                // Add additional query string parameters
                c.OAuthConfigObject.AdditionalQueryStringParams.Add("additional_parameter_1", "value1");
                c.OAuthConfigObject.AdditionalQueryStringParams.Add("additional_parameter_2", "value2");
            });

            return app;
        }
    }
}
