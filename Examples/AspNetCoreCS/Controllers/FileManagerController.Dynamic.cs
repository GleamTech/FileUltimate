using GleamTech.AspNet;
using GleamTech.FileUltimate.AspNet.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GleamTech.FileUltimateExamples.AspNetCoreCS.Controllers
{
    public partial class FileManagerController
    {
        public IActionResult Dynamic()
        {
            var fileManager = new FileManager
            {
                Width = 800,
                Height = 600,
                Resizable = true
            };

            var context = Hosting.GetHttpContext();
            var selectedUser = context.Request["userSelector"] ?? "User1";

            SetDynamicFolderAndPermissions(fileManager, selectedUser);

            PopulateUserSelector(selectedUser);

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

        private void PopulateUserSelector(string selectedUser)
        {
            ViewBag.UserList = new SelectList(
                new[]
                {
                    new SelectListItem {Text = "User1 (Full permissions)", Value = "User1"},
                    new SelectListItem {Text = "User2 (ReadOnly plus Upload permissions)", Value = "User2"}
                },
                "Value", 
                "Text",
                selectedUser
            );
        }
    }
}
