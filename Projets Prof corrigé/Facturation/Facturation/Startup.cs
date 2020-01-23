using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facturation.Models;
using JWT.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Facturation
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
            services.AddControllersWithViews();
            services.AddDbContext<FacturationContext>(options =>
            {
                options.UseLazyLoadingProxies(true);
                options.UseSqlServer(Configuration.GetConnectionString("FacturationDB"));
              
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.Use(async (context, next) =>
            {
                var hasCookie = context.Request.Cookies.Any(c => c.Key == "security_token");

                if (!hasCookie)
                {
                  

                }
                var token = context.Request.Cookies.FirstOrDefault(c => c.Key == "security_token").Value;

                var payload = new JwtBuilder()
                        .WithSecret("123456")
                        .MustVerifySignature()
                         .Decode<IDictionary<string, object>>(token);
                context.User.Claims.Add

            });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Clients}/{action=Index}/{id?}");
            });
        }
    }
}
