Imports GleamTech.FileUltimate

Namespace Controllers
    Partial Public Class FileManagerController
        Public Function Chooser() As ActionResult

            Dim fileManager1 = New FileManager() With {
             .ID = "fileManager1",
             .Width = 800,
             .Height = 400,
             .Resizable = True,
             .DisplayLanguage = "en",
             .ShowOnLoad = False,
             .CollapseRibbon = True,
             .ModalDialog = True,
             .ModalDialogTitle = "Choose a file",
             .ClientChosen = "fileManagerChosen",
             .Chooser = True
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
             .Height = 400,
             .Resizable = True,
             .DisplayLanguage = "en",
             .ShowOnLoad = False,
             .CollapseRibbon = True,
             .ModalDialog = True,
             .ModalDialogTitle = "Choose a folder",
             .ClientChosen = "fileManagerChosen",
             .Chooser = True,
            .ChooserType = FileManagerChooserType.Folder
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
             .Height = 400,
             .Resizable = True,
             .DisplayLanguage = "en",
             .ShowOnLoad = False,
             .CollapseRibbon = True,
             .ModalDialog = True,
             .ModalDialogTitle = "Choose a file or a folder",
             .ClientChosen = "fileManagerChosen",
             .Chooser = True,
            .ChooserType = FileManagerChooserType.FileOrFolder
            }
            fileManager3.RootFolders.Add(New FileManagerRootFolder() With {
             .Name = "Root Folder 1",
             .Location = "~/App_Data/RootFolder1"
            })
            fileManager3.RootFolders(0).AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\",
             .AllowedPermissions = FileManagerPermissions.Full
            })

            Dim fileManager4 = New FileManager() With {
             .ID = "fileManager4",
             .Width = 800,
             .Height = 400,
             .Resizable = True,
             .DisplayLanguage = "en",
             .ShowOnLoad = False,
             .CollapseRibbon = True,
             .ModalDialog = True,
             .ModalDialogTitle = "Choose files",
             .ClientChosen = "fileManagerChosen",
             .Chooser = True,
            .ChooserMultipleSelection = True
            }
            fileManager4.RootFolders.Add(New FileManagerRootFolder() With {
             .Name = "Root Folder 1",
             .Location = "~/App_Data/RootFolder1"
            })
            fileManager4.RootFolders(0).AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\",
             .AllowedPermissions = FileManagerPermissions.Full
            })

            Dim fileManager5 = New FileManager() With {
             .ID = "fileManager5",
             .Width = 800,
             .Height = 400,
             .Resizable = True,
             .DisplayLanguage = "en",
             .ShowOnLoad = False,
             .CollapseRibbon = True,
             .ModalDialog = True,
             .ModalDialogTitle = "Choose folders",
             .ClientChosen = "fileManagerChosen",
             .Chooser = True,
             .ChooserType = FileManagerChooserType.Folder,
            .ChooserMultipleSelection = True
            }
            fileManager5.RootFolders.Add(New FileManagerRootFolder() With {
             .Name = "Root Folder 1",
             .Location = "~/App_Data/RootFolder1"
            })
            fileManager5.RootFolders(0).AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\",
             .AllowedPermissions = FileManagerPermissions.Full
            })

            Dim fileManager6 = New FileManager() With {
             .ID = "fileManager6",
             .Width = 800,
             .Height = 400,
             .Resizable = True,
             .DisplayLanguage = "en",
             .ShowOnLoad = False,
             .CollapseRibbon = True,
             .ModalDialog = True,
             .ModalDialogTitle = "Choose files or folders",
             .ClientChosen = "fileManagerChosen",
             .Chooser = True,
             .ChooserType = FileManagerChooserType.FileOrFolder,
            .ChooserMultipleSelection = True
            }
            fileManager6.RootFolders.Add(New FileManagerRootFolder() With {
             .Name = "Root Folder 1",
             .Location = "~/App_Data/RootFolder1"
            })
            fileManager6.RootFolders(0).AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\",
             .AllowedPermissions = FileManagerPermissions.Full
            })

            Dim fileManager7 = New FileManager() With {
             .ID = "fileManager7",
             .Width = 800,
             .Height = 400,
             .Resizable = True,
             .DisplayLanguage = "en",
             .ShowOnLoad = False,
             .ShowRibbon = False,
             .ClientChosen = "fileManagerChosen",
            .Chooser = True
            }
            fileManager7.RootFolders.Add(New FileManagerRootFolder() With {
             .Name = "Root Folder 1",
             .Location = "~/App_Data/RootFolder1"
            })
            fileManager7.RootFolders(0).AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\",
             .AllowedPermissions = FileManagerPermissions.Full
            })

            Return View(New FileManager() {fileManager1, fileManager2, fileManager3, fileManager4, fileManager5, fileManager6, fileManager7})
        End Function

    End Class
End Namespace
