using System.Web.Mvc;
using GleamTech.FileUltimate.AspNet;
using GleamTech.FileUltimate.AspNet.UI;

namespace GleamTech.FileUltimateExamples.AspNetMvcCS.Controllers
{
    public partial class FileUploaderController
    {
        public ActionResult Overview()
        {
            var fileUploader = new FileUploader
            {
                Width = 600, //Default unit is pixels. Percentage can be specified as CssLength.Percentage(100)
                Height = 300,
                Resizable = true,
                UploadLocation = "~/App_Data/Uploads"
            };

            if (Request["languageSelector"] != null)
                fileUploader.DisplayLanguage = Request["languageSelector"];

            PopulateLanguageSelector();

            return View(fileUploader);
        }

        private void PopulateLanguageSelector()
        {
            ViewBag.LanguageList = new SelectList(
                FileUltimateWebConfiguration.AvailableDisplayCultures,
                "Name",
                "NativeName",
                Request["languageSelector"] ?? FileUltimateWebConfiguration.CurrentLanguage.ClosestCulture.Name
            );
        }
    }
}