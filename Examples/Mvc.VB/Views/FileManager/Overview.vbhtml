@Imports GleamTech.Web.Mvc
@Imports GleamTech.FileUltimate
@ModelType FileManager

<!DOCTYPE html>

<html>
<head>
    <title>Overview</title>
    @Html.RenderCss(Model)
    @Html.RenderJs(Model) @*If you choose, JS can also be rendered at the bottom of the page before the closing </body> tag*@
</head>
<body style="margin: 20px;">

@Using (Html.BeginForm())
    @<text>Change language: </text>@Html.DropDownList("languageSelector", DirectCast(ViewBag.LanguageList, SelectList), New With {.onchange = "this.form.submit();"})
    @<br/>@<br/>
End Using

@Html.RenderControl(Model)

</body>
</html>
