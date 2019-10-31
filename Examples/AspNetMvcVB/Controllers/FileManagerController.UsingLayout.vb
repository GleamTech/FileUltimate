Imports GleamTech.AspNet.UI
Imports GleamTech.FileUltimate.AspNet.UI

Namespace Controllers
    Partial Public Class FileManagerController

        Public Function UsingLayout() As ActionResult
            Dim fileManager = New FileManager() With {
             .Width = CssLength.Percentage(100),
             .DisplayLanguage = "en"
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
