using System.IO;
using GleamTech.AspNet;
using GleamTech.AspNet.Core;
using GleamTech.FileUltimate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GleamTech.FileUltimateExamples.AspNetCore.CS
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
            services.AddMvc();

            services.AddGleamTech();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseGleamTech();

            var gleamTechConfig = Hosting.ResolvePhysicalPath("~/App_Data/GleamTech.config");
            if (File.Exists(gleamTechConfig))
                GleamTechConfiguration.Current.Load(gleamTechConfig);

            var fileUltimateConfig = Hosting.ResolvePhysicalPath("~/App_Data/FileUltimate.config");
            if (File.Exists(fileUltimateConfig))
                FileUltimateConfiguration.Current.Load(fileUltimateConfig);

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
