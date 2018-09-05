@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.FileUltimate.AspNet.UI
@ModelType FileManager

<!DOCTYPE html>

<html>
<head>
    <title>Dynamic folder and permissions</title>
    @Me.RenderHead(Model)
</head>
<body style="margin: 20px;">

@Using (Html.BeginForm())
    @<text>Change user: </text>@Html.DropDownList("userSelector", DirectCast(ViewBag.UserList, SelectList), New With {.onchange = "this.form.submit();"})
    @<br/>@<br/>
End Using

@Me.RenderBody(Model)

</body>
</html>
