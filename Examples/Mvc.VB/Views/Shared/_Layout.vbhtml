<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
    @If (IsSectionDefined("fileUltimateCss")) Then
        @RenderSection("fileUltimateCss")
    End If
    @If (IsSectionDefined("fileUltimateJs")) Then
        @RenderSection("fileUltimateJs")
    End If
</head>
<body style="margin: 20px;">
    <div style="width: 800px;">
        @RenderBody()
    </div>
</body>
</html>
