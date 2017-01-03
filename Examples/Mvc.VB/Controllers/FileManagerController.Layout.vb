Imports System.Web.UI.WebControls
Imports GleamTech.FileUltimate

Namespace Controllers
    Partial Public Class FileManagerController

        Public Function Layout() As ActionResult
            Dim fileManager = New FileManager() With {
             .Width = Unit.Percentage(100),
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
