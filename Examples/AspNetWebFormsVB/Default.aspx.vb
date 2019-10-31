Imports GleamTech.Examples
Imports GleamTech.FileUltimate

Public Class DefaultPage
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        exampleExplorer.VersionTitle = "v" + FileUltimateConfiguration.AssemblyInfo.FileVersion.ToString()

        exampleExplorer.Examples = New ExampleBase() {
            New ExampleFolder() With {
                .Title = "FileManager",
                .Children = New ExampleBase() {
                    New Example() With {
                        .Title = "Overview",
                        .Url = "FileManager/Overview.aspx",
                        .SourceFiles = New String() {"FileManager/Overview.aspx", "FileManager/Overview.aspx.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Overview.html"
                    },
                    New Example() With {
                        .Title = "Setting properties programmatically",
                        .Url = "FileManager/Programmatic.aspx",
                        .SourceFiles = New String() {"FileManager/Programmatic.aspx", "FileManager/Programmatic.aspx.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Programmatic.html"
                    },
                    New Example() With {
                        .Title = "Displaying control on demand",
                        .Url = "FileManager/Display.aspx",
                        .SourceFiles = New String() {"FileManager/Display.aspx", "FileManager/Display.aspx.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Display.html"
                    },
                    New Example() With {
                        .Title = "Server-side events",
                        .Url = "FileManager/ServerEvents.aspx",
                        .SourceFiles = New String() {"FileManager/ServerEvents.aspx", "FileManager/ServerEvents.aspx.vb"},
                        .DescriptionFile = "Descriptions/FileManager/ServerEvents.html"
                    },
                    New Example() With {
                        .Title = "Client-side events",
                        .Url = "FileManager/ClientEvents.aspx",
                        .SourceFiles = New String() {"FileManager/ClientEvents.aspx", "FileManager/ClientEvents.aspx.vb"},
                        .DescriptionFile = "Descriptions/FileManager/ClientEvents.html"
                    },
                    New Example() With {
                        .Title = "Dynamic folder and permissions",
                        .Url = "FileManager/Dynamic.aspx",
                        .SourceFiles = New String() {"FileManager/Dynamic.aspx", "FileManager/Dynamic.aspx.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Dynamic.html"
                    },
                    New Example() With {
                        .Title = "File/Folder chooser",
                        .Url = "FileManager/Chooser.aspx",
                        .SourceFiles = New String() {"FileManager/Chooser.aspx", "FileManager/Chooser.aspx.vb"},
                        .DescriptionFile = "Descriptions/FileManager/Chooser.html"
                    }
                }
            },
            New ExampleFolder() With {
                .Title = "FileUploader",
                .Children = New ExampleBase() {
                    New Example() With {
                        .Title = "Overview",
                        .Url = "FileUploader/Overview.aspx",
                        .SourceFiles = New String() {"FileUploader/Overview.aspx", "FileUploader/Overview.aspx.vb"},
                        .DescriptionFile = "Descriptions/FileUploader/Overview.html"
                    }
                }
            }
        }

        exampleExplorer.ExampleProjectName = "ASP.NET Web Forms (VB)"
        exampleExplorer.ExampleProjects = ExamplesConfiguration.LoadExampleProjects("~/App_Data/ExampleProjects.json")

    End Sub

End Class