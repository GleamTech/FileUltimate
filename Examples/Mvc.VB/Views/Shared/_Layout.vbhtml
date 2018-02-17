<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
    @If (IsSectionDefined("LayoutHead")) Then
        @RenderSection("LayoutHead")
    End If
</head>
<body style="margin: 20px;">
    <div style="width: 1000px; height: 800px; border: 1px dashed black">
        Parent layout
        @RenderBody()
    </div>
</body>
</html>
