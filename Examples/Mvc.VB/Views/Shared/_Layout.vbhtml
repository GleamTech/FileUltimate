<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
    @If (IsSectionDefined("fileUltimateHead")) Then
        @RenderSection("fileUltimateHead")
    End If
</head>
<body style="margin: 20px;">
    <div style="width: 800px;">
        @RenderBody()
    </div>
</body>
</html>
