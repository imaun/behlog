using Behlog.Core;
using Behlog.Core.Contracts.Repository.Content;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Content;
using Behlog.Core.Security;
using Behlog.Factories.Contracts.Content;
using Behlog.Services.Dto.Admin.Content;
using System.Threading.Tasks;

namespace Behlog.Factories.Content
{

    public class PostFileFactory: IPostFileFactory {

        private readonly IWebsiteInfo _websiteInfo;
        private readonly IDateService _dateService;
        private readonly IUserContext _userContext;
        private readonly IFileRepository _fileRepository;

        public PostFileFactory(
            IWebsiteInfo websiteInfo,
            IDateService dateService,
            IUserContext userContext,
            IFileRepository fileRepository) {

            websiteInfo.CheckArgumentIsNull();
            _websiteInfo = websiteInfo;

            dateService.CheckArgumentIsNull();
            _dateService = dateService;

            userContext.CheckArgumentIsNull();
            _userContext = userContext;

            fileRepository.CheckArgumentIsNull();
            _fileRepository = fileRepository;
        }


        public async Task<PostFile> MakeAsync(CreatePostFileDto model) {
            model.CheckArgumentIsNull();
            if(model.FileId.HasValue) {
                var referencedFile = await _fileRepository.FindAsync(model.FileId.Value);
                referencedFile.CheckReferenceIsNull();
                var postFile = new PostFile {
                    CreateDate = _dateService.UtcNow(),
                    CreatorUserId = _userContext.UserId,
                    FileId = referencedFile.Id,
                    File = referencedFile,
                    ModifierUserId = _userContext.UserId,
                    ModifyDate = _dateService.UtcNow(),
                    OrderNum = model.OrderNum,
                    PostId = model.PostId
                };
                return await Task.FromResult(postFile);
            }

            return new PostFile();
            //var file = new File {
            //    CreateDate = _dateService.UtcNow(),
            //    CreatorUserId = _userContext.UserId,
                
            //};
        }

        public async Task<PostFile> MakeAsync(File file, 
            string title, 
            int? postId = null, 
            int? relatedFileId = null,
            int orderNum = 1) {
            file.CheckArgumentIsNull(nameof(file));

            var result = new PostFile {
                CreateDate = _dateService.UtcNow(),
                CreatorUserId = _userContext.UserId,
                File = file,
                FileId = file.Id,
                ModifierUserId = _userContext.UserId,
                ModifyDate = _dateService.UtcNow(),
                OrderNum = orderNum,
                Title = title.ApplyCorrectYeKe()
            };

            if (postId.HasValue)
                result.PostId = postId.Value;

            if (relatedFileId.HasValue)
                result.RelatedFileId = relatedFileId;

            return await Task.FromResult(result);
        }
    }
}
