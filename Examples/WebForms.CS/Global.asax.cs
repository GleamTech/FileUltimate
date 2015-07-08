using System;
using System.Web;
using GleamTech.FileUltimateExamples.Common;

namespace GleamTech.FileUltimateExamples.WebForms.CS
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ExamplesExplorerContext.Start();
        }
    }
}