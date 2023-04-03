﻿using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using GleamTech.AspNet;
using GleamTech.AspNet.Core;
using GleamTech.FileUltimate;

namespace GleamTech.FileUltimateExamples.AspNetCoreOnNetFullCS
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();


            //----------------------
            //Add GleamTech to the ASP.NET Core services container.
            services.AddGleamTech();
            //----------------------
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //----------------------
            //Register GleamTech to the ASP.NET Core HTTP request pipeline.
            app.UseGleamTech(() =>
            {
	            //The below custom config file loading is only for our demo publishing purpose:

	            var gleamTechConfig = Hosting.ResolvePhysicalPath("~/App_Data/GleamTech.config");
	            if (File.Exists(gleamTechConfig))
	                GleamTechConfiguration.Current.Load(gleamTechConfig);

	            var fileUltimateConfig = Hosting.ResolvePhysicalPath("~/App_Data/FileUltimate.config");
	            if (File.Exists(fileUltimateConfig))
	                FileUltimateConfiguration.Current.Load(fileUltimateConfig);
            });
            //----------------------


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
