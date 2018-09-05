Imports GleamTech.FileUltimate.AspNet.UI

Namespace Controllers
    Partial Public Class FileManagerController

        Public Function ClientEvents() As ActionResult
            Dim fileManager = New FileManager() With {
             .Width = 800,
             .Height = 600,
             .DisplayLanguage = "en",
             .ClientLoading = "fileManagerLoading",
             .ClientLoaded = "fileManagerLoaded",
             .ClientChosen = "fileManagerChosen",
             .ClientFolderChanged = "fileManagerFolderChanged",
             .ClientSelectionChanged = "fileManagerSelectionChanged",
             .ClientCreating = "fileManagerCreating",
             .ClientCreated = "fileManagerCreated",
             .ClientDeleting = "fileManagerDeleting",
             .ClientDeleted = "fileManagerDeleted",
             .ClientRenaming = "fileManagerRenaming",
             .ClientRenamed = "fileManagerRenamed",
             .ClientCopying = "fileManagerCopying",
             .ClientCopied = "fileManagerCopied",
             .ClientMoving = "fileManagerMoving",
             .ClientMoved = "fileManagerMoved",
             .ClientCompressing = "fileManagerCompressing",
             .ClientCompressed = "fileManagerCompressed",
             .ClientExtracting = "fileManagerExtracting",
             .ClientExtracted = "fileManagerExtracted",
             .ClientUploading = "fileManagerUploading",
             .ClientUploaded = "fileManagerUploaded",
             .ClientDownloading = "fileManagerDownloading",
             .ClientPreviewing = "fileManagerPreviewing"
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
