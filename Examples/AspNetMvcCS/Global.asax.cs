using System.IO;
using System.Web.Mvc;
using System.Web.Routing;
using GleamTech.AspNet;
using GleamTech.FileUltimate;

namespace GleamTech.FileUltimateExamples.AspNetMvcCS
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            var gleamTechConfig = Hosting.ResolvePhysicalPath("~/App_Data/GleamTech.config");
            if (File.Exists(gleamTechConfig))
                GleamTechConfiguration.Current.Load(gleamTechConfig);

            var fileUltimateConfig = Hosting.ResolvePhysicalPath("~/App_Data/FileUltimate.config");
            if (File.Exists(fileUltimateConfig))
                FileUltimateConfiguration.Current.Load(fileUltimateConfig);
        }
    }
}