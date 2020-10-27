using System.Threading.Tasks;
using Behlog.Services.Dto.Feature;

namespace Behlog.Services.Contracts.Feature
{
    public interface ISubscriberService
    {
        Task CreateAsync(CreateSubscriberDto model);
    }
}
