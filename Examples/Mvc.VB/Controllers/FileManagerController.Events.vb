Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions
Imports GleamTech.FileUltimate

Namespace Controllers
    Partial Public Class FileManagerController

        Private Const EventLogSessionKey As String = "EventLog.VB"

        Public Function Events() As ActionResult
            Dim fileManager = New FileManager() With {
             .Width = 800,
             .Height = 600,
             .DisplayLanguage = "en"
            }
            fileManager.RootFolders.Add(New FileManagerRootFolder() With {
             .Name = "Root Folder 1",
             .Location = "~/App_Data/RootFolder1"
            })
            fileManager.RootFolders(0).AccessControls.Add(New FileManagerAccessControl() With {
             .Path = "\",
             .AllowedPermissions = FileManagerPermissions.Full
            })

            'Attached event handlers should be shared methods because they are raised out of the context of the host page.
            'If instance methods are attached (eg. an instance method of Page class), this would cause memory leaks. 

            'Before Events which are fired before the action is started.
            'Use e.Cancel("message") within a before event handler for canceling the event and displaying a message to the user, 
            'When an event is canceled, the corresponding action will be canceled and the after event will not be fired.
            AddHandler fileManager.Expanding, AddressOf FileManagerExpanding
            AddHandler fileManager.Listing, AddressOf FileManagerListing
            AddHandler fileManager.Creating, AddressOf FileManagerCreating
            AddHandler fileManager.Deleting, AddressOf FileManagerDeleting
            AddHandler fileManager.Renaming, AddressOf FileManagerRenaming
            AddHandler fileManager.Copying, AddressOf FileManagerCopying
            AddHandler fileManager.Moving, AddressOf FileManagerMoving
            AddHandler fileManager.Compressing, AddressOf FileManagerCompressing
            AddHandler fileManager.Extracting, AddressOf FileManagerExtracting
            AddHandler fileManager.Uploading, AddressOf FileManagerUploading
            AddHandler fileManager.Downloading, AddressOf FileManagerDownloading
            AddHandler fileManager.Previewing, AddressOf FileManagerPreviewing

            'After Events which are fired after the action is completed.
            AddHandler fileManager.Expanded, AddressOf FileManagerExpanded
            AddHandler fileManager.Listed, AddressOf FileManagerListed
            AddHandler fileManager.Created, AddressOf FileManagerCreated
            AddHandler fileManager.Deleted, AddressOf FileManagerDeleted
            AddHandler fileManager.Renamed, AddressOf FileManagerRenamed
            AddHandler fileManager.Copied, AddressOf FileManagerCopied
            AddHandler fileManager.Moved, AddressOf FileManagerMoved
            AddHandler fileManager.Compressed, AddressOf FileManagerCompressed
            AddHandler fileManager.Extracted, AddressOf FileManagerExtracted
            AddHandler fileManager.Uploaded, AddressOf FileManagerUploaded
            AddHandler fileManager.Downloaded, AddressOf FileManagerDownloaded
            AddHandler fileManager.Previewed, AddressOf FileManagerPreviewed
            AddHandler fileManager.Failed, AddressOf FileManagerFailed

            Return View(fileManager)
        End Function

        Public Function GetLatestEvents() As ActionResult
            Dim sb = New StringBuilder("<pre>")

            Dim eventLog = TryCast(Session(EventLogSessionKey), Stack(Of String))
            If eventLog Is Nothing OrElse eventLog.Count = 0 Then
                sb.AppendLine("No events.")
            Else
                While eventLog.Count > 0
                    sb.AppendLine("Event " + Convert.ToString(eventLog.Count) + " - " + DateTime.Now.ToString("T"))
                    sb.AppendLine(New [String]("-"c, 80))
                    sb.AppendLine(eventLog.Pop())
                End While
            End If

            sb.AppendLine("</pre>")

            Return Content(sb.ToString())
        End Function

#Region "Example event handlers for before events"

        Private Shared Sub FileManagerExpanding(sender As Object, e As FileManagerExpandingEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Expanding"},
                {"Path", e.Folder.FullPath},
                {"Is Refresh", e.IsRefresh}
            })
        End Sub

        Private Shared Sub FileManagerListing(sender As Object, e As FileManagerListingEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Listing"},
                {"Path", e.Folder.FullPath},
                {"Is Refresh", e.IsRefresh}
            })
        End Sub

        Private Shared Sub FileManagerCreating(sender As Object, e As FileManagerCreatingEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Creating"},
                {"Path", e.Folder.FullPath},
                {"Creating Folder", e.ItemName}
            })
        End Sub

        Private Shared Sub FileManagerDeleting(sender As Object, e As FileManagerDeletingEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Deleting"},
                {"Path", e.Folder.FullPath},
                {"Deleting Items", e.ItemNames}
            })
        End Sub

        Private Shared Sub FileManagerRenaming(sender As Object, e As FileManagerRenamingEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Renaming"},
                {"Path", e.Folder.FullPath},
                {"Item Old Name", e.ItemName},
                {"Item New Name", e.ItemNewName}
            })
        End Sub

        Private Shared Sub FileManagerCopying(sender As Object, e As FileManagerCopyingEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Copying"},
                {"From Path", e.Folder.FullPath},
                {"Copying Items", e.ItemNames},
                {"To Path", e.TargetFolder.FullPath}
            })
        End Sub

        Private Shared Sub FileManagerMoving(sender As Object, e As FileManagerMovingEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Moving"},
                {"From Path", e.Folder.FullPath},
                {"Moving Items", e.ItemNames},
                {"To Target Path", e.TargetFolder.FullPath}
            })
        End Sub

        Private Shared Sub FileManagerCompressing(sender As Object, e As FileManagerCompressingEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Compressing"},
                {"Path", e.Folder.FullPath},
                {"Compressing Items", e.ItemNames},
                {"Zip File", e.ZipFileName}
            })
        End Sub

        Private Shared Sub FileManagerExtracting(sender As Object, e As FileManagerExtractingEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Extracting"},
                {"Path", e.Folder.FullPath},
                {"Extracting to Subfolder", e.ToSubfolder},
                {"Archive File", e.ArchiveFileName}
            })
        End Sub

        Private Shared Sub FileManagerUploading(sender As Object, e As FileManagerUploadingEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Uploading"},
                {"Path", e.Folder.FullPath},
                {"Upload Method", e.Method},
                {"Uploading Files", e.Validations.[Select](Function(validation) New Dictionary(Of String, Object)() From {
                    {"Name", validation.Name},
                    {"Content Type", validation.ContentType},
                    {"Size", If(validation.Size.HasValue, New ByteSizeValue(validation.Size.Value).ToFileSize().ToString(), "<unknown>")}
                })}
            })
        End Sub

        Private Shared Sub FileManagerDownloading(sender As Object, e As FileManagerDownloadingEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Downloading"},
                {"Path", e.Folder.FullPath},
                {"Downloading Items", e.ItemNames},
                {"Downloading File Name", e.DownloadFileName},
                {"Opening in browser", e.OpenInBrowser}
            })
        End Sub

        Private Shared Sub FileManagerPreviewing(sender As Object, e As FileManagerPreviewingEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Previewing"},
                {"Path", e.Folder.FullPath},
                {"Previewing File", e.ItemName},
                {"Previewer", e.PreviewerType}
            })
        End Sub

#End Region

#Region "Example event handlers for after events"

        Private Shared Sub FileManagerExpanded(sender As Object, e As FileManagerExpandedEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Expanded"},
                {"Path", e.Folder.FullPath},
                {"Is Refresh", e.IsRefresh}
            })
        End Sub

        Private Shared Sub FileManagerListed(sender As Object, e As FileManagerListedEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Listed"},
                {"Path", e.Folder.FullPath},
                {"Is Refresh", e.IsRefresh}
            })
        End Sub

        Private Shared Sub FileManagerCreated(sender As Object, e As FileManagerCreatedEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Created"},
                {"Path", e.Folder.FullPath},
                {"Created Folder", e.ItemName}
            })
        End Sub

        Private Shared Sub FileManagerDeleted(sender As Object, e As FileManagerDeletedEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Deleted"},
                {"Path", e.Folder.FullPath},
                {"Deleted Items", e.ItemNames}
            })
        End Sub

        Private Shared Sub FileManagerRenamed(sender As Object, e As FileManagerRenamedEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Renamed"},
                {"Path", e.Folder.FullPath},
                {"Item Old Name", e.ItemName},
                {"Item New Name", e.ItemNewName}
            })
        End Sub

        Private Shared Sub FileManagerCopied(sender As Object, e As FileManagerCopiedEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Copied"},
                {"From Path", e.Folder.FullPath},
                {"Source Items", e.ItemNames},
                {"To Path", e.TargetFolder.FullPath},
                {"Copied Items", e.TargetItemNames}
            })
        End Sub

        Private Shared Sub FileManagerMoved(sender As Object, e As FileManagerMovedEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Moved"},
                {"From Path", e.Folder.FullPath},
                {"Moved Items", e.ItemNames},
                {"To Path", e.TargetFolder.FullPath}
            })
        End Sub

        Private Shared Sub FileManagerCompressed(sender As Object, e As FileManagerCompressedEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Compressed"},
                {"Path", e.Folder.FullPath},
                {"Compressed Items", e.ItemNames},
                {"Zip File", e.ZipFileName}
            })
        End Sub

        Private Shared Sub FileManagerExtracted(sender As Object, e As FileManagerExtractedEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Extracted"},
                {"Path", e.Folder.FullPath},
                {"Extracted to Subfolder", e.ToSubfolder},
                {"Archive File", e.ArchiveFileName}
            })
        End Sub

        Private Shared Sub FileManagerUploaded(sender As Object, e As FileManagerUploadedEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Uploaded"},
                {"Path", e.Folder.FullPath},
                {"Upload Method", e.Method},
                {"Uploaded Files", e.Items.[Select](Function(item) New Dictionary(Of String, Object)() From {
                    {"Name", If((item.Status = UploadItemStatus.Completed), item.ReceivedName, item.ReceivingName)},
                    {"Content Type", If((item.Status = UploadItemStatus.Completed), item.ReceivedContentType, item.ReceivingContentType)},
                    {"Size", New ByteSizeValue(If((item.Status = UploadItemStatus.Completed), item.ReceivedSize, item.ReceivingSize)).ToFileSize()},
                    {"Status", item.Status},
                    {"Status Message", If((Not String.IsNullOrEmpty(item.StatusMessage)), Regex.Replace(item.StatusMessage, "\n+", vbLf & vbTab & vbTab), "<none>")}
                })},
                {"Total Size", New ByteSizeValue(e.TotalSize).ToFileSize()},
                {"Elapsed Time", e.ElapsedTime},
                {"Transfer Rate", e.TransferRate}
            })
        End Sub

        Private Shared Sub FileManagerDownloaded(sender As Object, e As FileManagerDownloadedEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Downloaded"},
                {"Path", e.Folder.FullPath},
                {"Downloaded Items", e.ItemNames},
                {"Downloaded File Name", e.DownloadFileName},
                {"Opened in browser", e.OpenInBrowser},
                {"Total Size", New ByteSizeValue(e.TotalSize).ToFileSize()},
                {"Elapsed Time", e.ElapsedTime},
                {"Transfer Rate", e.TransferRate}
            })
        End Sub

        Private Shared Sub FileManagerPreviewed(sender As Object, e As FileManagerPreviewedEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Previewed"},
                {"Path", e.Folder.FullPath},
                {"Previewed File", e.ItemName},
                {"Previewer", e.PreviewerType}
            })
        End Sub

        Private Shared Sub FileManagerFailed(sender As Object, e As FileManagerFailedEventArgs)
            SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Type", "Failed"},
                {"Failed Action", e.FailedActionInfo.Name},
                {"Parameters", e.FailedActionInfo.Parameters},
                {"Error", e.Exception.ToString().Replace(vbLf, vbLf & vbTab)}
            })
        End Sub

#End Region

        Private Shared Sub SaveEventInfo(eventInfo As Dictionary(Of String, Object))
            Dim resultText = New StringBuilder()
            For Each kvp In eventInfo
                resultText.Append(kvp.Key)
                resultText.Append(": " & vbLf)

                Dim enumerable = TryCast(kvp.Value, IEnumerable)
                If TypeOf enumerable Is String Then
                    enumerable = Nothing
                End If
                If enumerable IsNot Nothing Then
                    For Each item In enumerable
                        Dim subDictionary = TryCast(item, Dictionary(Of String, Object))
                        If subDictionary IsNot Nothing Then
                            For Each subKvp In subDictionary
                                resultText.Append(vbTab)
                                resultText.Append(subKvp.Key)
                                resultText.Append(": ")
                                resultText.Append(subKvp.Value)
                                resultText.Append(vbLf)
                            Next
                        Else
                            resultText.Append(vbTab)
                            resultText.Append(item)
                        End If
                        resultText.Append(vbLf)
                    Next
                Else
                    resultText.Append(vbTab)
                    resultText.Append(kvp.Value)
                    resultText.Append(vbLf)
                End If
            Next

            Dim context = System.Web.HttpContext.Current
            Dim eventLog = TryCast(context.Session(EventLogSessionKey), Stack(Of String))
            If eventLog Is Nothing Then
                eventLog = New Stack(Of String)()
                context.Session(EventLogSessionKey) = eventLog
            End If
            If eventLog.Count > 50 Then
                eventLog.Clear()
            End If

            eventLog.Push(resultText.ToString())
        End Sub

    End Class
End Namespace
