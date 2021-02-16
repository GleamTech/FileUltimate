Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports GleamTech.AspNet.UI
Imports GleamTech.FileUltimate.AspNet.UI

Namespace Controllers
    Partial Public Class FileManagerController

        Private Const EventLogSessionKey As String = "EventLog.VB"

        Public Function ServerEvents() As ActionResult
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
            Return Content(EventUtil.GetLatestEvents(), "text/html")
        End Function

#Region "Example event handlers for before events"

        Private Shared Sub FileManagerExpanding(sender As Object, e As FileManagerExpandingEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Expanding"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"IsRefresh", e.IsRefresh}
            })
        End Sub

        Private Shared Sub FileManagerListing(sender As Object, e As FileManagerListingEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Listing"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"IsRefresh", e.IsRefresh}
            })
        End Sub

        Private Shared Sub FileManagerCreating(sender As Object, e As FileManagerCreatingEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Creating"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemName", e.ItemName}
            })
        End Sub

        Private Shared Sub FileManagerDeleting(sender As Object, e As FileManagerDeletingEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Deleting"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemNames", e.ItemNames}
            })
        End Sub

        Private Shared Sub FileManagerRenaming(sender As Object, e As FileManagerRenamingEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Renaming"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemName", e.ItemName},
                {"ItemNewName", e.ItemNewName}
            })
        End Sub

        Private Shared Sub FileManagerCopying(sender As Object, e As FileManagerCopyingEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Copying"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemNames", e.ItemNames},
                {"TargetFolder.FullPath", e.TargetFolder.FullPath}
            })
        End Sub

        Private Shared Sub FileManagerMoving(sender As Object, e As FileManagerMovingEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Moving"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemNames", e.ItemNames},
                {"TargetFolder.FullPath", e.TargetFolder.FullPath}
            })
        End Sub

        Private Shared Sub FileManagerCompressing(sender As Object, e As FileManagerCompressingEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Compressing"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemNames", e.ItemNames},
                {"ZipFileName", e.ZipFileName}
            })
        End Sub

        Private Shared Sub FileManagerExtracting(sender As Object, e As FileManagerExtractingEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Extracting"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ToSubfolder", e.ToSubfolder},
                {"ArchiveFileName", e.ArchiveFileName}
            })
        End Sub

        Private Shared Sub FileManagerUploading(sender As Object, e As FileManagerUploadingEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Uploading"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"Queue.Method", e.Queue.Method},
                {"Items", e.Items.Select(Function(item) New Dictionary(Of String, Object)() From {
                    {"Name", item.Name},
                    {"ContentType", item.ContentType},
                    {"SizeAsString", item.SizeAsString},
                    {"DateModified", item.DateModified}
                })}
            })
        End Sub

        Private Shared Sub FileManagerDownloading(sender As Object, e As FileManagerDownloadingEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Downloading"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemNames", e.ItemNames},
                {"DownloadFileName", e.DownloadFileName},
                {"OpenInBrowser", e.OpenInBrowser}
            })
        End Sub

        Private Shared Sub FileManagerPreviewing(sender As Object, e As FileManagerPreviewingEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Previewing"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemName", e.ItemName},
                {"PreviewerType", e.PreviewerType}
            })
        End Sub

#End Region

#Region "Example event handlers for after events"

        Private Shared Sub FileManagerExpanded(sender As Object, e As FileManagerExpandedEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Expanded"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"IsRefresh", e.IsRefresh}
            })
        End Sub

        Private Shared Sub FileManagerListed(sender As Object, e As FileManagerListedEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Listed"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"IsRefresh", e.IsRefresh}
            })
        End Sub

        Private Shared Sub FileManagerCreated(sender As Object, e As FileManagerCreatedEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Created"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemName", e.ItemName}
            })
        End Sub

        Private Shared Sub FileManagerDeleted(sender As Object, e As FileManagerDeletedEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Deleted"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemNames", e.ItemNames}
            })
        End Sub

        Private Shared Sub FileManagerRenamed(sender As Object, e As FileManagerRenamedEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Renamed"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemName", e.ItemName},
                {"ItemNewName", e.ItemNewName}
            })
        End Sub

        Private Shared Sub FileManagerCopied(sender As Object, e As FileManagerCopiedEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Copied"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemNames", e.ItemNames},
                {"TargetFolder.FullPath", e.TargetFolder.FullPath},
                {"TargetItemNames", e.TargetItemNames}
            })
        End Sub

        Private Shared Sub FileManagerMoved(sender As Object, e As FileManagerMovedEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Moved"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemNames", e.ItemNames},
                {"TargetFolder.FullPath", e.TargetFolder.FullPath}
            })
        End Sub

        Private Shared Sub FileManagerCompressed(sender As Object, e As FileManagerCompressedEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Compressed"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemNames", e.ItemNames},
                {"ZipFileName", e.ZipFileName}
            })
        End Sub

        Private Shared Sub FileManagerExtracted(sender As Object, e As FileManagerExtractedEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Extracted"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ToSubfolder", e.ToSubfolder},
                {"ArchiveFileName", e.ArchiveFileName}
            })
        End Sub

        Private Shared Sub FileManagerUploaded(sender As Object, e As FileManagerUploadedEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Uploaded"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"Queue.Method", e.Queue.Method},
                {"Items", e.Items.[Select](Function(item) New Dictionary(Of String, Object)() From {
                    {"Name", item.Name},
                    {"ContentType", item.ContentType},
                    {"SizeAsString", item.SizeAsString},
                    {"DateModified", item.DateModified},
                    {"Status", item.Status},
                    {"StatusMessage", item.StatusMessage}
                })},
                {"Queue.TotalUploadedSizeAsString", e.Queue.TotalUploadedSizeAsString},
                {"Queue.ElapsedTimeAsString", e.Queue.ElapsedTimeAsString},
                {"Queue.TransferRateAsString", e.Queue.TransferRateAsString}
            })
        End Sub

        Private Shared Sub FileManagerDownloaded(sender As Object, e As FileManagerDownloadedEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Downloaded"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemNames", e.ItemNames},
                {"DownloadFileName", e.DownloadFileName},
                {"OpenInBrowser", e.OpenInBrowser},
                {"TotalDownloadedSizeAsString", e.TotalDownloadedSizeAsString},
                {"ElapsedTimeAsString", e.ElapsedTimeAsString},
                {"TransferRateAsString", e.TransferRateAsString}
            })
        End Sub

        Private Shared Sub FileManagerPreviewed(sender As Object, e As FileManagerPreviewedEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Previewed"},
                {"Folder.FullPath", e.Folder.FullPath},
                {"ItemName", e.ItemName},
                {"PreviewerType", e.PreviewerType}
            })
        End Sub

        Private Shared Sub FileManagerFailed(sender As Object, e As FileManagerFailedEventArgs)
            EventUtil.SaveEventInfo(New Dictionary(Of String, Object)() From {
                {"Event Name", "Failed"},
                {"FailedActionInfo.Name", e.FailedActionInfo.Name},
                {"FailedActionInfo.Parameters", e.FailedActionInfo.Parameters},
                {"Exception", e.Exception}
            })
        End Sub

#End Region

        Private Class EventUtil
            Public Shared Sub SaveEventInfo(eventInfo As Dictionary(Of String, Object))
                Dim now = DateTime.Now.ToString("T")
                Dim json = ComponentStateManager.SerializeState(eventInfo, True)
                Dim formattedValue = "[" + now + "]" + vbLf & "Event arguments: " + json + vbLf & vbLf

                Dim eventLog As Stack(Of String) = Nothing
                If Not ComponentStateManager.TryGetState(EventLogSessionKey, eventLog) Then
                    eventLog = New Stack(Of String)()
                End If

                If eventLog.Count > 50 Then
                    eventLog.Clear()
                End If

                eventLog.Push(formattedValue)
                ComponentStateManager.SaveState(EventLogSessionKey, eventLog)
            End Sub

            Public Shared Function GetLatestEvents() As String
                Dim eventLog As Stack(Of String) = Nothing
                If Not ComponentStateManager.TryGetState(EventLogSessionKey, eventLog) Then
                    eventLog = New Stack(Of String)()
                End If

                Dim sb As New StringBuilder("<pre>")
                If eventLog.Count = 0 Then
                    sb.AppendLine("No events.")
                Else
                    While eventLog.Count > 0
                        sb.AppendLine(eventLog.Pop())
                    End While
                End If
                sb.AppendLine("</pre>")

                Return sb.ToString()
            End Function
        End Class
    End Class
End Namespace
