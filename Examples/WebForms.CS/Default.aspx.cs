using System;
using System.Web.UI;
using GleamTech.ExamplesCore;
using GleamTech.FileUltimate;

namespace GleamTech.FileUltimateExamples.WebForms.CS
{
    public partial class DefaultPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            exampleExplorer.VersionTitle = "v" + FileUltimateConfiguration.AssemblyInfo.FileVersion;

            exampleExplorer.Examples = new ExampleBase[]
            {
                new ExampleFolder
                {
                    Title = "FileManager",
                    Children = new ExampleBase[]
                    {
                        new Example
                        {
                            Title = "Overview",
                            Url = "filemanager/overview.aspx",
                            SourceFiles = new[] {"FileManager/Overview.aspx", "FileManager/Overview.aspx.cs"},
                            DescriptionFile = "Descriptions/FileManager/Overview.html"
                        },
                        new Example
                        {
                            Title = "Setting properties programmatically",
                            Url = "filemanager/programmatic.aspx",
                            SourceFiles = new[] { "FileManager/Programmatic.aspx", "FileManager/Programmatic.aspx.cs"},
                            DescriptionFile = "Descriptions/FileManager/Programmatic.html"
                        },
                        new Example
                        {
                            Title = "Displaying control on demand",
                            Url = "filemanager/display.aspx",
                            SourceFiles = new[] {"FileManager/Display.aspx", "FileManager/Display.aspx.cs"},
                            DescriptionFile = "Descriptions/FileManager/Display.html"
                        },
                        new Example
                        {
                            Title = "Events",
                            Url = "filemanager/events.aspx",
                            SourceFiles = new[] {"FileManager/Events.aspx", "FileManager/Events.aspx.cs"},
                            DescriptionFile = "Descriptions/FileManager/Events.html"
                        },
                        new Example
                        {
                            Title = "Dynamic folder and permissions",
                            Url = "filemanager/dynamic.aspx",
                            SourceFiles = new[] {"FileManager/Dynamic.aspx", "FileManager/Dynamic.aspx.cs"},
                            DescriptionFile = "Descriptions/FileManager/Dynamic.html"
                        },
                        new Example
                        {
                            Title = "File/Folder chooser",
                            Url = "filemanager/chooser.aspx",
                            SourceFiles = new[] {"FileManager/Chooser.aspx", "FileManager/Chooser.aspx.cs"},
                            DescriptionFile = "Descriptions/FileManager/Chooser.html"
                        }
                    }
                }
            };

            exampleExplorer.ExampleProjectName = "ASP.NET Web Forms (C#)";
            exampleExplorer.ExampleProjects = ExamplesCoreConfiguration.LoadExampleProjects(Server.MapPath("~/App_Data/ExampleProjects.json"));
        }
    }
}