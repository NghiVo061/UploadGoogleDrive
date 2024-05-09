using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace UploadGoogleDrive
{
    public class GoogleDriveApi
    {
        static string crePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Templates), "GPM", "GoogleApi", "GoogleDrive");
        static FileDataStore _fileDataStore = new FileDataStore(crePath, true);
        private DriveService _service;

        public string LocalUserName { set; get; }
        string _clientId, _clientSecret, _appName = "GPM.Apis.GoogleApi.Drive";

        public GoogleDriveApi(string clientid, string clientsecret, string localuser) : this(clientid, clientsecret)
        {
            this.LocalUserName = localuser;
        }

        public GoogleDriveApi(string clientid, string clientsecret)
        {
            this._clientId = clientid;
            this._clientSecret = clientsecret;
        }

        public async Task LoginAsync()
        {
            _fileDataStore = new FileDataStore(crePath, true);
            var app = new ClientSecrets() { ClientId = this._clientId, ClientSecret = this._clientSecret };
            var scopes = new[] { DriveService.Scope.Drive,
                                 DriveService.Scope.DriveFile,
                                 DriveService.Scope.DriveAppdata,
                                 DriveService.Scope.DriveReadonly};

            UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                app,
                scopes,
                this.LocalUserName,
                System.Threading.CancellationToken.None,
                _fileDataStore);

            _service = new DriveService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = _appName
            });
        }

        public static bool CheckLogin(string localusername)
        {
            string fileSave = string.Format("{0}\\{1}", _fileDataStore.FolderPath, "Google.Apis.Auth.OAuth2.Responses.TokenResponse-" + localusername);
            return System.IO.File.Exists(fileSave);
        }

        public async Task<string> CreateFolderIfNotExistAync(string folderName)
        {
            var timKiemFolder_request = _service.Files.List();
            timKiemFolder_request.Q = $"mimeType='application/vnd.google-apps.folder' and name='{folderName}' and trashed=false";
            var timKiemFolder_response = await timKiemFolder_request.ExecuteAsync();
            if (timKiemFolder_response.Files.Count >= 1)
                return timKiemFolder_response.Files[0].Id;

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder"
            };

            var request = _service.Files.Create(fileMetadata);

            request.Fields = "id";
            var file = await request.ExecuteAsync();
            return file.Id;
        }

        public async Task<string> UploadFileAsync(string filepath,
                           CancellationToken cancel_token,
                           string folderid = null,
                           Action<double> callback_progressuploadchanged = null,
                           string filename = null,
                           string mimetype = "video/audio/image/jpeg",
                           bool shareanyonewithlink = false)
        {
            FileInfo fInfo = new FileInfo(filepath);
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = filename == null ? fInfo.Name : filename,
                Description = "Upload by tool DRADYO",
                Parents = folderid != null ? new List<string> { folderid } : null
            };

            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                var requestUpload = _service.Files.Create(fileMetadata, fs, mimetype);

                if (callback_progressuploadchanged != null)
                    requestUpload.ProgressChanged += (u) => callback_progressuploadchanged((double)u.BytesSent / fs.Length);

                var upload_response = await requestUpload.UploadAsync(cancel_token);

                if (upload_response.Exception != null)
                {
                    throw upload_response.Exception;
                }

                if (requestUpload.ResponseBody == null)
                    throw new Exception("Upload fail");
                else
                {
                    if (shareanyonewithlink)
                    {
                        string linkShare = await ShareAnyoneWithLinkAsync(_service, requestUpload.ResponseBody.Id);
                    }

                    return requestUpload.ResponseBody.Id;
                }
            }
        }


        private async Task<string> ShareAnyoneWithLinkAsync(DriveService service, string fileid)
        {
            Permission permision = new Permission()
            {
                Type = "anyone",
                Role = "reader"
            };
            var requestShare = service.Permissions.Create(permision, fileid);
            await requestShare.ExecuteAsync();
            return $"https://drive.google.com/file/d/{fileid}/view?usp=sharing";
        }

        public string GetLinkFile(string fileId)
        {
            return $"https://drive.google.com/file/d/{fileId}";
        }
    }
}
