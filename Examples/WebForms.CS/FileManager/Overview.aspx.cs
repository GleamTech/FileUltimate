using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GleamTech.FileUltimate;

namespace GleamTech.FileUltimateExamples.WebForms.CS.FileManager
{
    public partial class OverviewPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                fileManager.DisplayLanguage = LanguageSelector.SelectedValue;
            else
                PopulateLanguageSelector();
        }

        private void PopulateLanguageSelector()
        {
            foreach (var culture in FileUltimateConfiguration.AvailableDisplayCultures)
            {
                var listItem = new ListItem(culture.NativeName, culture.Name);
                if (culture.Name == FileUltimateConfiguration.CurrentLanguage.ClosestCulture.Name)
                    listItem.Selected = true;
                LanguageSelector.Items.Add(listItem);
            }
        }
    }
}