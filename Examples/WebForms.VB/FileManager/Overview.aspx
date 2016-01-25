<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Overview.aspx.vb" Inherits="GleamTech.FileUltimateExamples.WebForms.VB.FileManager.OverviewPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.FileUltimate" Assembly="GleamTech.FileUltimate" %>

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

    <GleamTech:FileManager ID="fileManager" runat="server" 
                           Width="800"
                           Height="600"
                           Resizable="True">
        
        <%--
            For connecting as a specific user to a protected folder (UNC or local) use this format:
            Location="Path=\\server\share; User Name=USERNAME; Password=PASSWORD"
            Please see description of Location property on the right pane for more information.
        --%>
        <GleamTech:FileManagerRootFolder Name="1. Root Folder" Location="~/App_Data/RootFolder1">
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
        </GleamTech:FileManagerRootFolder>       
        
        <GleamTech:FileManagerRootFolder Name="2. Feature Tests" Location="~/App_Data/Feature Tests" > 
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="ReadOnly"/>

            <GleamTech:FileManagerAccessControl Path="\6. Permissions" AllowedPermissions="ListFiles, ListSubfolders" /> 
            <GleamTech:FileManagerAccessControl Path="\6. Permissions\01. Full" AllowedPermissions="Full"/>
            <GleamTech:FileManagerAccessControl Path="\6. Permissions\02. Read" AllowedPermissions="ReadOnly"/>
            <GleamTech:FileManagerAccessControl Path="\6. Permissions\03. List subfolders" AllowedPermissions="ListSubfolders"/>
            <GleamTech:FileManagerAccessControl Path="\6. Permissions\04. List files" AllowedPermissions="ListFiles"/>
            <GleamTech:FileManagerAccessControl Path="\6. Permissions\05. Create" AllowedPermissions="Create, ListFiles, ListSubfolders"/>
            <GleamTech:FileManagerAccessControl Path="\6. Permissions\06. Delete" AllowedPermissions="Delete, ListFiles, ListSubfolders"/>
            <GleamTech:FileManagerAccessControl Path="\6. Permissions\07. Rename" AllowedPermissions="Rename, ListFiles, ListSubfolders"/>
            <GleamTech:FileManagerAccessControl Path="\6. Permissions\08. Edit" AllowedPermissions="Edit, ListFiles, ListSubfolders"/>
            <GleamTech:FileManagerAccessControl Path="\6. Permissions\09. Upload" AllowedPermissions="Upload, ListFiles, ListSubfolders"/>
            <GleamTech:FileManagerAccessControl Path="\6. Permissions\10. Download" AllowedPermissions="Download, ListFiles, ListSubfolders"/>
            <GleamTech:FileManagerAccessControl Path="\6. Permissions\11. Compress" AllowedPermissions="Compress, ListFiles, ListSubfolders"/>
            <GleamTech:FileManagerAccessControl Path="\6. Permissions\12. Extract" AllowedPermissions="Extract, ListFiles, ListSubfolders"/>
            <GleamTech:FileManagerAccessControl Path="\6. Permissions\13. Cut" AllowedPermissions="Cut, ListFiles, ListSubfolders"/>
            <GleamTech:FileManagerAccessControl Path="\6. Permissions\14. Copy" AllowedPermissions="Copy, ListFiles, ListSubfolders"/>
            <GleamTech:FileManagerAccessControl Path="\6. Permissions\15. Paste" AllowedPermissions="Paste, ListFiles, ListSubfolders"/>

            <GleamTech:FileManagerAccessControl Path="\7. File Type Restrictions\1. Only Image files (jpg, png, bmp, gif)" AllowedPermissions="Full" AllowedFileTypes="*.jpg|*.png|*.bmp|*.gif"/>

            <GleamTech:FileManagerAccessControl Path="\8. Quota Restrictions\1. Quota (1 MB)" AllowedPermissions="Full" Quota="1MB"/>
            <GleamTech:FileManagerAccessControl Path="\8. Quota Restrictions\2. Quota (15 MB)" AllowedPermissions="Full" Quota="15MB"/>
            <GleamTech:FileManagerAccessControl Path="\8. Quota Restrictions\2. Quota (15 MB)\Quota (1 MB)" AllowedPermissions="Full" Quota="1MB"/>
            <GleamTech:FileManagerAccessControl Path="\8. Quota Restrictions\2. Quota (15 MB)\Deep\Quota (1 MB)" AllowedPermissions="Full" Quota="1MB"/>
            <GleamTech:FileManagerAccessControl Path="\8. Quota Restrictions\3. Quota (Unlimited)" AllowedPermissions="Full" />
            <GleamTech:FileManagerAccessControl Path="\8. Quota Restrictions\3. Quota (Unlimited)\Quota (1 MB)" AllowedPermissions="Full" Quota="1MB"/>

        </GleamTech:FileManagerRootFolder>   
        

        <GleamTech:FileManagerRootFolder Name="3. Another Root Folder" Location="~/App_Data/RootFolder2" >
            <GleamTech:FileManagerAccessControl Path="\" 
                                                AllowedPermissions="ListSubfolders, ListFiles, Download, Upload"
                                                AllowedFileTypes="*.jpg|*.gif" 
                                                Quota="2 MB" />

            <GleamTech:FileManagerAccessControl Path="\Subfolder1" 
                                                AllowedPermissions="Full"
                                                DeniedPermissions="Download"
                                                DeniedFileTypes="*.exe" />
        </GleamTech:FileManagerRootFolder>         

    </GleamTech:FileManager>
    
</body>
</html>
