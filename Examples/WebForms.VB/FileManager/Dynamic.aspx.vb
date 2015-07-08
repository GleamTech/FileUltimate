Imports GleamTech.FileUltimate

Namespace FileManager

    Public Class DynamicPage
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not IsPostBack Then
                PopulateUserSelector()
            End If

            SetDynamicFolderAndPermissions(UserSelector.SelectedValue)
        End Sub

        Private Sub PopulateUserSelector()
            UserSelector.Items.Add(New ListItem("User1 (Full permissions)", "User1"))
            UserSelector.Items.Add(New ListItem("User2 (ReadOnly plus Upload permissions)", "User2"))
        End Sub

        Private Sub SetDynamicFolderAndPermissions(userName As String)
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
                    accessControl.AllowedPermissions = FileManagerPermissions.ReadOnly Or FileManagerPermissions.Upload
                    Exit Select
            End Select

            rootFolder.AccessControls.Add(accessControl)
            fileManager.RootFolders.Add(rootFolder)
        End Sub

    End Class
End Namespace