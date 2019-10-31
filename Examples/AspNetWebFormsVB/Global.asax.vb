Imports System.IO
Imports GleamTech.AspNet
Imports GleamTech.FileUltimate

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Dim gleamTechConfig = Hosting.ResolvePhysicalPath("~/App_Data/GleamTech.config")
        If File.Exists(gleamTechConfig) Then
            GleamTechConfiguration.Current.Load(gleamTechConfig)
        End If

        Dim fileUltimateConfig = Hosting.ResolvePhysicalPath("~/App_Data/FileUltimate.config")
        If File.Exists(fileUltimateConfig) Then
            FileUltimateConfiguration.Current.Load(fileUltimateConfig)
        End If
    End Sub

End Class