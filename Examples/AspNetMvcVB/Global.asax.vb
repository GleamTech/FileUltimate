Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.IO
Imports GleamTech.AspNet
Imports GleamTech.FileUltimate

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        RouteConfig.RegisterRoutes(RouteTable.Routes)

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
