using Behlog.Core.Contracts;
using Behlog.Core.Models.Feature;
using Behlog.Core.Contracts.Repository.Feature;

namespace Behlog.Repository.Feature
{
    public class FormFieldItemRepository: BaseRepository<FormFieldItem, long>, IFormFieldItemRepository
    {
        public FormFieldItemRepository(IBehlogContext context) : base(context) {
        }
    }
}
