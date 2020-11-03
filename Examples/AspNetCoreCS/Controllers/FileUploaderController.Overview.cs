using System.Linq;
using GleamTech.AspNet;
using GleamTech.FileUltimate.AspNet;
using GleamTech.FileUltimate.AspNet.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GleamTech.FileUltimateExamples.AspNetCoreCS.Controllers
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

            HandleLanguage(fileUploader);

            return View(fileUploader);
        }

        private void HandleLanguage(FileUploader fileUploader)
        {
            var context = Hosting.GetHttpContext();
            var selectedLanguage = context.Request["languageSelector"];

            if (selectedLanguage != null)
                fileUploader.DisplayLanguage = selectedLanguage;
            else
                selectedLanguage = fileUploader.DisplayLanguage;

            PopulateLanguageSelector(selectedLanguage);
        }

        private void PopulateLanguageSelector(string selectedLanguage)
        {
            ViewBag.LanguageList = new SelectList(
                FileUltimateWebConfiguration.AvailableDisplayCultures.Select(culture => new
                {
                    Value = culture.Name,
                    Text = culture.NativeName + $" ({culture.Name})"
                }),
                "Value",
                "Text",
                selectedLanguage
            );
        }
    }
}
