using Behlog.Core.Contracts;
using Behlog.Core.Models.Feature;
using Behlog.Core.Contracts.Repository.Feature;

namespace Behlog.Repository.Feature
{
    public class FormFieldRepository: BaseRepository<FormField, long>, IFormFieldRepository
    {
        public FormFieldRepository(IBehlogContext context) : base(context) {
        }
    }
}
