Imports System.Globalization
Imports GleamTech.FileUltimate

Namespace FileManager

    Public Class OverviewPage
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                fileManager.DisplayLanguage = LanguageSelector.SelectedValue
            Else
                PopulateLanguageSelector()
            End If
        End Sub

        Private Sub PopulateLanguageSelector()
            For Each cultureInfo As CultureInfo In FileUltimateConfiguration.AvailableDisplayCultures
                Dim listItem = New ListItem(cultureInfo.NativeName, cultureInfo.Name)
                If cultureInfo.Name = FileUltimateConfiguration.CurrentLanguage.ClosestCulture.Name Then
                    listItem.Selected = True
                End If
                LanguageSelector.Items.Add(listItem)
            Next
        End Sub

    End Class
End Namespace