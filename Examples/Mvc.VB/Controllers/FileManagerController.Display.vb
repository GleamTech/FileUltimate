Imports GleamTech.FileUltimate

Namespace Controllers
    Partial Public Class FileManagerController

        Public Function Display() As ActionResult
            Dim fileManager1 = New FileManager() With {
             .ID = "fileManager1",
             .Width = 800,
             .Height = 600,
             .DisplayLanguage = "en",
             .ShowOnLoad = False
            }
            fileManager1.RootFolders.Add(New FileManagerRootFolder() With {
             .Name = "Root Folder 1",
             .Location = "~/App_Data/RootFolder1"
            })
            fileManager1.RootFolders(0).AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\",
             .AllowedPermissions = FileManagerPermissions.Full
            })

            Dim fileManager2 = New FileManager() With {
             .ID = "fileManager2",
             .Width = 800,
             .Height = 600,
             .DisplayLanguage = "en",
             .ShowOnLoad = False,
             .FullViewport = True,
             .ModalDialog = True,
             .ModalDialogTitle = "FileManager as a modal dialog of viewport"
            }
            fileManager2.RootFolders.Add(New FileManagerRootFolder() With {
             .Name = "Root Folder 1",
             .Location = "~/App_Data/RootFolder1"
            })
            fileManager2.RootFolders(0).AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\",
             .AllowedPermissions = FileManagerPermissions.Full
            })

            Dim fileManager3 = New FileManager() With {
             .ID = "fileManager3",
             .Width = 800,
             .Height = 600,
             .DisplayLanguage = "en",
             .ShowOnLoad = False,
             .ModalDialog = True,
             .ModalDialogTitle = "FileManager as a modal dialog of parent element"
            }
            fileManager3.RootFolders.Add(New FileManagerRootFolder() With {
             .Name = "Root Folder 1",
             .Location = "~/App_Data/RootFolder1"
            })
            fileManager3.RootFolders(0).AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\",
             .AllowedPermissions = FileManagerPermissions.Full
            })

            Return View(New FileManager() {fileManager1, fileManager2, fileManager3})
        End Function
    End Class
End Namespace
