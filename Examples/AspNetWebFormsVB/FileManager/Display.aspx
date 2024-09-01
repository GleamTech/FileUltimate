<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Display.aspx.vb" Inherits="GleamTech.FileUltimateExamples.AspNetWebFormsVB.FileManager.DisplayPage" %>
<%@ Register TagPrefix="GleamTech" Assembly="GleamTech.FileUltimate" Namespace="GleamTech.FileUltimate.AspNet.WebForms" %>
<%@ Register TagPrefix="GleamTech" Assembly="GleamTech.FileUltimate" Namespace="GleamTech.FileUltimate.AspNet.UI" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Displaying control on demand</title>
</head>
<body style="margin: 20px;">
    
    1. FileManager instance displayed as inline element:
    <input type="button" value="Show" onclick="fileManager1.show()" />
    <input type="button" value="Hide" onclick="fileManager1.hide()" />
    <br /><br />
    <GleamTech:FileManagerControl ID="fileManager1" runat="server" 
                           Width="800"
                           Height="600" 
                           DisplayLanguage="en"
                           Hidden="True">
        <GleamTech:FileManagerRootFolder Name="Root Folder 1" Location="~/App_Data/RootFolder1" >
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
        </GleamTech:FileManagerRootFolder>
    </GleamTech:FileManagerControl>
    
    2. FileManager instance displayed as a modal dialog:
    <input type="button" value="Show" onclick="fileManager2.show()" />
    <br /><br />
    <GleamTech:FileManagerControl ID="fileManager2" runat="server" 
                           Width="800"
                           Height="600" 
                           DisplayLanguage="en"
                           Hidden="True"
                           DisplayMode="Window"
                           WindowOptions-Modal="True"
                           WindowOptions-Maximizable="True"
                           WindowOptions-Minimizable="True"
                           WindowOptions-Title="FileManager as a modal dialog">
        <GleamTech:FileManagerRootFolder Name="Root Folder 1" Location="~/App_Data/RootFolder1" >
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
        </GleamTech:FileManagerRootFolder>       
    </GleamTech:FileManagerControl>

    3. FileManager instance displayed as a panel:
    <input type="button" value="Show" onclick="fileManager3.show()" />
    <input type="button" value="Hide" onclick="fileManager3.hide()" />
    <br /><br />
    <GleamTech:FileManagerControl ID="fileManager3" runat="server" 
                           Width="800"
                           Height="600" 
                           DisplayLanguage="en"
                           Hidden="True"
                           DisplayMode="Panel"
                           PanelOptions-Collapsible="True"                                  
                           PanelOptions-Title="FileManager as a panel">
        <GleamTech:FileManagerRootFolder Name="Root Folder 1" Location="~/App_Data/RootFolder1" >
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
        </GleamTech:FileManagerRootFolder>       
    </GleamTech:FileManagerControl>

</body>
</html>
