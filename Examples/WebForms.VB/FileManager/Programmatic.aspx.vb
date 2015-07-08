Imports GleamTech.FileUltimate

Namespace FileManager

    Public Class ProgrammaticPage
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            fileManager.Width = Unit.Percentage(100) ' or new Unit(100, UnitType.Percentage)
            fileManager.Height = 600 'Default unit is pixels.
            fileManager.DisplayLanguage = "en"

            'Create a root folder and add it to the control
            Dim rootFolder1 = New FileManagerRootFolder()
            rootFolder1.Name = "Root Folder 1"

            'For connecting as a specific user to a protected folder (UNC or local) use this format:

            '  Location = "Path=\\server\share; User Name=USERNAME; Password=PASSWORD"
            '  Please see description of Location property on the right pane for more information.

            'Information on FileManagerRootFolder.Location property as of v4.7:

            '  This property is now of type Location class instead of string. You can still assign
            '  a string to this property as it's automatically casted so this is not a breaking change. The advantage of this special
            '  Location class is that you can now set it directly to an instance of PhysicalLocation or AmazonS3Location (more will
            '  be available in the future) classes. For instance this line:

            '  rootFolder.Location = "Type=AmazonS3; Bucket Name=mybucket";

            '  is same as this line:

            '  rootFolder.Location = new AmazonS3Location { BucketName = "mybucket" };

            '  This means you don't need to bother with formatting location strings correctly (eg. guessing property names)
            '  Except in aspx markup, you will still need to use strings which look like connection strings if you need to set 
            '  advanced properties. Also note that this line:

            '  rootFolder.Location = "c:\some\folder";

            '  is same as this line:

            '  rootFolder.Location = "Type=Physical; Path=c:\some\folder";

            '  and also same as this line:

            '  rootFolder.Location = new PhysicalLocation { Path = "c:\some\folder" };

            '  So as in previous versions, setting location to a path string directly means it's a physical location by default.
            rootFolder1.Location = "~/App_Data/RootFolder1"

            fileManager.RootFolders.Add(rootFolder1)
            Dim accessControl1 = New FileManagerAccessControl()
            accessControl1.Path = "\"
            accessControl1.AllowedPermissions = FileManagerPermissions.Full
            rootFolder1.AccessControls.Add(accessControl1)

            'Create another root folder and add it to the control
            'This time use object initializers
            Dim rootFolder2 = New FileManagerRootFolder() With {
                    .Name = "Root Folder 2",
                    .Location = "~/App_Data/RootFolder2"
                    }
            rootFolder2.AccessControls.Add(New FileManagerAccessControl() With {
                                              .Path = "\",
                                              .AllowedPermissions = FileManagerPermissions.ListSubfolders Or FileManagerPermissions.ListFiles Or FileManagerPermissions.Download Or FileManagerPermissions.Upload,
                                              .AllowedFileTypes = New FileTypeSet(New String() {"*.jpg", "*.gif"}),
                                              .Quota = New ByteSizeValue(2, ByteSizeUnit.MB)
                                              })
            ' or .AllowedFileTypes = FileTypeSet.Parse("*.jpg|*.gif")
            ' or .Quota = ByteSizeValue.Parse("2 MB")
            rootFolder2.AccessControls.Add(New FileManagerAccessControl() With {
                                              .Path = "\Subfolder1",
                                              .AllowedPermissions = FileManagerPermissions.Full,
                                              .DeniedPermissions = FileManagerPermissions.Download,
                                              .DeniedFileTypes = New FileTypeSet(New String() {"*.exe"})
                                              })
            'or .DeniedFileTypes = FileTypeSet.Parse("*.exe")
            fileManager.RootFolders.Add(rootFolder2)
        End Sub
    End Class
End Namespace