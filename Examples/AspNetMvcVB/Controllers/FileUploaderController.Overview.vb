Imports System.Linq
Imports GleamTech.FileUltimate.AspNet
Imports GleamTech.FileUltimate.AspNet.UI

Namespace Controllers
    Partial Public Class FileUploaderController

        Public Function Overview() As ActionResult
            'Default unit is pixels. Percentage can be specified as CssLength.Percentage(100)
            Dim fileUploader = New FileUploader() With {
             .Width = 600,
             .Height = 300,
             .Resizable = True,
             .UploadLocation = "~/App_Data/Uploads"
            }

            HandleLanguage(fileUploader)

            Return View(fileUploader)
        End Function

        Private Sub HandleLanguage(fileUploader As FileUploader)
            Dim selectedLanguage = Request("languageSelector")

            If selectedLanguage IsNot Nothing Then
                fileUploader.DisplayLanguage = selectedLanguage
            Else
                selectedLanguage = fileUploader.DisplayLanguage
            End If

            PopulateLanguageSelector(selectedLanguage)
        End Sub

        Private Sub PopulateLanguageSelector(selectedLanguage As String)
            ViewBag.LanguageList =  New SelectList(
                FileUltimateWebConfiguration.AvailableDisplayCultures.Select(function(culture) New With {
                        .Value = culture.Name,
                        .Text = culture.NativeName + $" ({culture.Name})"
                    }), 
                "Value",
                "Text",
                selectedLanguage
            )            
        End Sub
    End Class
End Namespace
