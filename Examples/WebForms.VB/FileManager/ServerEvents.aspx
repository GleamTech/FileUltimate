<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ServerEvents.aspx.vb" Inherits="GleamTech.FileUltimateExamples.WebForms.VB.FileManager.ServerEventsPage" %>
<%@ Register TagPrefix="GleamTech" Assembly="GleamTech.FileUltimate" Namespace="GleamTech.FileUltimate.AspNet.WebForms" %>
<%@ Register TagPrefix="GleamTech" Assembly="GleamTech.FileUltimate" Namespace="GleamTech.FileUltimate.AspNet.UI" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Server-side events</title>
</head>
<body style="margin: 20px;">
    <p>
        Events:<br/>
        <iframe id="eventsIframe" src="<%=Request.Url.LocalPath%>?getLatestEvents=1" style="width: 800px; height: 200px; background-color: white; border: 1px solid black"></iframe>
        <br /><input type="button" value="Get Latest Events" onclick="document.getElementById('eventsIframe').contentWindow.location.reload();" />
    </p>

    <GleamTech:FileManagerControl ID="fileManager" runat="server" 
                           Width="800"
                           Height="600"
                           DisplayLanguage="en">
        <GleamTech:FileManagerRootFolder Name="Root Folder 1" Location="~/App_Data/RootFolder1" >
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
        </GleamTech:FileManagerRootFolder>       
    </GleamTech:FileManagerControl>

</body>
</html>
