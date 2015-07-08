Imports GleamTech.FileUltimateExamples.Common

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ExamplesExplorerContext.Start()
    End Sub

End Class