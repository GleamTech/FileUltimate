using System.Web.Mvc;
using System.Web.UI.WebControls;
using GleamTech.FileUltimate;

namespace GleamTech.FileUltimateExamples.Mvc.CS.Controllers
{
    public partial class FileManagerController
    {
        public ActionResult Layout()
        {
            var fileManager = new FileManager
            {
                Width = Unit.Percentage(100), 
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
