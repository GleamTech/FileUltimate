@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.FileUltimate.AspNet.UI
@ModelType FileManager()

<!DOCTYPE html>

<html>
<head>
    <title>Displaying control on demand</title>
    @Me.RenderHead(Model(0))
</head>
<body style="margin: 20px;">

    1. FileManager instance displayed as inline element:
    <input type="button" value="Show" onclick="fileManager1.show()" />
    <input type="button" value="Hide" onclick="fileManager1.hide()" />
    <br /><br />
    @Me.RenderBody(Model(0))

    2. FileManager instance displayed as a modal dialog of viewport:
    <input type="button" value="Show" onclick="fileManager2.show()" />
    <br /><br />
    @Me.RenderBody(Model(1))

    3. FileManager instance displayed as a modal dialog of parent element:
    <input type="button" value="Show" onclick="fileManager3.show()" />
    <input type="button" value="Hide" onclick="fileManager3.hide()" />
    <br /><br />
    <div style="width: 1000px; height: 800px; border: 1px dashed black">
        Parent &lt;div&gt; element
        @Me.RenderBody(Model(2))
    </div>

</body>
</html>
