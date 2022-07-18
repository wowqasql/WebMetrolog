using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMetrolog.Entity;

namespace WebMetrolog
{
    public class Startup
    {
        public IConfiguration Configuration { get; } 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
          

  

    public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddControllersWithViews();

        }
        


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Reports/Error");
          
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(  
                    name: "default",
                    pattern: "{controller=Reports}/{action=Cal}/{id?}");
            });
        }
    }
}
