using System;
using System.IO;
using System.Web;
using GleamTech.AspNet;
using GleamTech.FileUltimate;

namespace GleamTech.FileUltimateExamples.AspNetWebFormsCS
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var gleamTechConfig = Hosting.ResolvePhysicalPath("~/App_Data/GleamTech.config");
            if (File.Exists(gleamTechConfig))
                GleamTechConfiguration.Current.Load(gleamTechConfig);

            var fileUltimateConfig = Hosting.ResolvePhysicalPath("~/App_Data/FileUltimate.config");
            if (File.Exists(fileUltimateConfig))
                FileUltimateConfiguration.Current.Load(fileUltimateConfig);
        }
    }
}