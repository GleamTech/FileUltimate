@Imports GleamTech.FileUltimate
@Imports GleamTech.FileUltimateExamples.Common
@Imports GleamTech.FileUltimateExamples.Mvc.VB
@Imports GleamTech.Web

<!DOCTYPE html>

<html>
    <head>
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <title>FileUltimate Examples - ASP.NET MVC (VB)</title>

        <link href="@ResourceManager.GetUrl(FileUltimateConfiguration.LibraryCssBundle)" rel="stylesheet" />
        <link href="@ResourceManager.GetUrl(ExamplesExplorerContext.CssBundle)" rel="stylesheet" />
        
        <script src="@ResourceManager.GetUrl(FileUltimateConfiguration.LibraryJsBundle)"></script>
        <script src="@ResourceManager.GetUrl(ExamplesExplorerContext.JsBundle)"></script>

        <script type="text/javascript">
            examplesData = [
                {
                    text: "FileManager",
                    assemblyResourceLocator: "@GetType(MvcApplication).AssemblyQualifiedName",
                    children: [
                        {
                            text: "Overview",
                            url: "filemanager/overview",
                            sourceFiles: ["Views/FileManager/Overview.vbhtml", "Controllers/FileManagerController.Overview.vb"],
                            descriptionFile: "Descriptions/Mvc/FileManager/Overview.html",
                            leaf: true
                        },
                        {
                            text: "Using page layouts",
                            url: "filemanager/layout",
                            sourceFiles: ["Views/FileManager/Layout.vbhtml", "Views/Shared/_Layout.vbhtml", "Controllers/FileManagerController.Layout.vb"],
                            descriptionFile: "Descriptions/Mvc/FileManager/Layout.html",
                            leaf: true
                        },
                        {
                            text: "Displaying control on demand",
                            url: "filemanager/display",
                            sourceFiles: ["Views/FileManager/Display.vbhtml", "Controllers/FileManagerController.Display.vb"],
                            descriptionFile: "Descriptions/Mvc/FileManager/Display.html",
                            leaf: true
                        },
                        {
                            text: "Events",
                            url: "filemanager/events",
                            sourceFiles: ["Views/FileManager/Events.vbhtml", "Controllers/FileManagerController.Events.vb"],
                            descriptionFile: "Descriptions/Mvc/FileManager/Events.html",
                            leaf: true
                        },
                        {
                            text: "Dynamic folder and permissions",
                            url: "filemanager/dynamic",
                            sourceFiles: ["Views/FileManager/Dynamic.vbhtml", "Controllers/FileManagerController.Dynamic.vb"],
                            descriptionFile: "Descriptions/Mvc/FileManager/Dynamic.html",
                            leaf: true
                        },
                        {
                            text: "File/Folder chooser",
                            url: "filemanager/chooser",
                            sourceFiles: ["Views/FileManager/Chooser.vbhtml", "Controllers/FileManagerController.Chooser.vb"],
                            descriptionFile: "Descriptions/Mvc/FileManager/Chooser.html",
                            leaf: true
                        }
                    ]
                }
            ]; 
        </script>
    </head>
    <body>
    </body>
</html>
