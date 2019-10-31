Imports GleamTech.AspNet.UI
Imports GleamTech.FileUltimate.AspNet.UI

Namespace Controllers
    Partial Public Class FileManagerController

        Public Function Display() As ActionResult
            Dim fileManager1 = New FileManager() With {
             .ID = "fileManager1",
             .Width = 800,
             .Height = 600,
             .DisplayLanguage = "en",
             .Hidden = true
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
             .Hidden = true,
             .DisplayMode = DisplayMode.Window,
             .WindowOptions = New WindowOptions() With {
               .Title = "FileManager as a modal dialog of viewport",
               .Modal = true rem FullViewport = true,
              }
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
             .Hidden = true,             
             .WindowOptions = New WindowOptions() With {
               .Title = "FileManager as a modal dialog of parent element",
               .Modal = true
              }
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
