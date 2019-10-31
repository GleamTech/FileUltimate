using System.Web.Mvc;
using GleamTech.AspNet.UI;
using GleamTech.FileUltimate.AspNet.UI;

namespace GleamTech.FileUltimateExamples.AspNetMvcCS.Controllers
{
    public partial class FileManagerController
    {
        public ActionResult UsingLayout()
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

            return View(fileManager);
        }
    }
}
