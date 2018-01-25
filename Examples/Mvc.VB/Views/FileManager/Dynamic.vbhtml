@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.FileUltimate
@ModelType FileManager

<!DOCTYPE html>

<html>
<head>
    <title>Dynamic</title>
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
