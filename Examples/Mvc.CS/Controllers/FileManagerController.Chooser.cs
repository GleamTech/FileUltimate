using System.Web.Mvc;
using GleamTech.FileUltimate;

namespace GleamTech.FileUltimateExamples.Mvc.CS.Controllers
{
    public partial class FileManagerController
    {
        public ActionResult Chooser()
        {
            var fileManager1 = new FileManager
            {
                ID = "fileManager1",
                Width = 800,
                Height = 400,
                Resizable = true,
                DisplayLanguage = "en",
                ShowOnLoad = false,
                CollapseRibbon = true,
                ModalDialog = true,
                ModalDialogTitle="Choose a file",
                ClientChosen = "fileManagerChosen",
                Chooser = true
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
                Height = 400,
                Resizable = true,
                DisplayLanguage = "en",
                ShowOnLoad = false,
                CollapseRibbon = true,
                ModalDialog = true,
                ModalDialogTitle = "Choose a folder",
                ClientChosen = "fileManagerChosen",
                Chooser = true,
                ChooserType = FileManagerChooserType.Folder
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
                Height = 400,
                Resizable = true,
                DisplayLanguage = "en",
                ShowOnLoad = false,
                CollapseRibbon = true,
                ModalDialog = true,
                ModalDialogTitle = "Choose a file or a folder",
                ClientChosen = "fileManagerChosen",
                Chooser = true,
                ChooserType = FileManagerChooserType.FileOrFolder
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

            var fileManager4 = new FileManager
            {
                ID = "fileManager4",
                Width = 800,
                Height = 400,
                Resizable = true,
                DisplayLanguage = "en",
                ShowOnLoad = false,
                CollapseRibbon = true,
                ModalDialog = true,
                ModalDialogTitle = "Choose files",
                ClientChosen = "fileManagerChosen",
                Chooser = true,
                ChooserMultipleSelection = true
            };
            fileManager4.RootFolders.Add(new FileManagerRootFolder
            {
                Name = "Root Folder 1",
                Location = "~/App_Data/RootFolder1"
            });
            fileManager4.RootFolders[0].AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\",
                AllowedPermissions = FileManagerPermissions.Full
            });

            var fileManager5 = new FileManager
            {
                ID = "fileManager5",
                Width = 800,
                Height = 400,
                Resizable = true,
                DisplayLanguage = "en",
                ShowOnLoad = false,
                CollapseRibbon = true,
                ModalDialog = true,
                ModalDialogTitle = "Choose folders",
                ClientChosen = "fileManagerChosen",
                Chooser = true,
                ChooserType = FileManagerChooserType.Folder,
                ChooserMultipleSelection = true
            };
            fileManager5.RootFolders.Add(new FileManagerRootFolder
            {
                Name = "Root Folder 1",
                Location = "~/App_Data/RootFolder1"
            });
            fileManager5.RootFolders[0].AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\",
                AllowedPermissions = FileManagerPermissions.Full
            });

            var fileManager6 = new FileManager
            {
                ID = "fileManager6",
                Width = 800,
                Height = 400,
                Resizable = true,
                DisplayLanguage = "en",
                ShowOnLoad = false,
                CollapseRibbon = true,
                ModalDialog = true,
                ModalDialogTitle = "Choose files or folders",
                ClientChosen = "fileManagerChosen",
                Chooser = true,
                ChooserType = FileManagerChooserType.FileOrFolder,
                ChooserMultipleSelection = true
            };
            fileManager6.RootFolders.Add(new FileManagerRootFolder
            {
                Name = "Root Folder 1",
                Location = "~/App_Data/RootFolder1"
            });
            fileManager6.RootFolders[0].AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\",
                AllowedPermissions = FileManagerPermissions.Full
            });

            var fileManager7 = new FileManager
            {
                ID = "fileManager7",
                Width = 800,
                Height = 400,
                Resizable = true,
                DisplayLanguage = "en",
                ShowOnLoad = false,
                ShowRibbon = false,
                ClientChosen = "fileManagerChosen",
                Chooser = true
            };
            fileManager7.RootFolders.Add(new FileManagerRootFolder
            {
                Name = "Root Folder 1",
                Location = "~/App_Data/RootFolder1"
            });
            fileManager7.RootFolders[0].AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\",
                AllowedPermissions = FileManagerPermissions.Full
            });

            return View(new[] { fileManager1, fileManager2, fileManager3, fileManager4, fileManager5, fileManager6, fileManager7 });
        }
    }
}
