using Behlog.Core.Models.Security;

namespace Behlog.Services.Contracts.Security {
    public interface IUserProfileImageService {
        string GetUsersAvatarsFolderPath();
        void SetUserDefaultPhoto(User user);
        string GetUserDefaultPhoto(string photoFileName);
        string GetUserPhotoUrl(string photoFileName);
        string GetCurrentUserPhotoUrl();

    }
}
