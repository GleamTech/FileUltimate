using System.Web.Mvc;
using GleamTech.FileUltimate.AspNet.UI;

namespace GleamTech.FileUltimateExamples.AspNetMvcCS.Controllers
{
    public partial class FileManagerController
    {
        public ActionResult ClientEvents()
        {
            var fileManager = new FileManager
            {
                Width = 800,
                Height = 600,
                DisplayLanguage = "en",
                ClientEvents = new FileManagerClientEvents
                {
                    Loading = "fileManagerLoading",
                    Loaded = "fileManagerLoaded",
                    Chosen = "fileManagerChosen",
                    FolderChanged = "fileManagerFolderChanged",
                    SelectionChanged = "fileManagerSelectionChanged",
                    Creating = "fileManagerCreating",
                    Created = "fileManagerCreated",
                    Deleting = "fileManagerDeleting",
                    Deleted = "fileManagerDeleted",
                    Renaming = "fileManagerRenaming",
                    Renamed = "fileManagerRenamed",
                    Copying = "fileManagerCopying",
                    Copied = "fileManagerCopied",
                    Moving = "fileManagerMoving",
                    Moved = "fileManagerMoved",
                    Compressing = "fileManagerCompressing",
                    Compressed = "fileManagerCompressed",
                    Extracting = "fileManagerExtracting",
                    Extracted = "fileManagerExtracted",
                    Uploading = "fileManagerUploading",
                    Uploaded = "fileManagerUploaded",
                    Downloading = "fileManagerDownloading",
                    Previewing = "fileManagerPreviewing"
                }
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
