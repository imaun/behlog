using System.Threading.Tasks;
using Behlog.Services.Dto.Feature;

namespace Behlog.Validation.Contracts.Feature
{
    public interface ISubscriberValidator
    {
        Task<bool> ValidateCreateAsync(CreateSubscriberDto model);
    }
}
