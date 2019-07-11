<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Overview.aspx.cs" Inherits="GleamTech.FileUltimateExamples.WebForms.CS.FileUploader.Overview" %>
<%@ Register TagPrefix="GleamTech" Assembly="GleamTech.FileUltimate" Namespace="GleamTech.FileUltimate.AspNet.WebForms" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
</head>
<body style="margin: 20px;">
    
    <form id="form1" runat="server">
        Change language: <asp:DropDownList ID="LanguageSelector" runat="server" AutoPostBack="true"></asp:DropDownList>
        <br /><br />
    </form>

    <GleamTech:FileUploaderControl ID="fileUploader" runat="server" 
                                  Width="600"
                                  Height="300"
                                  Resizable="True" 
                                  UploadLocation="~/App_Data/Uploads" />

</body>
</html>
