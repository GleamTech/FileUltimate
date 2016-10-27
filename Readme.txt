FileUltimate v5.6 - ASP.NET File Manager
Copyright © 2006-2016 GleamTech
http://www.gleamtech.com/fileultimate

------------------------------------------------------------------------------------------------------
Information on package contents:
------------------------------------------------------------------------------------------------------

  - "Bin" folder contains the DLLs for FileUltimate. The DLLs are targetted for .NET 4.0 and above.
    Please see below for the full instructions on how to reference and use the DLLs in your ASP.NET project.

  - "Examples" folder contains the example projects for ASP.NET Web Forms (C# and VB) and ASP.NET MVC (C# and VB). 
    Please open one of the solution files with Visual Studio 2015/2013/2012/2010 to load an example project. 
	The example projects demonstrate various features and settings of FileUltimate controls. Note that, 
	the projects reference GleamTech.FileUltimate.dll which is at "Bin" folder of the root of this package 
	so make sure you extract the whole package (not only "Examples" folder) before opening a solution.

  - "Resources" folder contains the copies of resource files such as the language files which are already embedded
    into GleamTech.FileUltimate.dll. You can use these copies to create a new translation or modify an existing translation.
    Please see below for more information on overriding resource files.
    
------------------------------------------------------------------------------------------------------
To use FileUltimate in an ASP.NET MVC Project, do the following in Visual Studio:
------------------------------------------------------------------------------------------------------

1.  Add references to FileUltimate assemblies. There are two ways to
    perform this:  

    -   Add reference to GleamTech.Core.dll and
        GleamTech.FileUltimate.dll found in "Bin" folder of
        FileUltimate-vX.X.X.X.zip package which you already downloaded
        and extracted.  

          The other DLLs in the same folder, i.e.
          GleamTech.ImageUltimate.dll, GleamTech.VideoUltimate.dll and
          GleamTech.DocumentUltimate.dll are assemblies that
          FileUltimate depends on for some of the features. They are
          separate assemblies as they are also standalone products with
          the same names. MSbuild or Visual Studio will automatically
          copy these 3 DLLs along with the main referenced assembly
          GleamTech.FileUltimate.dll to your bin folder during build so
          they don't need to be referenced directly (unless you are
          using these products separately in the same project and you
          have a license for them). Note that even without these 3 DLLs,
          FileUltimate will work but it will just turn off the
          corresponding features such as generating image or video
          thumbnails or the document viewer. So with this modular
          approach, you can opt-out of the features you do not need by
          excluding the corresponding DLL, i.e. MSBuild or Visual Studio
          would automatically copy a dependency only if that DLL is
          found in the same folder as the main referenced DLL so you can
          simply delete/move a DLL to opt-out.

    -   Or install NuGet package and add references automatically via
        NuGet Package Manager in Visual Studio: open Tools -> NuGet
        Package Manager -> Package Manager Console and run this command:

			Install-Package FileUltimate

		If you prefer using the user interface when working with NuGet, you
		can also install the package this way: open Tools -> NuGet Package
		Manager -> Manage NuGet Packages for Solution, enter FileUltimate in
		the search field, and click Install button on the found package.  

2.  Set FileUltimate's global configuration. For example, you may want
    to set the license key. Insert some of the following lines (if
    overriding a default value is required) into the Application_Start
    method of your Global.asax.cs:

    ~~~~
    //Set this property only if you have a valid license key, otherwise do not 
    //set it so FileUltimate runs in trial mode.  
    FileUltimateConfiguration.Current.LicenseKey = "QQJDJLJP34...";
    ~~~~

    Alternatively you can specify the configuration in \ tag of your
    Web.config.

    ~~~~
    <appSettings> 
      <add key="FileUltimate:LicenseKey" value="QQJDJLJP34..." /> 
    </appSettings>
    ~~~~

    As you would notice, FileUltimate: prefix maps to
    FileUltimateConfiguration.Current.  
      

3.  Open one of your View pages (eg. Index.cshtml) and at the top of
    your page add the necessary namespaces:

    ~~~~
    @using GleamTech.Web.Mvc
    @using GleamTech.FileUltimate
    ~~~~

    Alternatively you can add the namespaces globally in
    Views/web.config to avoid adding namespaces in your pages every
    time:

    ~~~~
      <system.web.webPages.razor>
        <pages pageBaseType="System.Web.Mvc.WebViewPage">
          <namespaces>
            .
            .
            .
            <add namespace="GleamTech.Web.Mvc" />
            <add namespace="GleamTech.FileUltimate" />
          </namespaces>
        </pages>
      </system.web.webPages.razor>
    ~~~~

    Now in your page insert these lines:

    ~~~~
    @{
        var fileManager = new FileManager
        {
            Width = 800,
            Height = 600,
            Resizable = true
        };

        var rootFolder = new FileManagerRootFolder
        {
            Name = "A Root Folder",
            Location = "~/App_Data/RootFolder1"
        };

        rootFolder.AccessControls.Add(new FileManagerAccessControl
        {
            Path = @"\",
            AllowedPermissions = FileManagerPermissions.Full
        });

        fileManager.RootFolders.Add(rootFolder);
    }
    <html>
    <head>
        @Html.RenderCss(fileManager)
        @Html.RenderJs(fileManager)
    </head>
    <body>
        @Html.RenderControl(fileManager)
    </body>
    </html>
    ~~~~

    This will render a file manager control in the page which displays
    one root folder named "A Root Folder" which points to
    "~/App_Data/RootFolder1" with Full permissions.

------------------------------------------------------------------------------------------------------
To use FileUltimate in an ASP.NET WebForms Project, do the following in Visual Studio:
------------------------------------------------------------------------------------------------------

1.  Add references to FileUltimate assemblies. There are two ways to
    perform this:  

    -   Add reference to GleamTech.Core.dll and
        GleamTech.FileUltimate.dll found in "Bin" folder of
        FileUltimate-vX.X.X.X.zip package which you already downloaded
        and extracted.  

          The other DLLs in the same folder, i.e.
          GleamTech.ImageUltimate.dll, GleamTech.VideoUltimate.dll and
          GleamTech.DocumentUltimate.dll are assemblies that
          FileUltimate depends on for some of the features. They are
          separate assemblies as they are also standalone products with
          the same names. MSbuild or Visual Studio will automatically
          copy these 3 DLLs along with the main referenced assembly
          GleamTech.FileUltimate.dll to your bin folder during build so
          they don't need to be referenced directly (unless you are
          using these products separately in the same project and you
          have a license for them). Note that even without these 3 DLLs,
          FileUltimate will work but it will just turn off the
          corresponding features such as generating image or video
          thumbnails or the document viewer. So with this modular
          approach, you can opt-out of the features you do not need by
          excluding the corresponding DLL, i.e. MSBuild or Visual Studio
          would automatically copy a dependency only if that DLL is
          found in the same folder as the main referenced DLL so you can
          simply delete/move a DLL to opt-out.

    -   Or install NuGet package and add references automatically via
        NuGet Package Manager in Visual Studio: open Tools -> NuGet
        Package Manager -> Package Manager Console and run this command:
           
			Install-Package FileUltimate

		If you prefer using the user interface when working with NuGet, you
		can also install the package this way: open Tools -> NuGet Package
		Manager -> Manage NuGet Packages for Solution, enter FileUltimate in
		the search field, and click Install button on the found package.  

2.  Set FileUltimate's global configuration. For example, you may want
    to set the license key. Insert some of the following lines (if
    overriding a default value is required) into the Application_Start
    method of your Global.asax.cs:

    ~~~~
    //Set this property only if you have a valid license key, otherwise do not 
    //set it so FileUltimate runs in trial mode.  
    FileUltimateConfiguration.Current.LicenseKey = "QQJDJLJP34...";
    ~~~~

    Alternatively you can specify the configuration in \ tag of your
    Web.config.

    ~~~~
    <appSettings> 
      <add key="FileUltimate:LicenseKey" value="QQJDJLJP34..." /> 
    </appSettings>
    ~~~~

    As you would notice, FileUltimate: prefix maps to
    FileUltimateConfiguration.Current.  
      

3.  Open one of your pages (eg. Default.aspx) and at the top of your
    page add add the necessary namespaces:

    ~~~~
    <%@ Register TagPrefix="GleamTech" Namespace="GleamTech.FileUltimate" Assembly="GleamTech.FileUltimate" %>
    ~~~~

    Alternatively you can add the namespaces globally in Web.config to
    avoid adding namespaces in your pages every time:

    ~~~~
      <system.web>
        <pages>
          <controls>
            .
            .
            .
            <add tagPrefix="GleamTech" namespace="GleamTech.FileUltimate" assembly="GleamTech.FileUltimate" />
          </controls>
        </pages>
      </system.web>
    ~~~~

    Now in your page insert these lines:

    ~~~~
    <GleamTech:FileManager ID="fileManager" runat="server" 
                            Width="800"
                            Height="600" 
                            Resizable="True">
        
        <GleamTech:FileManagerRootFolder Name="A Root Folder" Location="~/App_Data/RootFolder1" > 
            <GleamTech:FileManagerAccessControl Path="\" AllowedPermissions="Full"/> 
        </GleamTech:FileManagerRootFolder>

    </GleamTech:FileManager> 
    ~~~~

    This will render a file manager control in the page which displays
    one root folder named "A Root Folder" which points to
    "~/App_Data/RootFolder1" with Full permissions.

------------------------------------------------------------------------------------------------------
Optional:
------------------------------------------------------------------------------------------------------

FileUltimate does not depend on any Web.config settings to work (it's
config-free for easy deployment). However if you want to support the
lowest level upload method Html4 which is the only possible method for
old browsers without Html5 or Flash or Silverlight support, then you
will need to increase the request limits (ASP.NET's default is 4MB) so
that you can upload files larger than 4MB on these browsers.  
 Edit your project's Web.config file and add the following settings
inside \ tag:  

~~~~
  <!-- 
    Html4 upload method requires the limits to be set to the maximum value (2 GB).
    Other upload methods use chunking so there is no 2GB limit for them.
  -->
  <location path="fileuploader.ashx">
    <system.webServer>
      <security>
        <requestFiltering>
          <!-- 
            Maximum value for maxAllowedContentLength (in bytes) is 2147483648 (2GB). 
            maxAllowedContentLength should be always equal to (or greater than) maxRequestLength x 1024.
          -->
          <requestLimits maxAllowedContentLength="2147483648"/>
        </requestFiltering>
      </security>
    </system.webServer>
    <system.web>
      <!-- Maximum value for maxRequestLength (in kilobytes) is 2097152 (2GB) -->
      <httpRuntime maxRequestLength="2097152"/>
    </system.web>
  </location>
~~~~

------------------------------------------------------------------------------------------------------
Overriding resource files:
------------------------------------------------------------------------------------------------------

  "Resources" folder contains the copies of resource files such as the language files which are 
  already embedded into GleamTech.FileUltimate.dll. For example, you can use these files to create
  a new translation or modify an existing translation. You should copy the modified files to the 
  corresponding place under "Project\App_GlobalResources" to override an embedded resource. Please 
  only copy the required files and not the whole folder as future updates to GleamTech.FileUltimate.dll 
  may include newer versions of those files which may be necessary to run the latest version properly.
 
  New or modified files under "Project\App_GlobalResources" folder should trigger restarting of the ASP.NET 
  application. So, FileUltimate should automatically recognize the changes to the resource files under this 
  folder. If FileUltimate does not recognize the changes then you can touch (simply open & save) 
  "Project\Web.config" file to force FileUltimate to see the changes.

------------------------------------------------------------------------------------------------------
Translating to a new language:
------------------------------------------------------------------------------------------------------

  Please first see "Overriding resource files" above for information on where to find original language files.

  To override an existing embedded language or to add a newly translated language, create 
  "Project\App_GlobalResources\Languages" folder and put the modified language file or the newly 
  translated language file in this subfolder.

  Language files are simple XML files. To create a new language file, make a copy of "FileUltimate-en.xml"
  and rename it to a standard language name (refer to Culture Name column in this table: 
  https://msdn.microsoft.com/en-us/goglobal/bb896001.aspx). For instance, rename it to "FileUltimate-de.xml" 
  for German language. Edit the new xml file and translate each string element but do not modify the key 
  attributes. If a string includes a place holder {0}, do not forget to include it in the translated 
  string too. You can create language files also for specific cultures. For instance, you can create 
  "FileUltimate-de-CH.xml" for German in Switzerland. There is a fallback mechanism, FileUltimate will 
  first look for the language file "FileUltimate-de-CH.xml" and if the file is not found, it will load 
  the general language file of that culture which is "FileUltimate-de.xml".

  We will appreciate if you send us the language files you created so that we can bundle them in 
  future versions.