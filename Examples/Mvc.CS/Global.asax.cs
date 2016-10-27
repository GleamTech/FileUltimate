using System.IO;
using System.Web.Mvc;
using System.Web.Routing;
using GleamTech.FileUltimate;

namespace GleamTech.FileUltimateExamples.Mvc.CS
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

            var licenseFile = Server.MapPath("~/App_Data/License.dat");
            if (File.Exists(licenseFile))
                FileUltimateConfiguration.Current.LicenseKey = File.ReadAllText(licenseFile);
        }
    }
}