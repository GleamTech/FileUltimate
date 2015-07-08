using System.Web.Mvc;
using GleamTech.FileUltimate;

namespace GleamTech.FileUltimateExamples.Mvc.CS.Controllers
{
    public partial class FileManagerController
    {
        public ActionResult Display()
        {
            var fileManager1 = new FileManager
            {
                ID = "fileManager1",
                Width = 800,
                Height = 600,
                DisplayLanguage = "en",
                ShowOnLoad = false
            };
            fileManager1.RootFolders.Add(new FileManagerRootFolder
            {
                Name = "Root Folder 1",
                Location = "~/App_Data/RootFolder1"
            });
            fileManager1.RootFolders[0].AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\",
                AllowedPermissions = FileManagerPermissions.Full
            });

            var fileManager2 = new FileManager
            {
                ID = "fileManager2",
                Width = 800,
                Height = 600,
                DisplayLanguage = "en",
                ShowOnLoad = false,
                FullViewport = true,
                ModalDialog = true,
                ModalDialogTitle = "FileManager as a modal dialog of viewport"
            };
            fileManager2.RootFolders.Add(new FileManagerRootFolder
            {
                Name = "Root Folder 1",
                Location = "~/App_Data/RootFolder1"
            });
            fileManager2.RootFolders[0].AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\",
                AllowedPermissions = FileManagerPermissions.Full
            });

            var fileManager3 = new FileManager
            {
                ID = "fileManager3",
                Width = 800,
                Height = 600,
                DisplayLanguage = "en",
                ShowOnLoad = false,
                ModalDialog = true,
                ModalDialogTitle = "FileManager as a modal dialog of parent element"
            };
            fileManager3.RootFolders.Add(new FileManagerRootFolder
            {
                Name = "Root Folder 1",
                Location = "~/App_Data/RootFolder1"
            });
            fileManager3.RootFolders[0].AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\",
                AllowedPermissions = FileManagerPermissions.Full
            });

            return View(new[] {fileManager1, fileManager2, fileManager3});
        }
    }
}
