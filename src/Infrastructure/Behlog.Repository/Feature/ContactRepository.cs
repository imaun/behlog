using Behlog.Core.Contracts;
using Behlog.Core.Models.Feature;
using Behlog.Core.Contracts.Repository.Feature;

namespace Behlog.Repository.Feature
{
    public class ContactRepository: BaseRepository<Contact, int>, IContactRepository
    {
        public ContactRepository(IBehlogContext context) : base(context) {
        }
    }
}
