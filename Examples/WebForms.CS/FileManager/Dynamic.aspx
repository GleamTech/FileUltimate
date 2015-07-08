<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Dynamic.aspx.cs" Inherits="GleamTech.FileUltimateExamples.WebForms.CS.FileManager.DynamicPage" %>
<%@ Register TagPrefix="GleamTech" Assembly="GleamTech.FileUltimate" Namespace="GleamTech.FileUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
</head>
<body style="margin: 20px;">
    
    <form id="form1" runat="server">
        Change user: <asp:DropDownList ID="UserSelector" runat="server" AutoPostBack="true"></asp:DropDownList>
        <br /><br />
    </form>
    
    <GleamTech:FileManager ID="fileManager" runat="server" Width="800" Height="600" DisplayLanguage="en" />

</body>
</html>
