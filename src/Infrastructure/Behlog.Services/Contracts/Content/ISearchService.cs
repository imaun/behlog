using Behlog.Services.Dto.Content;
using System.Threading.Tasks;

namespace Behlog.Services.Contracts.Content {
    
    public interface ISearchService {
        Task<FrontSearchResultDto> FrontSearchAsync(string searchPhrase);
    }
}
