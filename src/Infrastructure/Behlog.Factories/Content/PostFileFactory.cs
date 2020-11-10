using Behlog.Core;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Content;
using Behlog.Core.Security;
using Behlog.Services.Dto.Admin.Content;
using System.Threading.Tasks;

namespace Behlog.Factories.Content
{
    public class PostFileFactory
    {
        private readonly IWebsiteInfo _websiteInfo;
        private readonly IDateService _dateService;
        private readonly IUserContext _userContext;

        public async Task<PostFile> MakeAsync(CreatePostFileDto model) {
            model.CheckArgumentIsNull();
            var file = new File {

            };
        }
    }
}
