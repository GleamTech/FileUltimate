using GleamTech.AspNet.UI;
using GleamTech.FileUltimate.AspNet.UI;
using Microsoft.AspNetCore.Mvc;

namespace GleamTech.FileUltimateExamples.AspNetCoreOnNetFullCS.Controllers
{
    public partial class FileManagerController
    {
        public IActionResult Chooser()
        {
            var fileManager1 = new FileManager
            {
                Id = "fileManager1",
                Width = 800,
                Height = 400,
                Resizable = true,
                DisplayLanguage = "en",
                Hidden = true,
                CollapseRibbon = true,
                DisplayMode = DisplayMode.Window,
                WindowOptions =
                {
                    Title = "Choose a file",
                    Modal = true
                },
                ClientEvents = new FileManagerClientEvents { 
                    Chosen = "fileManagerChosen"
                },
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
                Id = "fileManager2",
                Width = 800,
                Height = 400,
                Resizable = true,
                DisplayLanguage = "en",
                Hidden = true,
                CollapseRibbon = true,
                DisplayMode = DisplayMode.Window,
                WindowOptions =
                {
                    Title = "Choose a folder",
                    Modal = true
                },
                ClientEvents = new FileManagerClientEvents
                {
                    Chosen = "fileManagerChosen"
                },
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
                Id = "fileManager3",
                Width = 800,
                Height = 400,
                Resizable = true,
                DisplayLanguage = "en",
                Hidden = true,
                CollapseRibbon = true,
                DisplayMode = DisplayMode.Window,
                WindowOptions =
                {
                    Title = "Choose a file or a folder",
                    Modal = true
                },
                ClientEvents = new FileManagerClientEvents
                {
                    Chosen = "fileManagerChosen"
                },
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
                Id = "fileManager4",
                Width = 800,
                Height = 400,
                Resizable = true,
                DisplayLanguage = "en",
                Hidden = true,
                CollapseRibbon = true,
                DisplayMode = DisplayMode.Window,
                WindowOptions =
                {
                    Title = "Choose files",
                    Modal = true
                },
                ClientEvents = new FileManagerClientEvents
                {
                    Chosen = "fileManagerChosen"
                },
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
                Id = "fileManager5",
                Width = 800,
                Height = 400,
                Resizable = true,
                DisplayLanguage = "en",
                Hidden = true,
                CollapseRibbon = true,
                DisplayMode = DisplayMode.Window,
                WindowOptions =
                {
                    Title = "Choose folders",
                    Modal = true
                },
                ClientEvents = new FileManagerClientEvents
                {
                    Chosen = "fileManagerChosen"
                },
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
                Id = "fileManager6",
                Width = 800,
                Height = 400,
                Resizable = true,
                DisplayLanguage = "en",
                Hidden = true,
                CollapseRibbon = true,
                DisplayMode = DisplayMode.Window,
                WindowOptions =
                {
                    Title = "Choose files or folders",
                    Modal = true
                },
                ClientEvents = new FileManagerClientEvents
                {
                    Chosen = "fileManagerChosen"
                },
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
                Id = "fileManager7",
                Width = 800,
                Height = 400,
                Resizable = true,
                DisplayLanguage = "en",
                Hidden = true,
                ShowRibbon = false,
                ClientEvents = new FileManagerClientEvents
                {
                    Chosen = "fileManagerChosen"
                },
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
