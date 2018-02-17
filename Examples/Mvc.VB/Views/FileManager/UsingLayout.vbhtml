@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.FileUltimate
@ModelType FileManager

@Code
    ViewBag.Title = "UsingLayout"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Section LayoutHead
    @Me.RenderHead(Model)
End Section

@Me.RenderBody(Model)

