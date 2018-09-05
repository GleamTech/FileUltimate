<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Dynamic.aspx.vb" Inherits="GleamTech.FileUltimateExamples.WebForms.VB.FileManager.DynamicPage" %>
<%@ Register TagPrefix="GleamTech" Assembly="GleamTech.FileUltimate" Namespace="GleamTech.FileUltimate.AspNet.WebForms" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Dynamic folder and permissions</title>
</head>
<body style="margin: 20px;">
    
    <form id="form1" runat="server">
        Change user: <asp:DropDownList ID="UserSelector" runat="server" AutoPostBack="true"></asp:DropDownList>
        <br /><br />
    </form>
    
    <GleamTech:FileManagerControl ID="fileManager" runat="server" Width="800" Height="600" DisplayLanguage="en" />

</body>
</html>
