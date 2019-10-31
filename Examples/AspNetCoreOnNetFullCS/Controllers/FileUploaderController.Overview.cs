using GleamTech.AspNet;
using GleamTech.FileUltimate.AspNet;
using GleamTech.FileUltimate.AspNet.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GleamTech.FileUltimateExamples.AspNetCoreOnNetFullCS.Controllers
{
    public partial class FileUploaderController
    {
        public IActionResult Overview()
        {
            var fileUploader = new FileUploader
            {
                Width = 600, //Default unit is pixels. Percentage can be specified as CssLength.Percentage(100)
                Height = 300,
                Resizable = true,
                UploadLocation = "~/App_Data/Uploads"
            };

            var context = Hosting.GetHttpContext();
            var selectedLanguage = context.Request["languageSelector"];

            if (selectedLanguage != null)
                fileUploader.DisplayLanguage = selectedLanguage;

            PopulateLanguageSelector(selectedLanguage);

            return View(fileUploader);
        }

        private void PopulateLanguageSelector(string selectedLanguage)
        {
            ViewBag.LanguageList = new SelectList(
                FileUltimateWebConfiguration.AvailableDisplayCultures,
                "Name",
                "NativeName",
                selectedLanguage ?? FileUltimateWebConfiguration.CurrentLanguage.ClosestCulture.Name
            );
        }
    }
}
