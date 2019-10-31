Imports System.Globalization
Imports GleamTech.FileUltimate.AspNet

Namespace FileUploader

    Public Class OverviewPage
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                FileUploader.DisplayLanguage = LanguageSelector.SelectedValue
            Else
                PopulateLanguageSelector()
            End If
        End Sub

        Private Sub PopulateLanguageSelector()
            For Each cultureInfo As CultureInfo In FileUltimateWebConfiguration.AvailableDisplayCultures
                Dim listItem = New ListItem(cultureInfo.NativeName, cultureInfo.Name)
                If cultureInfo.Name = FileUltimateWebConfiguration.CurrentLanguage.ClosestCulture.Name Then
                    listItem.Selected = True
                End If
                LanguageSelector.Items.Add(listItem)
            Next
        End Sub

    End Class
End Namespace