@Imports GleamTech.ExamplesCore
@Imports GleamTech.Web.Mvc
@Imports GleamTech.FileUltimate
@Code
    Dim exampleExplorer = New ExampleExplorer() With {
        .FullViewport = True,
        .NavigationTitle = "FileUltimate Examples",
        .VersionTitle = "v" + FileUltimateConfiguration.AssemblyInfo.FileVersion.ToString(),
        .Examples = New ExampleBase() {
            New ExampleFolder() With {
                .Title = "FileManager",
                .Children = New ExampleBase() {
                    New Example() With {
                        .Title = "Overview",
                        .Url = "filemanager/overview",
                        .SourceFiles = New String() {"Views/FileManager/Overview.vbhtml", "Controllers/FileManagerController.Overview.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Overview.html"
                    },
                    New Example() With {
                        .Title = "Using page layouts",
                        .Url = "filemanager/layout",
                        .SourceFiles = New String() {"Views/FileManager/Layout.vbhtml", "Views/Shared/_Layout.vbhtml", "Controllers/FileManagerController.Layout.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Layout.html"
                    },
                    New Example() With {
                        .Title = "Displaying control on demand",
                        .Url = "filemanager/display",
                        .SourceFiles = New String() {"Views/FileManager/Display.vbhtml", "Controllers/FileManagerController.Display.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Display.html"
                    },
                    New Example() With {
                        .Title = "Events",
                        .Url = "filemanager/events",
                        .SourceFiles = New String() {"Views/FileManager/Events.vbhtml", "Controllers/FileManagerController.Events.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Events.html"
                    },
                    New Example() With {
                        .Title = "Dynamic folder and permissions",
                        .Url = "filemanager/dynamic",
                        .SourceFiles = New String() {"Views/FileManager/Dynamic.vbhtml", "Controllers/FileManagerController.Dynamic.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Dynamic.html"
                    },
                    New Example() With {
                        .Title = "File/Folder chooser",
                        .Url = "filemanager/chooser",
                        .SourceFiles = New String() {"Views/FileManager/Chooser.vbhtml", "Controllers/FileManagerController.Chooser.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Chooser.html"
                    }
                }
            }
        },
        .ExampleProjectName = "ASP.NET MVC (VB)",
        .ExampleProjects = ExamplesCoreConfiguration.LoadExampleProjects(Server.MapPath("~/App_Data/ExampleProjects.json"))
    }
End Code
<!DOCTYPE html>

<html>
<head>
    <title>FileUltimate Examples - ASP.NET MVC (VB)</title>

    @Html.RenderCss(exampleExplorer)
    @Html.RenderJs(exampleExplorer)

</head>
<body>
    @Html.RenderControl(exampleExplorer)
</body>
</html>
