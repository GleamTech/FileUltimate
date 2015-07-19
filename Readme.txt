FileUltimate v4.7.1 - ASP.NET File Handling Controls
Copyright © 2006-2015 GleamTech
http://www.gleamtech.com

---------------------------------------------------
Information on package contents:
---------------------------------------------------

  - "Bin" folder contains GleamTech.FileUltimate.dll which is to be referenced in your project for running FileUltimate 
     controls. FileUltimate is targetted for ASP.NET 4.0 and supports medium-trust level (shared hosting).
     Please see below for the full instructions on how to reference and use this dll in your ASP.NET project.

  - "Examples" folder contains the example projects for ASP.NET Web Forms (C# and VB) and ASP.NET MVC (C# and VB). 
    Please open one of the solution files with Visual Studio 2013/2012/2010 to load an example project. 
	The example projects demonstrate various features and settings of FileUltimate controls. Note that, 
	the projects reference GleamTech.FileUltimate.dll which is at "Bin" folder of the root of this package 
	so make sure you extract the whole package (not only "Examples" folder) before opening a solution.

  - "Resources" folder contains the copies of resource files such as the language files which are already embedded
    into GleamTech.FileUltimate.dll. You can use these copies to create a new translation or modify an existing translation.
    Please see below for more information on overriding resource files.

---------------------------------------------------
Instructions for using the controls in your project (Web Forms):
---------------------------------------------------

  1. Open your existing project with Visual Studio 2013/2012/2010 and add reference to GleamTech.FileUltimate.dll 
     found in "Bin" folder.

  2. Add the tag registration at the top of an aspx page which will host the control:
    
     <%@ Register TagPrefix="GleamTech" Assembly="GleamTech.FileUltimate" Namespace="GleamTech.FileUltimate" %> 	

  3. You can now add the FileManager control to the host aspx page with this tag:

     <GleamTech:FileManager ID="fileManager" runat="server" />

     Optionally you can add GleamTech.FileUltimate.dll to the toolbox (via Choose Items option) and 
     automate steps 2 and 3 by dragging or double-clicking toolbar item "FileManager"

  4. Optional:  FileUltimate does not depend on any Web.config settings to work (it's config-free for easy deployment).
     However if you want to support the lowest level upload method Html4 which is the only possible method 
     for old browsers without Html5 or Flash or Silverlight support, then
     you will need to increase the request limits (ASP.NET's default is 4MB) so that you can upload
     files larger than 4MB on these browsers.
     Edit your project's Web.config file and add the following settings inside <configuration> tag:

    <!-- 
      Html4 upload method requires the limits to be set to the maximum value (2 GB).
      Other upload methods use chunking so there is no 2GB limit for them.
    -->
    <location path="fileuploader.ashx">
      <system.webServer>
        <security>
          <requestFiltering>
            <!-- 
              Maximum value for maxAllowedContentLength (in bytes) is 2147483648 (2GB). 
              maxAllowedContentLength should be always equal to (or greater than) maxRequestLength x 1024.
            -->
            <requestLimits maxAllowedContentLength="2147483648"/>
          </requestFiltering>
        </security>
      </system.webServer>
      <system.web>
        <!-- Maximum value for maxRequestLength (in kilobytes) is 2097152 (2GB) -->
        <httpRuntime maxRequestLength="2097152"/>
      </system.web>
    </location>

---------------------------------------------------
Overriding resource files:
---------------------------------------------------

  Please only copy the required files and not the whole folder as future updates to GleamTech.FileUltimate.dll may include 
  newer versions of those files which may be necessary to run the latest version properly.

  To override an existing embedded language or to add a newly translated language, 
  create "App_GlobalResources\Languages" subfolder under your project's root folder and 
  put the modified language file or the newly translated language file in this subfolder.

  New or modified files under App_GlobalResources folder should trigger restarting of the ASP.NET application.
  So, FileUltimate should automatically recognize the changes to the resource files under this folder.
  If FileUltimate does not recognize the changes then you can touch (simply open & save) your project's
  Web.config file to force the control to see the changes.
