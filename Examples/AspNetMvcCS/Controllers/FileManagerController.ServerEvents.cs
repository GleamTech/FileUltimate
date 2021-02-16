using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using GleamTech.AspNet.UI;
using GleamTech.FileUltimate.AspNet.UI;

namespace GleamTech.FileUltimateExamples.AspNetMvcCS.Controllers
{
    public partial class FileManagerController
    {
        private const string EventLogSessionKey = "EventLog.CS";

        public ActionResult ServerEvents()
        {
            var fileManager = new FileManager
            {
                Width = 800,
                Height = 600,
                DisplayLanguage = "en"
            };
            fileManager.RootFolders.Add(new FileManagerRootFolder
            {
                Name = "Root Folder 1",
                Location = "~/App_Data/RootFolder1"
            });
            fileManager.RootFolders[0].AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\",
                AllowedPermissions = FileManagerPermissions.Full
            });

            //Attached event handlers should be static methods because they are raised out of the context of the host page.
            //If instance methods are attached (eg. an instance method of Page class), this would cause memory leaks. 

            //Before Events which are fired before the action is started.
            //Use e.Cancel("message") within a before event handler for canceling the event and displaying a message to the user, 
            //When an event is canceled, the corresponding action will be canceled and the after event will not be fired.
            fileManager.Expanding += FileManagerExpanding;
            fileManager.Listing += FileManagerListing;
            fileManager.Creating += FileManagerCreating;
            fileManager.Deleting += FileManagerDeleting;
            fileManager.Renaming += FileManagerRenaming;
            fileManager.Copying += FileManagerCopying;
            fileManager.Moving += FileManagerMoving;
            fileManager.Compressing += FileManagerCompressing;
            fileManager.Extracting += FileManagerExtracting;
            fileManager.Uploading += FileManagerUploading;
            fileManager.Downloading += FileManagerDownloading;
            fileManager.Previewing += FileManagerPreviewing;

            //After Events which are fired after the action is completed.
            fileManager.Expanded += FileManagerExpanded;
            fileManager.Listed += FileManagerListed;
            fileManager.Created += FileManagerCreated;
            fileManager.Deleted += FileManagerDeleted;
            fileManager.Renamed += FileManagerRenamed;
            fileManager.Copied += FileManagerCopied;
            fileManager.Moved += FileManagerMoved;
            fileManager.Compressed += FileManagerCompressed;
            fileManager.Extracted += FileManagerExtracted;
            fileManager.Uploaded += FileManagerUploaded;
            fileManager.Downloaded += FileManagerDownloaded;
            fileManager.Previewed += FileManagerPreviewed;
            fileManager.Failed += FileManagerFailed;

            return View(fileManager);
        }

        public ActionResult GetLatestEvents()
        {
            return Content(EventUtil.GetLatestEvents(), "text/html");
        }

        #region  Example event handlers for before events

        private static void FileManagerExpanding(object sender, FileManagerExpandingEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Expanding"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"IsRefresh", e.IsRefresh}
                });
        }

        private static void FileManagerListing(object sender, FileManagerListingEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Listing"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"IsRefresh", e.IsRefresh}
                });
        }

        private static void FileManagerCreating(object sender, FileManagerCreatingEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Creating"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemName", e.ItemName}
                });
        }

        private static void FileManagerDeleting(object sender, FileManagerDeletingEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Deleting"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemNames", e.ItemNames}
                });
        }

        private static void FileManagerRenaming(object sender, FileManagerRenamingEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Renaming"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemName", e.ItemName},
                    {"ItemNewName", e.ItemNewName}
                });
        }

        private static void FileManagerCopying(object sender, FileManagerCopyingEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Copying"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemNames", e.ItemNames},
                    {"TargetFolder.FullPath", e.TargetFolder.FullPath}
                });
        }

        private static void FileManagerMoving(object sender, FileManagerMovingEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Moving"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemNames", e.ItemNames},
                    {"TargetFolder.FullPath", e.TargetFolder.FullPath}
                });
        }

        private static void FileManagerCompressing(object sender, FileManagerCompressingEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Compressing"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemNames", e.ItemNames},
                    {"ZipFileName", e.ZipFileName}
                });
        }

        private static void FileManagerExtracting(object sender, FileManagerExtractingEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Extracting"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ToSubfolder", e.ToSubfolder},
                    {"ArchiveFileName", e.ArchiveFileName}
                });
        }

        private static void FileManagerUploading(object sender, FileManagerUploadingEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Uploading"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"Queue.Method", e.Queue.Method},
                    {"Items", e.Items.Select(item => new Dictionary<string, object>
                        {
                            {"Name", item.Name},
                            {"ContentType", item.ContentType},
                            {"SizeAsString", item.SizeAsString},
                            {"DateModified", item.DateModified }
                        })
                    }
                });
        }

        private static void FileManagerDownloading(object sender, FileManagerDownloadingEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Downloading"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemNames", e.ItemNames},
                    {"DownloadFileName", e.DownloadFileName},
                    {"OpenInBrowser", e.OpenInBrowser}
                });
        }

        private static void FileManagerPreviewing(object sender, FileManagerPreviewingEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Previewing"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemName", e.ItemName},
                    {"PreviewerType", e.PreviewerType}
                });
        }

        #endregion

        #region Example event handlers for after events

        private static void FileManagerExpanded(object sender, FileManagerExpandedEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Expanded"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"IsRefresh", e.IsRefresh}
                });
        }

        private static void FileManagerListed(object sender, FileManagerListedEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Listed"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"IsRefresh", e.IsRefresh}
                });
        }

        private static void FileManagerCreated(object sender, FileManagerCreatedEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Created"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemName", e.ItemName}
                });
        }

        private static void FileManagerDeleted(object sender, FileManagerDeletedEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Deleted"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemNames", e.ItemNames}
                });
        }

        private static void FileManagerRenamed(object sender, FileManagerRenamedEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Renamed"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemName", e.ItemName},
                    {"ItemNewName", e.ItemNewName}
                });
        }

        private static void FileManagerCopied(object sender, FileManagerCopiedEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Copied"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemNames", e.ItemNames},
                    {"TargetFolder.FullPath", e.TargetFolder.FullPath},
                    {"TargetItemNames", e.TargetItemNames}
                });
        }

        private static void FileManagerMoved(object sender, FileManagerMovedEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Moved"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemNames", e.ItemNames},
                    {"TargetFolder.FullPath", e.TargetFolder.FullPath},
                });
        }

        private static void FileManagerCompressed(object sender, FileManagerCompressedEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Compressed"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemNames", e.ItemNames},
                    {"ZipFileName", e.ZipFileName}
                });
        }

        private static void FileManagerExtracted(object sender, FileManagerExtractedEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Extracted"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ToSubfolder", e.ToSubfolder},
                    {"ArchiveFileName", e.ArchiveFileName}
                });
        }

        private static void FileManagerUploaded(object sender, FileManagerUploadedEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Uploaded"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"Queue.Method", e.Queue.Method},
                    {"Items", e.Items.Select(item => new Dictionary<string, object>
                        {
                            {"Name", item.Name},
                            {"ContentType", item.ContentType},
                            {"SizeAsString", item.SizeAsString},
                            {"DateModified", item.DateModified},
                            {"Status", item.Status},
                            {"StatusMessage", item.StatusMessage}
                        })
                    },
                    {"Queue.TotalUploadedSizeAsString", e.Queue.TotalUploadedSizeAsString},
                    {"Queue.ElapsedTimeAsString", e.Queue.ElapsedTimeAsString},
                    {"Queue.TransferRateAsString", e.Queue.TransferRateAsString}
                });
        }

        private static void FileManagerDownloaded(object sender, FileManagerDownloadedEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Downloaded"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemNames", e.ItemNames},
                    {"DownloadFileName", e.DownloadFileName},
                    {"OpenInBrowser", e.OpenInBrowser},
                    {"TotalDownloadedSizeAsString", e.TotalDownloadedSizeAsString},
                    {"ElapsedTimeAsString", e.ElapsedTimeAsString},
                    {"TransferRateAsString", e.TransferRateAsString}
                });
        }

        private static void FileManagerPreviewed(object sender, FileManagerPreviewedEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Previewed"},
                    {"Folder.FullPath", e.Folder.FullPath},
                    {"ItemName", e.ItemName},
                    {"PreviewerType", e.PreviewerType}
                });
        }

        private static void FileManagerFailed(object sender, FileManagerFailedEventArgs e)
        {
            EventUtil.SaveEventInfo(new Dictionary<string, object>
                {
                    {"Event Name", "Failed"},
                    {"FailedActionInfo.Name", e.FailedActionInfo.Name},
                    {"FailedActionInfo.Parameters", e.FailedActionInfo.Parameters},
                    {"Exception", e.Exception}
                });
        }

        #endregion

        private static class EventUtil
        {
            public static void SaveEventInfo(Dictionary<string, object> eventInfo)
            {
                var now = DateTime.Now.ToString("T");
                var json = ComponentStateManager.SerializeState(eventInfo, true);
                var formattedValue = "[" + now + "]" + "\nEvent arguments: " + json + "\n\n";

                Stack<string> eventLog;
                if (!ComponentStateManager.TryGetState(EventLogSessionKey, out eventLog))
                    eventLog = new Stack<string>();

                if (eventLog.Count > 50)
                    eventLog.Clear();

                eventLog.Push(formattedValue);
                ComponentStateManager.SaveState(EventLogSessionKey, eventLog);
            }

            public static string GetLatestEvents()
            {
                Stack<string> eventLog;
                if (!ComponentStateManager.TryGetState(EventLogSessionKey, out eventLog))
                    eventLog = new Stack<string>();

                var sb = new StringBuilder("<pre>");
                if (eventLog.Count == 0)
                    sb.AppendLine("No events.");
                else
                    while (eventLog.Count > 0)
                    {
                        sb.AppendLine(eventLog.Pop());
                    }
                sb.AppendLine("</pre>");

                return sb.ToString();
            }
        }
    }
}
