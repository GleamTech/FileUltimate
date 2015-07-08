using System.Web.Mvc;
using GleamTech.FileUltimate;

namespace GleamTech.FileUltimateExamples.Mvc.CS.Controllers
{
    public partial class FileManagerController
    {
        public ActionResult Dynamic()
        {
            var fileManager = new FileManager
            {
                Width = 800,
                Height = 600,
                Resizable = true
            };
            
            SetDynamicFolderAndPermissions(fileManager, Request["userSelector"] ?? "User1");

            PopulateUserSelector();

            return View(fileManager);
        }

        private void SetDynamicFolderAndPermissions(FileManager fileManager, string userName)
        {

            var rootFolder = new FileManagerRootFolder
            {
                Name = string.Format("Folder of {0}", userName),
                Location = string.Format("~/App_Data/RootFolder3/{0}", userName)
            };

            var accessControl = new FileManagerAccessControl { Path = @"\" };

            switch (userName)
            {
                case "User1":
                    accessControl.AllowedPermissions = FileManagerPermissions.Full;
                    break;
                case "User2":
                    accessControl.AllowedPermissions = FileManagerPermissions.ReadOnly | FileManagerPermissions.Upload;
                    break;
            }

            rootFolder.AccessControls.Add(accessControl);
            fileManager.RootFolders.Add(rootFolder);
        }

        private void PopulateUserSelector()
        {
            ViewBag.UserList = new SelectList(
                new[]
                {
                    new SelectListItem {Text = "User1 (Full permissions)", Value = "User1"},
                    new SelectListItem {Text = "User2 (ReadOnly plus Upload permissions)", Value = "User2"}
                },
                "Value", 
                "Text",
                Request["userSelector"] ?? "User1"
            );
        }
    }
}
