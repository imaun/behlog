using System;
using System.IO;
using System.Linq;
using Behlog.Core.Exceptions;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Resources.Strings;
using Behlog.Web.Core.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Behlog.Web.Common.Tools
{
    public class FileUploadHelper {
        private readonly IWebHostEnvironment _webHost;
        private readonly IOptionsSnapshot<BehlogSetting> _setting;

        public FileUploadHelper(
            IWebHostEnvironment webHost,
            IOptionsSnapshot<BehlogSetting> setting
        ) {
            webHost.CheckArgumentIsNull();
            _webHost = webHost;

            setting.CheckArgumentIsNull();
            _setting = setting;

        }


        #region Properties

        private BehlogSetting Options => _setting.Value;

        public string PhotoRootPath => Options.WebConfig
            .UploadPhotoPath.Replace("~", _webHost.WebRootPath);

        public string[] ValidPhotoExtensions =>
            Options.WebConfig.ValidPhotoFileExtensionsList;

        public string[] ValidVideoExtensions =>
            Options.WebConfig.ValidVideoFileExtensionsList;

        public string[] ValidAudioExtensions =>
            Options.WebConfig.ValidAudioFileExtensionsList;

        public string[] ValidDocumentExtensions =>
            Options.WebConfig.ValidDocumentFileExtensionsList;

        #endregion

        #region Methods

        private void CreateDirIfNotExist(string path) {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private string GetUniqueFileName(Guid fileId, string fileName) {
            fileName = Path.GetFileName(fileName);

            return Path.GetFileNameWithoutExtension(fileName)
                   + "_"
                   + fileId.ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }

        private PostFileType getPostFileType(string fileExt) {
            fileExt = fileExt.ToLower();
            if (ValidPhotoExtensions.Contains(fileExt))
                return PostFileType.Image;
            if (ValidVideoExtensions.Contains(fileExt))
                return PostFileType.Video;
            if (ValidDocumentExtensions.Contains(fileExt))
                return PostFileType.Document;
            if (ValidAudioExtensions.Contains(fileExt))
                return PostFileType.Audio;

            return PostFileType.Common;
        }

        private string GetUploadUrl(string path, string filename) {
            if (!path.EndsWith("/"))
                path += "/";

            return $"{path}/{filename}";
        }

        private void CheckPhotoExtension(string filename) {
            var ext = Path.GetExtension(filename);
            if(!ValidPhotoExtensions.Contains(ext))
                throw new UploadFileExtensionNotValidException();
        }

        public FileUploadResult UploadPhoto(IFormFile fileInfo) {
            fileInfo.CheckArgumentIsNull();
            var result = new FileUploadResult {
                StartDateTime = DateTime.Now
            };
            CheckPhotoExtension(fileInfo.FileName);
            CreateDirIfNotExist(PhotoRootPath);
            result.FileExtension = Path.GetExtension(fileInfo.FileName);
            result.FileType = getPostFileType(result.FileExtension);
            var filename = GetUniqueFileName(result.Id, fileInfo.FileName);
            result.UploadUrl = GetUploadUrl(Options.WebConfig.UploadPhotoPath, filename);
            result.TargetFileName = Path.Combine(PhotoRootPath, filename);
            try {
                fileInfo.CopyTo(new FileStream(result.TargetFileName, FileMode.Create));
            }
            catch(UploadFileExtensionNotValidException e) {
                result.Exception = e;
                result.HasError = true;
                result.ErrorMessage = AppTextDisplay.UploadFileExtNotValid;
            }
            catch (Exception e) {
                result.Exception = e;
                result.HasError = true;
                result.ErrorMessage = AppTextDisplay.FileUploadError;
            }
            finally {
                result.FinishDateTime = DateTime.Now;
            }

            return result;
        }



        #endregion

    }

    public class FileUploadResult {
        public FileUploadResult() {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? FinishDateTime { get; set; }
        public string TargetFileName { get; set; }
        public string UploadUrl { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Exception { get; set; }
        public bool HasError { get; set; }
        public string FileExtension { get; set; }
        public PostFileType FileType { get; set; }

        public override string ToString() 
            => UploadUrl;
        
    }
}
