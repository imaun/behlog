using Behlog.Services.Contracts.System;
using Behlog.Services.Dto.System;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core;
using Behlog.Core.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace Behlog.Services.System
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IWebsiteInfo _websiteInfo;


        public TagService(
            ITagRepository repository,
            IWebsiteInfo websiteInfo) {

            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;

            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;
        }


        public async Task<IEnumerable<TagDto>> LoadAsync() {
            var queryResult = await _repository
                .Query()
                .Where(_ => _.WebsiteId == _websiteInfo.Id)
                .ToListAsync();
            var result = queryResult.Adapt<List<TagDto>>();

            return await Task.FromResult(
                    result
                );
        }


        public async Task<IEnumerable<TagDto>> SearchAsync(string search) {
            var queryResult = await _repository
                .Query()
                .Where(_ => _.Title.Contains(search))
                .ToListAsync();

            var result = queryResult.Adapt<List<TagDto>>();
            return await Task.FromResult(result);
        }
    }
}
