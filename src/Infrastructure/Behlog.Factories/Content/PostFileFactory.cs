using Behlog.Core;
using Behlog.Core.Contracts.Repository.Content;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Content;
using Behlog.Core.Security;
using Behlog.Services.Dto.Admin.Content;
using System.Threading.Tasks;

namespace Behlog.Factories.Content
{

    public class PostFileFactory {
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
    }
}
