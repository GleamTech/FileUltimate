<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Events.aspx.vb" Inherits="GleamTech.FileUltimateExamples.WebForms.VB.FileManager.EventsPage" %>
<%@ Register TagPrefix="GleamTech" Assembly="GleamTech.FileUltimate" Namespace="GleamTech.FileUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
</head>
<body style="margin: 20px;">
    <iframe id="eventsIframe" src="<%=Request.Url.LocalPath%>?getLatestEvents=1" style="width: 800px; height: 200px; background-color: white; border: 1px solid black"></iframe>
    <br /><input type="button" value="Get Latest Events" onclick="document.getElementById('eventsIframe').contentWindow.location.reload();" />
    <br /><br />

    <GleamTech:FileManager ID="fileManager" runat="server" 
                           Width="800"
                           Height="600"
                           DisplayLanguage="en">
        <GleamTech:FileManagerRootFolder Name="Root Folder 1" Location="~/App_Data/RootFolder1" >
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
        </GleamTech:FileManagerRootFolder>       
    </GleamTech:FileManager>

</body>
</html>
