Imports GleamTech.FileUltimate

Namespace Controllers
    Partial Public Class FileManagerController

        Public Function Dynamic() As ActionResult
            Dim fileManager = New FileManager() With {
             .Width = 800,
             .Height = 600,
             .Resizable = True
            }

            SetDynamicFolderAndPermissions(fileManager, If(Request("userSelector"), "User1"))

            PopulateUserSelector()

            Return View(fileManager)
        End Function

        Private Sub SetDynamicFolderAndPermissions(fileManager As FileManager, userName As String)

            Dim rootFolder = New FileManagerRootFolder() With {
             .Name = String.Format("Folder of {0}", userName),
             .Location = String.Format("~/App_Data/RootFolder3/{0}", userName)
            }

            Dim accessControl = New FileManagerAccessControl() With {
             .Path = "\"
            }

            Select Case userName
                Case "User1"
                    accessControl.AllowedPermissions = FileManagerPermissions.Full
                    Exit Select
                Case "User2"
                    accessControl.AllowedPermissions = FileManagerPermissions.[ReadOnly] Or FileManagerPermissions.Upload
                    Exit Select
            End Select

            rootFolder.AccessControls.Add(accessControl)
            fileManager.RootFolders.Add(rootFolder)
        End Sub

        Private Sub PopulateUserSelector()
            ViewBag.UserList = New SelectList(
                New SelectListItem() {
                    New SelectListItem() With {.Text = "User1 (Full permissions)", .Value = "User1"},
                    New SelectListItem() With {.Text = "User2 (ReadOnly plus Upload permissions)", .Value = "User2"}
                },
                "Value",
                "Text",
                If(Request("userSelector"), "User1")
            )
        End Sub
    End Class
End Namespace
