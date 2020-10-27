using System.Threading.Tasks;
using Behlog.Core.Models.Feature;
using Behlog.Services.Dto.Feature;

namespace Behlog.Factories.Contracts.Feature
{
    public interface ISubscriberFactory
    {
        Task<Subscriber> MakeAsync(CreateSubscriberDto model);
    }
}
