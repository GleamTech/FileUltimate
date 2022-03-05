using System.IO;
using System.Web.Mvc;
using System.Web.Routing;
using GleamTech.AspNet;
using GleamTech.FileUltimate;

namespace GleamTech.FileUltimateExamples.AspNetMvcCS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var gleamTechConfig = Hosting.ResolvePhysicalPath("~/App_Data/GleamTech.config");
            if (File.Exists(gleamTechConfig))
                GleamTechConfiguration.Current.Load(gleamTechConfig);
            
            var fileUltimateConfig = Hosting.ResolvePhysicalPath("~/App_Data/FileUltimate.config");
            if (File.Exists(fileUltimateConfig))
                FileUltimateConfiguration.Current.Load(fileUltimateConfig);
        }
    }
}