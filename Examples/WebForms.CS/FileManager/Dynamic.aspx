<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Dynamic.aspx.cs" Inherits="GleamTech.FileUltimateExamples.WebForms.CS.FileManager.DynamicPage" %>
<%@ Register TagPrefix="GleamTech" Assembly="GleamTech.FileUltimate" Namespace="GleamTech.FileUltimate.AspNet.WebForms" %>
<%@ Register TagPrefix="GleamTech" Assembly="GleamTech.FileUltimate" Namespace="GleamTech.FileUltimate.AspNet.UI" %>

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
