using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SampleApplication.Services;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddMvc(); //without this we will get an error that the reuired services were not found when
            //the mvc is being used
            services.AddScoped<IRestaurantData, InMemoryRestaraunt>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //next here is used to pass the request to the next middleware
            app.Use(next =>
                async (context) =>
                {
                    if (context.Request.Path.StartsWithSegments("/hello"))
                    {
                        await context.Response.WriteAsync("Delegate Middleware hit");
                        logger.LogInformation("Request handled by the delegate");
                    }
                    else
                    {
                        await next(context);
                        logger.LogInformation("Request handled by  the next middleware");
                    }
                }
                    );

            app.UseMvc(ConfigureRoutes);

            app.UseStaticFiles();

            app.UseWelcomePage(new WelcomePageOptions
            {
                Path = "/wp"
            });

            app.Run(async (context) =>
            {
                string greeting = greeter.GetMessage();
                await context.Response.WriteAsync("hello world");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=home}/{action=index}/{id?}");
        }
    }
}
