using GleamTech.AspNet.UI;
using GleamTech.FileUltimate.AspNet.UI;
using Microsoft.AspNetCore.Mvc;

namespace GleamTech.FileUltimateExamples.AspNetCoreOnNetFullCS.Controllers
{
    public partial class FileManagerController
    {
        public IActionResult UsingPartial()
        {
            var fileManager = GetFileManagerModel();

            return View(fileManager);
        }

        public IActionResult FileManagerPartialView()
        {
            var fileManager = GetFileManagerModel();

            return PartialView(fileManager);
        }

        private FileManager GetFileManagerModel()
        {
            var fileManager = new FileManager
            {
                Width = CssLength.Percentage(100),
                DisplayLanguage = "en"
            };
            fileManager.RootFolders.Add(new FileManagerRootFolder
            {
                Name = "Root Folder 1",
                Location = "~/App_Data/RootFolder1"
            });
            fileManager.RootFolders[0].AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\",
                AllowedPermissions = FileManagerPermissions.Full
            });

            return fileManager;
        }
    }
}
