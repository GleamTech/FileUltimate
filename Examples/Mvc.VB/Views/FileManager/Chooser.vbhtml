@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.FileUltimate.AspNet.UI
@ModelType FileManager()

<!DOCTYPE html>

<html>
<head>
    <title>File/Folder chooser</title>
    @Me.RenderHead(Model(0))
    <script>
        function fileManagerChosen(sender, e) {
            //Pretty print the chosen info (from event object) when it changes
            var json = JSON.stringify(e, null, 2);

            alert("Chosen event:\n" + json);
        }
    </script>
</head>
<body style="margin: 20px;">

    1. Chooser with single file selection:
    <input type="button" value="Choose..." onclick="fileManager1.show()" />
    <br /><br />
    @Me.RenderBody(Model(0))

    2. Chooser with single folder selection:
    <input type="button" value="Choose..." onclick="fileManager2.show()" />
    <br /><br />
    @Me.RenderBody(Model(1))

    3. Chooser with single file or folder selection:
    <input type="button" value="Choose..." onclick="fileManager3.show()" />
    <br /><br />
    @Me.RenderBody(Model(2))

    4. Chooser with multiple file selections:
    <input type="button" value="Choose..." onclick="fileManager4.show()" />
    <br /><br />
    @Me.RenderBody(Model(3))

    5. Chooser with multiple folder selections:
    <input type="button" value="Choose..." onclick="fileManager5.show()" />
    <br /><br />
    @Me.RenderBody(Model(4))

    6. Chooser with multiple file or folder selections:
    <input type="button" value="Choose..." onclick="fileManager6.show()" />
    <br /><br />
    @Me.RenderBody(Model(5))

    7. Chooser displayed as inline element (also hide ribbon completely):
    <input type="button" value="Choose..." onclick="fileManager7.show()" />
    <br /><br />
    @Me.RenderBody(Model(6))

</body>
</html>
