using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GleamTech.FileUltimate.AspNet;

namespace GleamTech.FileUltimateExamples.AspNetWebFormsCS.FileUploader
{
    public partial class Overview : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                fileUploader.DisplayLanguage = LanguageSelector.SelectedValue;
            else
                PopulateLanguageSelector();
        }

        private void PopulateLanguageSelector()
        {
            foreach (var culture in FileUltimateWebConfiguration.AvailableDisplayCultures)
            {
                var listItem = new ListItem(culture.NativeName + $" ({culture.Name})", culture.Name);
                if (culture.Name == fileUploader.DisplayLanguage)
                    listItem.Selected = true;
                LanguageSelector.Items.Add(listItem);
            }
        }
    }
}