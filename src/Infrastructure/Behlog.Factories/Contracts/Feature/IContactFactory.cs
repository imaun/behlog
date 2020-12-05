using System.Threading.Tasks;
using Behlog.Core.Models.Feature;
using Behlog.Services.Dto.Feature;

namespace Behlog.Factories.Contracts.Feature
{
    public interface IContactFactory {
        Task<Contact> MakeAsync(CreateContactDto model);
        Contact MarkAsViewed(Contact contact);
        Contact MarkAsRead(Contact contact);
    }
}
