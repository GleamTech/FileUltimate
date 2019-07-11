Imports GleamTech.FileUltimate.AspNet.UI

Namespace Controllers
    Partial Public Class FileManagerController

        Public Function ClientEvents() As ActionResult
            Dim fileManager = New FileManager() With {
             .Width = 800,
             .Height = 600,
             .DisplayLanguage = "en",
             .ClientEvents = New FileManagerClientEvents() With {
                .Loading = "fileManagerLoading",
                .Loaded = "fileManagerLoaded",
                .Chosen = "fileManagerChosen",
                .FolderChanged = "fileManagerFolderChanged",
                .SelectionChanged = "fileManagerSelectionChanged",
                .Creating = "fileManagerCreating",
                .Created = "fileManagerCreated",
                .Deleting = "fileManagerDeleting",
                .Deleted = "fileManagerDeleted",
                .Renaming = "fileManagerRenaming",
                .Renamed = "fileManagerRenamed",
                .Copying = "fileManagerCopying",
                .Copied = "fileManagerCopied",
                .Moving = "fileManagerMoving",
                .Moved = "fileManagerMoved",
                .Compressing = "fileManagerCompressing",
                .Compressed = "fileManagerCompressed",
                .Extracting = "fileManagerExtracting",
                .Extracted = "fileManagerExtracted",
                .Uploading = "fileManagerUploading",
                .Uploaded = "fileManagerUploaded",
                .Downloading = "fileManagerDownloading",
                .Previewing = "fileManagerPreviewing"
               }
            }
            fileManager.RootFolders.Add(New FileManagerRootFolder() With {
             .Name = "Root Folder 1",
             .Location = "~/App_Data/RootFolder1"
            })
            fileManager.RootFolders(0).AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\",
             .AllowedPermissions = FileManagerPermissions.Full
            })

            Return View(fileManager)
        End Function

    End Class
End Namespace
