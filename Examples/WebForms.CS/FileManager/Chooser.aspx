<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Chooser.aspx.cs" Inherits="GleamTech.FileUltimateExamples.WebForms.CS.FileManager.ChooserPage" %>
<%@ Register TagPrefix="GleamTech" Assembly="GleamTech.FileUltimate" Namespace="GleamTech.FileUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <script>
        function fileManagerChosen(sender, eventArgs) {
            if (eventArgs.IsCanceled) {
                alert("Canceled!");
                return;
            }

            var text = "ParentFullPath: " + eventArgs.ParentFullPath;
            text += "\nItems: ";
            for (var i = 0; i < eventArgs.Items.length; i++) {
                var item = eventArgs.Items[i];
                text += "\n\tName: " + item.Name;
                text += "\n\tFullPath: " + item.FullPath;
                text += "\n\tIsfolder: " + item.IsFolder;
                text += "\n";
            }

            alert(text);
        }
    </script>
</head>
<body style="margin: 20px;">
    
    1. Chooser with single file selection:
    <input type="button" value="Choose..." onclick="fileManager1.show()" />
    <br /><br />
    <GleamTech:FileManager ID="fileManager1" runat="server" 
                           Width="800"
                           Height="400"
                           Resizable="True"
                           DisplayLanguage="en"
                           ShowOnLoad="False"
                           CollapseRibbon="True"
                           ModalDialog="True"
                           ModalDialogTitle="Choose a file"
                           ClientChosen="fileManagerChosen"
                           Chooser="True">
        <GleamTech:FileManagerRootFolder Name="Root Folder 1" Location="~/App_Data/RootFolder1" >
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
        </GleamTech:FileManagerRootFolder>       
    </GleamTech:FileManager>
    
    2. Chooser with single folder selection:
    <input type="button" value="Choose..." onclick="fileManager2.show()" />
    <br /><br />
    <GleamTech:FileManager ID="fileManager2" runat="server" 
                           Width="800"
                           Height="400"
                           Resizable="True"
                           DisplayLanguage="en"
                           ShowOnLoad="False"
                           CollapseRibbon="True"
                           ModalDialog="True"
                           ModalDialogTitle="Choose a folder"
                           ClientChosen="fileManagerChosen"
                           Chooser="True"
                           ChooserType="Folder">
        <GleamTech:FileManagerRootFolder Name="Root Folder 1" Location="~/App_Data/RootFolder1" >
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
        </GleamTech:FileManagerRootFolder>       
    </GleamTech:FileManager>
    
    3. Chooser with single file or folder selection:
    <input type="button" value="Choose..." onclick="fileManager3.show()" />
    <br /><br />
    <GleamTech:FileManager ID="fileManager3" runat="server" 
                           Width="800"
                           Height="400"
                           Resizable="True"
                           DisplayLanguage="en"
                           ShowOnLoad="False"
                           CollapseRibbon="True"
                           ModalDialog="True"
                           ModalDialogTitle="Choose a file or a folder"
                           ClientChosen="fileManagerChosen"
                           Chooser="True"
                           ChooserType="FileOrFolder">
        <GleamTech:FileManagerRootFolder Name="Root Folder 1" Location="~/App_Data/RootFolder1" >
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
        </GleamTech:FileManagerRootFolder>       
    </GleamTech:FileManager>
    
    4. Chooser with multiple file selections:
    <input type="button" value="Choose..." onclick="fileManager4.show()" />
    <br /><br />
    <GleamTech:FileManager ID="fileManager4" runat="server" 
                           Width="800"
                           Height="400"
                           Resizable="True"
                           DisplayLanguage="en"
                           ShowOnLoad="False"
                           CollapseRibbon="True"
                           ModalDialog="True"
                           ModalDialogTitle="Choose files"
                           ClientChosen="fileManagerChosen"
                           Chooser="True"
                           ChooserMultipleSelection="True">
        <GleamTech:FileManagerRootFolder Name="Root Folder 1" Location="~/App_Data/RootFolder1" >
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
        </GleamTech:FileManagerRootFolder>       
    </GleamTech:FileManager>
    
    5. Chooser with multiple folder selections:
    <input type="button" value="Choose..." onclick="fileManager5.show()" />
    <br /><br />
    <GleamTech:FileManager ID="fileManager5" runat="server" 
                           Width="800"
                           Height="400"
                           Resizable="True"
                           DisplayLanguage="en"
                           ShowOnLoad="False"
                           CollapseRibbon="True"
                           ModalDialog="True"
                           ModalDialogTitle="Choose folders"
                           ClientChosen="fileManagerChosen"
                           Chooser="True"
                           ChooserType="Folder"
                           ChooserMultipleSelection="True">
        <GleamTech:FileManagerRootFolder Name="Root Folder 1" Location="~/App_Data/RootFolder1" >
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
        </GleamTech:FileManagerRootFolder>       
    </GleamTech:FileManager>
    
    6. Chooser with multiple file or folder selections:
    <input type="button" value="Choose..." onclick="fileManager6.show()" />
    <br /><br />
    <GleamTech:FileManager ID="fileManager6" runat="server" 
                           Width="800"
                           Height="400"
                           Resizable="True"
                           DisplayLanguage="en"
                           ShowOnLoad="False"
                           CollapseRibbon="True"
                           ModalDialog="True"
                           ModalDialogTitle="Choose files or folders"
                           ClientChosen="fileManagerChosen"
                           Chooser="True"
                           ChooserType="FileOrFolder"
                           ChooserMultipleSelection="True">
        <GleamTech:FileManagerRootFolder Name="Root Folder 1" Location="~/App_Data/RootFolder1" >
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
        </GleamTech:FileManagerRootFolder>       
    </GleamTech:FileManager>
    
    7. Chooser displayed as inline element (also hide ribbon completely):
    <input type="button" value="Choose..." onclick="fileManager7.show()" />
    <br /><br />
    <GleamTech:FileManager ID="fileManager7" runat="server" 
                           Width="800"
                           Height="400"
                           Resizable="True"
                           DisplayLanguage="en"
                           ShowOnLoad="False"
                           ShowRibbon ="False"
                           ClientChosen="fileManagerChosen"
                           Chooser="True">
        <GleamTech:FileManagerRootFolder Name="Root Folder 1" Location="~/App_Data/RootFolder1" >
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/>
        </GleamTech:FileManagerRootFolder>       
    </GleamTech:FileManager>

</body>
</html>
