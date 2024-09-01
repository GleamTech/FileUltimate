using GleamTech.AspNet.UI;
using GleamTech.FileUltimate.AspNet.UI;
using Microsoft.AspNetCore.Mvc;

namespace GleamTech.FileUltimateExamples.AspNetCoreOnNetFullCS.Controllers
{
    public partial class FileManagerController
    {
        public IActionResult Display()
        {
            var fileManager1 = new FileManager
            {
                Id = "fileManager1",
                Width = 800,
                Height = 600,
                DisplayLanguage = "en",
                Hidden = true,
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
                Id = "fileManager2",
                Width = 800,
                Height = 600,
                DisplayLanguage = "en",
                Hidden = true,
                DisplayMode = DisplayMode.Window,
                WindowOptions =
                {
                    Title = "FileManager as a modal dialog",
                    Modal = true,
                    Maximizable = true,
                    Minimizable = true
                }
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
                Id = "fileManager3",
                Width = 800,
                Height = 600,
                DisplayLanguage = "en",
                Hidden = true,
                DisplayMode = DisplayMode.Panel,
                PanelOptions =
                {
                    Title = "FileManager as a panel",
                    Collapsible = true
                }
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

            return View(new[] { fileManager1, fileManager2, fileManager3 });
        }
    }
}
