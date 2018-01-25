@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.FileUltimate
@ModelType FileManager

@Code
    ViewBag.Title = "Layout"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Section fileUltimateHead
    @Me.RenderHead(Model)
End Section

@Me.RenderBody(Model)

