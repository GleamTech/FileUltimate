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

            HandleLanguage(fileUploader);

            return View(fileUploader);
        }

        private void HandleLanguage(FileUploader fileUploader)
        {
            var selectedLanguage = Request["languageSelector"];

            if (selectedLanguage != null)
                fileUploader.DisplayLanguage = selectedLanguage;
            else
                selectedLanguage = fileUploader.DisplayLanguage;

            PopulateLanguageSelector(selectedLanguage);
        }

        private void PopulateLanguageSelector(string selectedLanguage)
        {
            ViewBag.LanguageList = new SelectList(
                FileUltimateWebConfiguration.AvailableDisplayCultures,
                "Name",
                "NativeName",
                selectedLanguage
            );
        }
    }
}