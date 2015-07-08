<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="GleamTech.FileUltimateExamples.WebForms.VB.DefaultPage" %>
<%@ Import Namespace="GleamTech.FileUltimate" %>
<%@ Import Namespace="GleamTech.FileUltimateExamples.Common" %>
<%@ Import Namespace="GleamTech.FileUltimateExamples.WebForms.VB" %>
<%@ Import Namespace="GleamTech.Web" %>

<!DOCTYPE html>

<html>
    <head>
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <title>FileUltimate Examples - ASP.NET Web Forms (VB)</title>
        
        <link href="<%=ResourceManager.GetUrl(ControlContext.LibraryCssBundle)%>" rel="stylesheet" />
        <link href="<%=ResourceManager.GetUrl(ExamplesExplorerContext.CssBundle)%>" rel="stylesheet" />
        
        <script src="<%=ResourceManager.GetUrl(ControlContext.LibraryJsBundle)%>"></script>
        <script src="<%=ResourceManager.GetUrl(ExamplesExplorerContext.JsBundle)%>"></script>

        <script type="text/javascript">
            examplesData = [
                {
                    text: "FileManager",
                    assemblyResourceLocator: "<%=GetType(DefaultPage).AssemblyQualifiedName%>",
                    children: [
                        {
                            text: "Overview",
                            url: "filemanager/overview.aspx",
                            sourceFiles: ["FileManager/Overview.aspx", "FileManager/Overview.aspx.vb"],
                            descriptionFile: "Descriptions/WebForms/FileManager/Overview.html",
                            leaf: true
                        },
                        {
                            text: "Setting properties programmatically",
                            url: "filemanager/programmatic.aspx",
                            sourceFiles: ["FileManager/Programmatic.aspx", "FileManager/Programmatic.aspx.vb"],
                            descriptionFile: "Descriptions/WebForms/FileManager/Programmatic.html",
                            leaf: true
                        },
                        {
                            text: "Displaying control on demand",
                            url: "filemanager/display.aspx",
                            sourceFiles: ["FileManager/Display.aspx", "FileManager/Display.aspx.vb"],
                            descriptionFile: "Descriptions/WebForms/FileManager/Display.html",
                            leaf: true
                        },
                        {
                            text: "Events",
                            url: "filemanager/events.aspx",
                            sourceFiles: ["FileManager/Events.aspx", "FileManager/Events.aspx.vb"],
                            descriptionFile: "Descriptions/WebForms/FileManager/Events.html",
                            leaf: true
                        },
                        {
                            text: "Dynamic folder and permissions",
                            url: "filemanager/dynamic.aspx",
                            sourceFiles: ["FileManager/Dynamic.aspx", "FileManager/Dynamic.aspx.vb"],
                            descriptionFile: "Descriptions/WebForms/FileManager/Dynamic.html",
                            leaf: true
                        },
                        {
                            text: "File/Folder chooser",
                            url: "filemanager/chooser.aspx",
                            sourceFiles: ["FileManager/Chooser.aspx", "FileManager/Chooser.aspx.vb"],
                            descriptionFile: "Descriptions/WebForms/FileManager/Chooser.html",
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
