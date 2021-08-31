using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BundlerMinifier.TagHelpers;
using Umbrella.DataLayer.Helpers;
using Umbrella.Models.Framework;
using System.Text.Json.Serialization;

namespace Umbrella {
    public class Startup {

        private SecureConfiguration _SecureConfiguration = new SecureConfiguration();



        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddBundles(options =>
            {
                options.AppendVersion = true;
            });
            //services.AddControllers(options =>
            //{
            //    options.RespectBrowserAcceptHeader = true; // false by default
            //});

            //services.AddControllers().AddJsonOptions(options => {
            //    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            //    options.JsonSerializerOptions.PropertyNamingPolicy = null;
            //    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            //});


            //// https://www.meziantou.net/how-to-avoid-storing-secrets-in-the-source-code.htm
            //// https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.1&tabs=windows&WT.mc_id=DT-MVP-5003978
            //// https://stackoverflow.com/questions/47433027/configuration-getsection-in-asp-net-core-2-0-getting-all-settings
            //this._SecureConfiguration = new SecureConfiguration();
            //Configuration.GetSection("SecureConfiguration").Bind(this._SecureConfiguration, c => c.BindNonPublicProperties = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }


    }
}
