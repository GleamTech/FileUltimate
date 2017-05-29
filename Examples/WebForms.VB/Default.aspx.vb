Imports GleamTech.ExamplesCore
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
		                .Url = "filemanager/overview.aspx", 
		                .SourceFiles = New String() {"FileManager/Overview.aspx", "FileManager/Overview.aspx.vb"}, 
		                .DescriptionFile = "Descriptions/FileManager/Overview.html" 
	                }, 
                    New Example() With { 
		                .Title = "Setting properties programmatically", 
		                .Url = "filemanager/programmatic.aspx", 
		                .SourceFiles = New String() {"FileManager/Programmatic.aspx", "FileManager/Programmatic.aspx.vb"}, 
		                .DescriptionFile = "Descriptions/FileManager/Programmatic.html" 
	                }, 
                    New Example() With { 
		                .Title = "Displaying control on demand", 
		                .Url = "filemanager/display.aspx", 
		                .SourceFiles = New String() {"FileManager/Display.aspx", "FileManager/Display.aspx.vb"}, 
		                .DescriptionFile = "Descriptions/FileManager/Display.html" 
	                }, 
                    New Example() With { 
		                .Title = "Events", 
		                .Url = "filemanager/events.aspx", 
		                .SourceFiles = New String() {"FileManager/Events.aspx", "FileManager/Events.aspx.vb"}, 
		                .DescriptionFile = "Descriptions/FileManager/Events.html" 
	                }, 
                    New Example() With { 
		                .Title = "Dynamic folder and permissions", 
		                .Url = "filemanager/dynamic.aspx", 
		                .SourceFiles = New String() {"FileManager/Dynamic.aspx", "FileManager/Dynamic.aspx.vb"}, 
		                .DescriptionFile = "Descriptions/FileManager/Dynamic.html" 
	                }, 
                    New Example() With { 
		                .Title = "File/Folder chooser", 
		                .Url = "filemanager/chooser.aspx", 
		                .SourceFiles = New String() {"FileManager/Chooser.aspx", "FileManager/Chooser.aspx.vb"}, 
		                .DescriptionFile = "Descriptions/FileManager/Chooser.html" 
	                }
                }
            }
        }

        exampleExplorer.ExampleProjectName = "ASP.NET Web Forms (VB)"
        exampleExplorer.ExampleProjects = ExamplesCoreConfiguration.LoadExampleProjects(Server.MapPath("~/App_Data/ExampleProjects.json"))

    End Sub

End Class