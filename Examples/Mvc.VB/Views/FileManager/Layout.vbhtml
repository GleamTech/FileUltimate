@Imports GleamTech.Web.Mvc
@Imports GleamTech.FileUltimate
@ModelType FileManager

@Code
    ViewBag.Title = "Layout"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Section fileUltimateJs
    @Html.RenderJs(Model)
End Section
@Section fileUltimateCss
    @Html.RenderCss(Model)
End Section

@Html.RenderControl(Model)

