<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Display.aspx.vb" Inherits="GleamTech.FileUltimateExamples.WebForms.VB.FileManager.DisplayPage" %>
<%@ Register TagPrefix="GleamTech" Assembly="GleamTech.FileUltimate" Namespace="GleamTech.FileUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
</head>
<body style="margin: 20px;">
    
    1. FileManager instance displayed as inline element:
    <input type="button" value="Show" onclick="fileManager1.show()" />
    <input type="button" value="Hide" onclick="fileManager1.hide()" />
    <br /><br />
    <GleamTech:FileManager ID="fileManager1" runat="server" 
                           Width="800"
                           Height="600" 
                           DisplayLanguage="en"
                           ShowOnLoad="false">
        <GleamTech:FileManagerRootFolder Name="Root Folder 1" Location="~/App_Data/RootFolder1" >
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
        </GleamTech:FileManagerRootFolder>
    </GleamTech:FileManager>
    
    2. FileManager instance displayed as a modal dialog of viewport:
    <input type="button" value="Show" onclick="fileManager2.show()" />
    <br /><br />
    <GleamTech:FileManager ID="fileManager2" runat="server" 
                           Width="800"
                           Height="600" 
                           DisplayLanguage="en"
                           ShowOnLoad="false"
                           FullViewport="true"
                           ModalDialog="true"
                           ModalDialogTitle="FileManager as a modal dialog of viewport">
        <GleamTech:FileManagerRootFolder Name="Root Folder 1" Location="~/App_Data/RootFolder1" >
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
        </GleamTech:FileManagerRootFolder>       
    </GleamTech:FileManager>

    2. FileManager instance displayed as a modal dialog of parent element:
    <input type="button" value="Show" onclick="fileManager3.show()" />
    <input type="button" value="Hide" onclick="fileManager3.hide()" />
    <br /><br />
    <div style="width: 1000px; height: 800px; border: 1px dashed black">
        Parent &lt;div&gt; element
        <GleamTech:FileManager ID="fileManager3" runat="server" 
                               Width="800"
                               Height="600" 
                               DisplayLanguage="en"
                               ShowOnLoad="false"
                               ModalDialog="true"
                               ModalDialogTitle="FileManager as a modal dialog of parent element">
            <GleamTech:FileManagerRootFolder Name="Root Folder 1" Location="~/App_Data/RootFolder1" >
                <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
            </GleamTech:FileManagerRootFolder>       
        </GleamTech:FileManager>
    </div>

</body>
</html>
