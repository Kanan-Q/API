using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using WebApplication1.LanguageExceptions;
using WebApplication1.Services.Abstracts;
using WebApplication1.Services.Implements;

namespace WebApplication1
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IWordService, WordService>();
            return services;
        }
        public static IApplicationBuilder UseAppExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(
                opt =>
                {
                    opt.Run(async context =>
                    {
                        var feature = context.Features.GetRequiredFeature<IExceptionHandlerFeature>();
                        var exception = feature.Error;
                        if (exception is IBaseException Bex)
                        {
                            context.Response.StatusCode = Bex.StatusCode;
                            await context.Response.WriteAsJsonAsync(new
                            {
                                Message = Bex.ErrorMessage
                            });
                        }
                        else
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsJsonAsync(new
                            {
                                Message = "Error qaqa error"
                            });
                        }

                    });
                });
            return app;
        }
    }
}
