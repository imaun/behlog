using Behlog.Core.Contracts;
using Behlog.Core.Contracts.Repository.Feature;
using Behlog.Core.Models.Feature;

namespace Behlog.Repository.Feature
{
    public class FormRepository: BaseRepository<Form, int>, IFormRepository
    {
        public FormRepository(IBehlogContext context) : base(context) {
        }
    }
}
