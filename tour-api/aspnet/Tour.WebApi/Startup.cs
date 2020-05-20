using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Tour.DataContext;
using Tour.Domains.interfaces;
using Tour.Domains.Models;

namespace Tour.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<HeroDatabaseSetting>(Configuration.GetSection(nameof(HeroDatabaseSetting)));

            services.AddSingleton<IHeroDatabaseSetting>(sp =>
                    sp.GetRequiredService<IOptions<HeroDatabaseSetting>>().Value);

             services.AddSingleton<HeroRepository>();

            services.AddControllers();
            
            // Register the Swagger services
            services.AddSwaggerDocument();

            services.AddCors(o =>
            {
                o.AddPolicy("AllowAnyOrigin", options => options.AllowAnyOrigin());

            });
    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors(options => options.AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Use(async (context, next) =>
            {
              // Add Header
              context.Response.Headers["Access-Control-Allow-Origin"] = "*";

             // Call next middleware
             await next.Invoke();
            });

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
