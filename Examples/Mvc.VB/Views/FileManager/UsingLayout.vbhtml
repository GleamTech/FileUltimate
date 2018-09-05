@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.FileUltimate.AspNet.UI
@ModelType FileManager

@Code
    ViewBag.Title = "Using MVC layout"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Section LayoutHead
    @Me.RenderHead(Model)
End Section

@Me.RenderBody(Model)

