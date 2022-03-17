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
using Umbrella.Abstracts;
using Umbrella.DataLayer.Helpers;

namespace Umbrella {
    public class Startup {


        public Startup(IConfiguration configuration) {
            Configuration = configuration;
            AppSettings.Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddControllers();

            services.AddControllersWithViews();

            services.AddBundles(options => { options.AppendVersion = true; });

            //services.AddTransient<IDatabaseConnectionRepository>(x => new DatabaseConnectionRepository(Configuration.GetConnectionString("Default")));
            services.AddScoped<DataAccessLayerInterface> (options => new DataAccessLayerService("acorns"));
            //services.AddScoped<DataAccessLayerInterface>(options =>
            //{
            //    var _service = options.GetRequiredService<DataAccessLayerInterface>();
            //    return new DataAccessLayerService("acorns");
            //});
            //services.AddScoped<DataAccessLayerInterface, DataAccessLayerService>("acorns");

            //services.AddScoped<DataAccessLayerInterface>(DAL => {
            //    var _DataAccessLayerImplementation = DAL.GetRequiredService<DataAccessLayerInterface>();
            //    return new DataAccessLayerService("acorns");
            //});


            // work around for issue: Synchronous operations are disallowed. Call ReadAsync or set AllowSynchronousIO to true instead
            //services.Configure<KestrelServerOptions>(options => {
            //    options.AllowSynchronousIO = true;
            //});

            services.Configure<IISServerOptions>(options => {
                options.AllowSynchronousIO = true;
            });
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
