using System.Web.Mvc;
using GleamTech.FileUltimate;

namespace GleamTech.FileUltimateExamples.Mvc.CS.Controllers
{
    public partial class FileManagerController
    {
        public ActionResult Overview()
        {
            var fileManager = new FileManager
            {
                Width = 800, //Default unit is pixels. Percentage can be specified as Unit.Percentage(100)
                Height = 600,
                Resizable = true
            };

            //Create a root folder via assignment statements and add it to the control.
            var rootFolder = new FileManagerRootFolder();
            rootFolder.Name = "1. Root Folder";

            /*
              For connecting as a specific user to a protected folder (UNC or local) use this format:
             
                Location="Path=\\server\share; User Name=USERNAME; Password=PASSWORD"
                Please see description of Location property on the right pane for more information.

              Information on FileManagerRootFolder.Location property as of v4.7:
         
                This property is now of type Location class instead of string. You can still assign
                a string to this property as it's automatically casted so this is not a breaking change. The advantage of this special
                Location class is that you can now set it directly to an instance of PhysicalLocation or AmazonS3Location (more will
                be available in the future) classes. For instance this line:
                
                rootFolder.Location = "Type=AmazonS3; Bucket Name=mybucket";
             
                is same as this line:
             
                rootFolder.Location = new AmazonS3Location { BucketName = "mybucket" };
             
                This means you don't need to bother with formatting location strings correctly (eg. guessing property names)
                Except in aspx markup, you will still need to use strings which look like connection strings if you need to set 
                advanced properties. Also note that this line:

                rootFolder.Location = "c:\some\folder";
             
                is same as this line:
             
                rootFolder.Location = "Type=Physical; Path=c:\some\folder";
             
                and also same as this line:
             
                rootFolder.Location = new PhysicalLocation { Path = "c:\some\folder" };
              
                So as in previous versions, setting location to a path string directly means it's a physical location by default.
            */
            rootFolder.Location = "~/App_Data/RootFolder1";

            fileManager.RootFolders.Add(rootFolder);
            var accessControl = new FileManagerAccessControl();
            accessControl.Path = @"\";
            accessControl.AllowedPermissions = FileManagerPermissions.Full;
            rootFolder.AccessControls.Add(accessControl);

            //Create another root folder. This time use object initializers (See CreateRootFolder2 method body).
            fileManager.RootFolders.Add(CreateRootFolder2());

            //Create the final root folder and add it to the control
            fileManager.RootFolders.Add(CreateRootFolder3());
            
            if (Request["languageSelector"] != null)
                fileManager.DisplayLanguage = Request["languageSelector"];

            PopulateLanguageSelector();

            return View(fileManager);
        }

        private FileManagerRootFolder CreateRootFolder2()
        {
            //Use object initializers instead of assignment statements for making the code more compact.

            var rootFolder = new FileManagerRootFolder
            {
                Name = "2. Feature Tests",
                Location = "~/App_Data/Feature Tests"
            };

            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\",
                AllowedPermissions = FileManagerPermissions.ReadOnly
            });

            //Access controls for subfolder "6. Permissions" and below
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions",
                AllowedPermissions = FileManagerPermissions.ListFiles
                                     | FileManagerPermissions.ListSubfolders
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions\01. Full",
                AllowedPermissions = FileManagerPermissions.Full
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions\02. Read",
                AllowedPermissions = FileManagerPermissions.ReadOnly
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions\03. List subfolders",
                AllowedPermissions = FileManagerPermissions.ListSubfolders
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions\04. List files",
                AllowedPermissions = FileManagerPermissions.ListFiles
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions\05. Create",
                AllowedPermissions = FileManagerPermissions.Create
                | FileManagerPermissions.ListFiles
                | FileManagerPermissions.ListSubfolders
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions\06. Delete",
                AllowedPermissions = FileManagerPermissions.Delete
                | FileManagerPermissions.ListFiles
                | FileManagerPermissions.ListSubfolders
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions\07. Rename",
                AllowedPermissions = FileManagerPermissions.Rename
                | FileManagerPermissions.ListFiles
                | FileManagerPermissions.ListSubfolders
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions\08. Edit",
                AllowedPermissions = FileManagerPermissions.Edit
                | FileManagerPermissions.ListFiles
                | FileManagerPermissions.ListSubfolders
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions\09. Upload",
                AllowedPermissions = FileManagerPermissions.Upload
                | FileManagerPermissions.ListFiles
                | FileManagerPermissions.ListSubfolders
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions\10. Download",
                AllowedPermissions = FileManagerPermissions.Download
                | FileManagerPermissions.ListFiles
                | FileManagerPermissions.ListSubfolders
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions\11. Compress",
                AllowedPermissions = FileManagerPermissions.Compress
                | FileManagerPermissions.ListFiles
                | FileManagerPermissions.ListSubfolders
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions\12. Extract",
                AllowedPermissions = FileManagerPermissions.Extract
                | FileManagerPermissions.ListFiles
                | FileManagerPermissions.ListSubfolders
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions\13. Cut",
                AllowedPermissions = FileManagerPermissions.Cut
                | FileManagerPermissions.ListFiles
                | FileManagerPermissions.ListSubfolders
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions\14. Copy",
                AllowedPermissions = FileManagerPermissions.Copy
                | FileManagerPermissions.ListFiles
                | FileManagerPermissions.ListSubfolders
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\6. Permissions\15. Paste",
                AllowedPermissions = FileManagerPermissions.Paste
                | FileManagerPermissions.ListFiles
                | FileManagerPermissions.ListSubfolders
            });

            //Access controls for subfolder "7. File Type Restrictions" and below
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\7. File Type Restrictions\1. Only Image files (jpg, png, bmp, gif)",
                AllowedPermissions = FileManagerPermissions.Full,
                AllowedFileTypes = FileTypeSet.Parse("*.jpg|*.png|*.bmp|*.gif")
            });

            //Access controls for subfolder "8. Quota Restrictions" and below
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\8. Quota Restrictions\1. Quota (1 MB)",
                AllowedPermissions = FileManagerPermissions.Full,
                Quota = ByteSizeValue.Parse("1MB")
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\8. Quota Restrictions\2. Quota (15 MB)",
                AllowedPermissions = FileManagerPermissions.Full,
                Quota = ByteSizeValue.Parse("15MB")
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\8. Quota Restrictions\2. Quota (15 MB)\Quota (1 MB)",
                AllowedPermissions = FileManagerPermissions.Full,
                Quota = ByteSizeValue.Parse("1MB")
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\8. Quota Restrictions\2. Quota (15 MB)\Deep\Quota (1 MB)",
                AllowedPermissions = FileManagerPermissions.Full,
                Quota = ByteSizeValue.Parse("1MB")
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\8. Quota Restrictions\3. Quota (Unlimited)",
                AllowedPermissions = FileManagerPermissions.Full
            });
            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\8. Quota Restrictions\3. Quota (Unlimited)\Quota (1 MB)",
                AllowedPermissions = FileManagerPermissions.Full,
                Quota = ByteSizeValue.Parse("1MB")
            });

            return rootFolder;
        }

        private FileManagerRootFolder CreateRootFolder3()
        {
            //Create the final root folder and add it to the control
            var rootFolder = new FileManagerRootFolder
            {
                Name = "3. Another Root Folder",
                Location = "~/App_Data/RootFolder2"
            };

            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\",
                AllowedPermissions = FileManagerPermissions.ListSubfolders
                                     | FileManagerPermissions.ListFiles
                                     | FileManagerPermissions.Download
                                     | FileManagerPermissions.Upload,
                AllowedFileTypes = new FileTypeSet(new[] { "*.jpg", "*.gif" }), //or FileTypeSet.Parse("*.jpg|*.gif")
                Quota = new ByteSizeValue(2, ByteSizeUnit.MB) //or ByteSizeValue.Parse("2 MB")
            });

            rootFolder.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\Subfolder1",
                AllowedPermissions = FileManagerPermissions.Full,
                DeniedPermissions = FileManagerPermissions.Download,
                DeniedFileTypes = new FileTypeSet(new[] { "*.exe" }) //or FileTypeSet.Parse("*.exe")
            });

            return rootFolder;
        }

        private void PopulateLanguageSelector()
        {
            ViewBag.LanguageList = new SelectList(
                FileUltimateConfiguration.AvailableDisplayCultures, 
                "Name", 
                "NativeName",
                Request["languageSelector"] ?? FileUltimateConfiguration.CurrentLanguage.ClosestCulture.Name
            );
        }
    }
}
