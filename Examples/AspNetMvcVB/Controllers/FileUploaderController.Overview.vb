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

            If Request("languageSelector") IsNot Nothing Then
                fileUploader.DisplayLanguage = Request("languageSelector")
            End If

            PopulateLanguageSelector()

            Return View(fileUploader)
        End Function

        Private Sub PopulateLanguageSelector()
            ViewBag.LanguageList = New SelectList(FileUltimateWebConfiguration.AvailableDisplayCultures, "Name", "NativeName", If(Request("languageSelector"), FileUltimateWebConfiguration.CurrentLanguage.ClosestCulture.Name))
        End Sub
    End Class
End Namespace
