using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Core.Extensions;
using Behlog.Services.Dto.Content;
using Behlog.Services.Contracts.Content;
using Behlog.Core.Contracts.Repository.Content;
using Mapster;

namespace Behlog.Services.Content {

    public class SearchService: ISearchService
    {

        private readonly IPostRepository _postRepository;
        private readonly IWebsiteInfo _websiteInfo;

        public SearchService(
            IPostRepository postRepository,
            IWebsiteInfo websiteInfo) {
            postRepository.CheckArgumentIsNull();
            _postRepository = postRepository;
            websiteInfo.CheckArgumentIsNull();
            _websiteInfo = websiteInfo;
        }


        public async Task<FrontSearchResultDto> FrontSearchAsync(string searchPhrase) {
            var (posts, totalCount) = await _postRepository.FrontSearchAsync(
                _websiteInfo.Id, 
                searchPhrase);

            var result = new FrontSearchResultDto {
                Items = posts.Adapt<List<SearchResultItemDto>>(),
                TotalCount = totalCount
            };

            return await Task.FromResult(result);
        }
    }
}
