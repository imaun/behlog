using System.Threading.Tasks;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Extensions;
using Behlog.Core;
using Behlog.Core.Models.Content;
using Behlog.Services.Dto.Content;
using Behlog.Core.Security;
using Behlog.Core.Models.Enum;
using Behlog.Core.Utils.IO;
using Behlog.Factories.Extensions;
using Behlog.Factories.Contracts.Content;
using Behlog.Services.Dto.Admin.Content;
using Behlog.Core.Contracts.Repository.Content;

namespace Behlog.Factories.Content
{
    public class FileFactory: IFileFactory
    {
        private readonly IUserContext _userContext;
        private readonly IDateService _dateService;
        private readonly IWebsiteInfo _websiteInfo;
        private readonly IFileRepository _fileRepository;

        public FileFactory(
            IUserContext userContext,
            IDateService dateService,
            IWebsiteInfo websiteInfo,
            IFileRepository fileRepository) {

            userContext.CheckArgumentIsNull(nameof(userContext));
            _userContext = userContext;

            dateService.CheckArgumentIsNull(nameof(dateService));
            _dateService = dateService;

            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;

            fileRepository.CheckArgumentIsNull(nameof(fileRepository));
            _fileRepository = fileRepository;
        }


        public async Task<File> MakeAsync(CreateFileDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var utcNow = _dateService.UtcNow();

            var file = new File {
                CreateDate = utcNow,
                CreatorUserId = _userContext.UserId,
                Description = model.Description,
                ModifierUserId = _userContext.UserId,
                ModifyDate = utcNow,
                Status = FileStatus.UnAttached,
                WebsiteId = _websiteInfo.Id,
                Title = model.Title
            };

            if(!string.IsNullOrWhiteSpace(model.FilePath)) {
                file.FilePath = model.FileServerPath;
                file.Extension = model.FilePath.GetFileExtension();
                file.FileType = model.FilePath.GetPostFileType();
            }

            if (!string.IsNullOrWhiteSpace(model.Url))
                file.Url = model.Url;

            if (string.IsNullOrWhiteSpace(file.Title))
                file.Title = model.FilePath.GetFileTitle();

            return await Task.FromResult(file);
        }


        public async Task<File> MakeAsync(AdminCreateSliderItemDto model) {
            model.CheckArgumentIsNull(nameof(model));
            if (model.FileId.HasValue)
                return await _fileRepository.FindAsync(model.FileId.Value);

            var file = new File {
                CreateDate = _dateService.UtcNow(),
                CreatorUserId = _userContext.UserId,
                ModifierUserId = _userContext.UserId,
                Status = FileStatus.AttachedToPost,
                WebsiteId = _websiteInfo.Id,
                Title = model.Title
            };

            if(model.FilePath.IsNotNullOrEmpty()) {
                file.FilePath = model.FilePath;
                file.Extension = model.FilePath.GetFileExtension();
                file.FileType = model.FilePath.GetPostFileType();
            }

            if (model.Url.IsNotNullOrEmpty())
                file.Url = model.Url;

            if (file.Title.IsNullOrEmpty())
                file.Title = model.FilePath.GetFileTitle();

            return await Task.FromResult(file);
        }

    }
}
