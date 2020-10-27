using System.Threading.Tasks;
using Behlog.Core.Models.Feature;
using Behlog.Services.Dto.Feature;

namespace Behlog.Factories.Contracts.Feature
{
    public interface IPostVisitFactory
    {
        Task<PostVisit> MakeAsync(CreatePostVisitDto model);
        PostVisit Make(CreatePostVisitDto model);
    }
}
