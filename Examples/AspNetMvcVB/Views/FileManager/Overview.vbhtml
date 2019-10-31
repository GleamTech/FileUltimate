@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.FileUltimate.AspNet.UI
@ModelType FileManager

<!DOCTYPE html>

<html>
<head>
    <title>Overview</title>
    @Me.RenderHead(Model)

    @*
        If you prefer, JS can also be rendered at the bottom of the page,
        by first calling RenderHeadWithoutJs in <head>:

        @Me.RenderHeadWithoutJs(Model)

        and then calling RenderJs before the closing </body> tag:

        @Me.RenderJs(Model)
    *@
</head>
<body style="margin: 20px;">

@Using (Html.BeginForm())
    @<text>Change language: </text>@Html.DropDownList("languageSelector", DirectCast(ViewBag.LanguageList, SelectList), New With {.onchange = "this.form.submit();"})
    @<br/>@<br/>
End Using

@Me.RenderBody(Model)

</body>
</html>
