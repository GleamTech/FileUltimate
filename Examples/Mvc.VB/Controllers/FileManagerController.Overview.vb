Imports GleamTech.FileUltimate

Namespace Controllers
    Partial Public Class FileManagerController

        Public Function Overview() As ActionResult
            'Default unit is pixels. Percentage can be specified as Unit.Percentage(100)
            Dim fileManager = New FileManager() With {
             .Width = 800,
             .Height = 600,
             .Resizable = True
            }

            'Create a root folder via assignment statements and add it to the control.
            Dim rootFolder = New FileManagerRootFolder()
            rootFolder.Name = "1. Root Folder"

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
            rootFolder.Location = "~/App_Data/RootFolder1"

            fileManager.RootFolders.Add(rootFolder)
            Dim accessControl = New FileManagerAccessControl()
            accessControl.Path = "\"
            accessControl.AllowedPermissions = FileManagerPermissions.Full
            rootFolder.AccessControls.Add(accessControl)

            'Create another root folder. This time use object initializers (See CreateRootFolder2 method body).
            fileManager.RootFolders.Add(CreateRootFolder2())

            'Create the final root folder and add it to the control
            fileManager.RootFolders.Add(CreateRootFolder3())

            If Request("languageSelector") IsNot Nothing Then
                fileManager.DisplayLanguage = Request("languageSelector")
            End If

            PopulateLanguageSelector()

            Return View(fileManager)
        End Function

        Private Function CreateRootFolder2() As FileManagerRootFolder
            'Use object initializers instead of assignment statements for making the code more compact.

            Dim rootFolder = New FileManagerRootFolder() With {
             .Name = "2. Feature Tests",
             .Location = "~/App_Data/Feature Tests"
            }

            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\",
             .AllowedPermissions = FileManagerPermissions.[ReadOnly]
            })

            'Access controls for subfolder "6. Permissions" and below
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions",
             .AllowedPermissions = FileManagerPermissions.ListFiles Or FileManagerPermissions.ListSubfolders
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions\01. Full",
             .AllowedPermissions = FileManagerPermissions.Full
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions\02. Read",
             .AllowedPermissions = FileManagerPermissions.[ReadOnly]
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions\03. List subfolders",
             .AllowedPermissions = FileManagerPermissions.ListSubfolders
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions\04. List files",
             .AllowedPermissions = FileManagerPermissions.ListFiles
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions\05. Create",
             .AllowedPermissions = FileManagerPermissions.Create Or FileManagerPermissions.ListFiles Or FileManagerPermissions.ListSubfolders
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions\06. Delete",
             .AllowedPermissions = FileManagerPermissions.Delete Or FileManagerPermissions.ListFiles Or FileManagerPermissions.ListSubfolders
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions\07. Rename",
             .AllowedPermissions = FileManagerPermissions.Rename Or FileManagerPermissions.ListFiles Or FileManagerPermissions.ListSubfolders
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions\08. Edit",
             .AllowedPermissions = FileManagerPermissions.Edit Or FileManagerPermissions.ListFiles Or FileManagerPermissions.ListSubfolders
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions\09. Upload",
             .AllowedPermissions = FileManagerPermissions.Upload Or FileManagerPermissions.ListFiles Or FileManagerPermissions.ListSubfolders
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions\10. Download",
             .AllowedPermissions = FileManagerPermissions.Download Or FileManagerPermissions.ListFiles Or FileManagerPermissions.ListSubfolders
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions\11. Compress",
             .AllowedPermissions = FileManagerPermissions.Compress Or FileManagerPermissions.ListFiles Or FileManagerPermissions.ListSubfolders
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions\12. Extract",
             .AllowedPermissions = FileManagerPermissions.Extract Or FileManagerPermissions.ListFiles Or FileManagerPermissions.ListSubfolders
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions\13. Cut",
             .AllowedPermissions = FileManagerPermissions.Cut Or FileManagerPermissions.ListFiles Or FileManagerPermissions.ListSubfolders
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions\14. Copy",
             .AllowedPermissions = FileManagerPermissions.Copy Or FileManagerPermissions.ListFiles Or FileManagerPermissions.ListSubfolders
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\6. Permissions\15. Paste",
             .AllowedPermissions = FileManagerPermissions.Paste Or FileManagerPermissions.ListFiles Or FileManagerPermissions.ListSubfolders
            })

            'Access controls for subfolder "7. File Type Restrictions" and below
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\7. File Type Restrictions\1. Only Image files (jpg, png, bmp, gif)",
             .AllowedPermissions = FileManagerPermissions.Full,
             .AllowedFileTypes = FileTypeSet.Parse("*.jpg|*.png|*.bmp|*.gif")
            })

            'Access controls for subfolder "8. Quota Restrictions" and below
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\8. Quota Restrictions\1. Quota (1 MB)",
             .AllowedPermissions = FileManagerPermissions.Full,
             .Quota = ByteSizeValue.Parse("1MB")
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\8. Quota Restrictions\2. Quota (15 MB)",
             .AllowedPermissions = FileManagerPermissions.Full,
             .Quota = ByteSizeValue.Parse("15MB")
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\8. Quota Restrictions\2. Quota (15 MB)\Quota (1 MB)",
             .AllowedPermissions = FileManagerPermissions.Full,
             .Quota = ByteSizeValue.Parse("1MB")
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\8. Quota Restrictions\2. Quota (15 MB)\Deep\Quota (1 MB)",
             .AllowedPermissions = FileManagerPermissions.Full,
             .Quota = ByteSizeValue.Parse("1MB")
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\8. Quota Restrictions\3. Quota (Unlimited)",
             .AllowedPermissions = FileManagerPermissions.Full
            })
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\8. Quota Restrictions\3. Quota (Unlimited)\Quota (1 MB)",
             .AllowedPermissions = FileManagerPermissions.Full,
             .Quota = ByteSizeValue.Parse("1MB")
            })

            Return rootFolder
        End Function

        Private Function CreateRootFolder3() As FileManagerRootFolder
            'Create the final root folder and add it to the control
            Dim rootFolder = New FileManagerRootFolder() With {
             .Name = "3. Another Root Folder",
             .Location = "~/App_Data/RootFolder2"
            }

            'or FileTypeSet.Parse("*.jpg|*.gif")
            'or ByteSizeValue.Parse("2 MB")
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\",
             .AllowedPermissions = FileManagerPermissions.ListSubfolders Or FileManagerPermissions.ListFiles Or FileManagerPermissions.Download Or FileManagerPermissions.Upload,
             .AllowedFileTypes = New FileTypeSet(New String() {"*.jpg", "*.gif"}),
             .Quota = New ByteSizeValue(2, ByteSizeUnit.MB)
            })

            'or FileTypeSet.Parse("*.exe")
            rootFolder.AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\Subfolder1",
             .AllowedPermissions = FileManagerPermissions.Full,
             .DeniedPermissions = FileManagerPermissions.Download,
             .DeniedFileTypes = New FileTypeSet(New String() {"*.exe"})
            })

            Return rootFolder
        End Function

        Private Sub PopulateLanguageSelector()
            ViewBag.LanguageList = New SelectList(FileUltimateConfiguration.AvailableDisplayCultures, "Name", "NativeName", If(Request("languageSelector"), FileUltimateConfiguration.CurrentLanguage.ClosestCulture.Name))
        End Sub
    End Class
End Namespace
