using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GleamTech.FileUltimate;

namespace GleamTech.FileUltimateExamples.WebForms.CS.FileManager
{
    public partial class DynamicPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateUserSelector();

            SetDynamicFolderAndPermissions(UserSelector.SelectedValue);
        }

        private void PopulateUserSelector()
        {
            UserSelector.Items.Add(new ListItem("User1 (Full permissions)", "User1"));
            UserSelector.Items.Add(new ListItem("User2 (ReadOnly plus Upload permissions)", "User2"));
        }

        private void SetDynamicFolderAndPermissions(string userName)
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
    }
}