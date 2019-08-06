@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.FileUltimate.AspNet.UI
@ModelType FileManager

<!DOCTYPE html>

<html>
<head>
    <title>Server-side events</title>
    @Me.RenderHead(Model)
</head>
<body style="margin: 20px;">
    <p>
        Events:<br />
        <iframe id="eventsIframe" src="@Url.Action("GetLatestEvents")" style="width: 800px; height: 200px; background-color: white; border: 1px solid black"></iframe>
        <br /><input type="button" value="Get Latest Events" onclick="document.getElementById('eventsIframe').contentWindow.location.reload();" />
    </p>

    @Me.RenderBody(Model)
</body>
</html>
