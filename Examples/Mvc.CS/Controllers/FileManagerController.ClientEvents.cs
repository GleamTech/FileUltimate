using System.Web.Mvc;
using GleamTech.FileUltimate.AspNet.UI;

namespace GleamTech.FileUltimateExamples.Mvc.CS.Controllers
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
                ClientLoading = "fileManagerLoading",
                ClientLoaded = "fileManagerLoaded",
                ClientChosen = "fileManagerChosen",
                ClientFolderChanged = "fileManagerFolderChanged",
                ClientSelectionChanged = "fileManagerSelectionChanged",
                ClientCreating = "fileManagerCreating",
                ClientCreated = "fileManagerCreated",
                ClientDeleting = "fileManagerDeleting",
                ClientDeleted = "fileManagerDeleted",
                ClientRenaming = "fileManagerRenaming",
                ClientRenamed = "fileManagerRenamed",
                ClientCopying = "fileManagerCopying",
                ClientCopied = "fileManagerCopied",
                ClientMoving = "fileManagerMoving",
                ClientMoved = "fileManagerMoved",
                ClientCompressing = "fileManagerCompressing",
                ClientCompressed = "fileManagerCompressed",
                ClientExtracting = "fileManagerExtracting",
                ClientExtracted = "fileManagerExtracted",
                ClientUploading = "fileManagerUploading",
                ClientUploaded = "fileManagerUploaded",
                ClientDownloading = "fileManagerDownloading",
                ClientPreviewing = "fileManagerPreviewing"
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
