using System.Threading.Tasks;
using Behlog.Core.Models.Feature;

namespace Behlog.Core.Contracts.Repository.Feature
{
    public interface IContactRepository: IBaseRepository<Contact, int>
    {
    }
}
