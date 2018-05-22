﻿@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.Examples
@Imports GleamTech.FileUltimate
@Imports GleamTech.FileUltimate.AspNet.UI
@Code
    Dim exampleExplorer = New ExampleExplorer() With {
        .DisplayMode = GleamTech.AspNet.UI.DisplayMode.Viewport,
        .NavigationTitle = "FileUltimate Examples",
        .VersionTitle = "v" + FileUltimateConfiguration.AssemblyInfo.FileVersion.ToString(),
        .Examples = New ExampleBase() {
            New ExampleFolder() With {
                .Title = "FileManager",
                .Children = New ExampleBase() {
                    New Example() With {
                        .Title = "Overview",
                        .Url = "FileManager/Overview",
                        .SourceFiles = New String() {"Views/FileManager/Overview.vbhtml", "Controllers/FileManagerController.Overview.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Overview.html"
                    },
                    New Example() With {
                        .Title = "Displaying control on demand",
                        .Url = "FileManager/Display",
                        .SourceFiles = New String() {"Views/FileManager/Display.vbhtml", "Controllers/FileManagerController.Display.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Display.html"
                    },
                    New Example() With {
                        .Title = "Events",
                        .Url = "FileManager/Events",
                        .SourceFiles = New String() {"Views/FileManager/Events.vbhtml", "Controllers/FileManagerController.Events.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Events.html"
                    },
                    New Example() With {
                        .Title = "Dynamic folder and permissions",
                        .Url = "FileManager/Dynamic",
                        .SourceFiles = New String() {"Views/FileManager/Dynamic.vbhtml", "Controllers/FileManagerController.Dynamic.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Dynamic.html"
                    },
                    New Example() With {
                        .Title = "File/Folder chooser",
                        .Url = "FileManager/Chooser",
                        .SourceFiles = New String() {"Views/FileManager/Chooser.vbhtml", "Controllers/FileManagerController.Chooser.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Chooser.html"
                    },
                    New Example() With {
                        .Title = "Using MVC layout",
                        .Url = "FileManager/UsingLayout",
                        .SourceFiles = New String() {"Views/FileManager/UsingLayout.vbhtml", "Views/Shared/_Layout.vbhtml", "Controllers/FileManagerController.UsingLayout.vb"},
                        .DescriptionFile = "Descriptions/FileManager/UsingLayout.html"
                    },
                    New Example() With {
                        .Title = "Using MVC partial view",
                        .Url = "FileManager/UsingPartial",
                        .SourceFiles = New String() {"Views/FileManager/UsingPartial.vbhtml", "Views/FileManager/FileManagerPartialView.vbhtml", "Controllers/FileManagerController.UsingPartial.vb"},
                        .DescriptionFile = "Descriptions/FileManager/UsingPartial.html"
                    }
                }
            }
        },
        .ExampleProjectName = "ASP.NET MVC (VB)",
        .ExampleProjects = ExamplesConfiguration.LoadExampleProjects(Server.MapPath("~/App_Data/ExampleProjects.json"))
    }
End Code
<!DOCTYPE html>

<html>
<head>
    <title>FileUltimate Examples - ASP.NET MVC (VB)</title>
    @Me.RenderHead(exampleExplorer)
</head>
<body>
    @Me.RenderBody(exampleExplorer)
</body>
</html>
