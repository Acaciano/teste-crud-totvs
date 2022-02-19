using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Cbyk.ATS.API.Extension
{
    public static class SwaggerExtension
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "API",
                        Version = "v1",
                        Description = "Cbyk.ATS - API REST criada com o ASP.NET Core 3.1."
                    });
            });
        }
    }
}
