using Behlog.Core.Contracts;
using Behlog.Core.Contracts.Repository.Feature;
using Behlog.Core.Models.Feature;

namespace Behlog.Repository.Feature
{
    public class FormFieldValueRepository: BaseRepository<FormFieldValue, long>, IFormFieldValueRepository
    {
        public FormFieldValueRepository(IBehlogContext context) : base(context) {
        }
    }
}
