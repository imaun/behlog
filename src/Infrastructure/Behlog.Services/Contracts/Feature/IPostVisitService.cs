using System.Threading.Tasks;
using Behlog.Services.Dto.Feature;

namespace Behlog.Services.Contracts.Feature {
    public interface IPostVisitService {

        Task CreateAsync(CreatePostVisitDto model);
        void Create(CreatePostVisitDto model);
    }
}
