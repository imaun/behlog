using System;
using System.IO;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Security;
using Behlog.Services.Contracts.Security;
using Behlog.Web.Core.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Behlog.Services.Security
{
    public class UserProfileImageService: IUserProfileImageService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IOptionsSnapshot<BehlogSetting> _siteSettings;

        public UserProfileImageService(
            IHttpContextAccessor contextAccessor,
            IWebHostEnvironment hostingEnvironment,
            IOptionsSnapshot<BehlogSetting> siteSettings) {
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(_contextAccessor));
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(_hostingEnvironment));
            _siteSettings = siteSettings ?? throw new ArgumentNullException(nameof(_siteSettings));
        }

        public string GetUsersAvatarsFolderPath() {
            var usersAvatarsFolder = ""; //_siteSettings.Value.UsersAvatarsFolder;
            var uploadsRootFolder = Path.Combine(_hostingEnvironment.WebRootPath, usersAvatarsFolder);
            if (!Directory.Exists(uploadsRootFolder)) {
                Directory.CreateDirectory(uploadsRootFolder);
            }
            return uploadsRootFolder;
        }

        public void SetUserDefaultPhoto(User user) {
            throw new NotImplementedException();
            //if (!string.IsNullOrWhiteSpace(user.PhotoFileName)) {
            //    return;
            //}

            //var avatarPath = Path.Combine(GetUsersAvatarsFolderPath(), user.PhotoFileName ?? string.Empty);
            //if (!File.Exists(avatarPath)) {
            //    user.PhotoFileName = _siteSettings.Value.UserDefaultPhoto;
            //}
        }

        public string GetUserDefaultPhoto(string photoFileName) {
            throw new NotImplementedException();
            //if (string.IsNullOrWhiteSpace(photoFileName)) {
            //    return _siteSettings.Value.UserDefaultPhoto;
            //}

            //var avatarPath = Path.Combine(GetUsersAvatarsFolderPath(), photoFileName ?? string.Empty);
            //return !File.Exists(avatarPath) ? _siteSettings.Value.UserDefaultPhoto : photoFileName;
        }

        public string GetUserPhotoUrl(string photoFileName) {
            throw new NotImplementedException();
            //photoFileName = GetUserDefaultPhoto(photoFileName);
            //return $"~/{_siteSettings.Value.UsersAvatarsFolder}/{photoFileName}";
        }

        public string GetCurrentUserPhotoUrl() {
            var photoFileName = _contextAccessor.HttpContext.User.Identity.GetUserClaimValue(AppClaimsPrincipalFactory.PhotoFileName);
            return GetUserPhotoUrl(photoFileName);
        }
    }
}
