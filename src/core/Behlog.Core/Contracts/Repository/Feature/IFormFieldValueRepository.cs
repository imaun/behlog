using System.Threading.Tasks;
using Behlog.Core.Models.Feature;

namespace Behlog.Core.Contracts.Repository.Feature
{
    public interface IFormFieldValueRepository: IBaseRepository<FormFieldValue, long>
    {
    }
}
