using System.Threading.Tasks;
using Behlog.Core.Models.Feature;

namespace Behlog.Core.Contracts.Repository.Feature
{
    public interface ISubscriberRepository : IBaseRepository<Subscriber, long>
    {
        Task<Subscriber> FindByEmailAsync(string email);
    }
}
