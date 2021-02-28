using System.Threading.Tasks;
using Behlog.Services.Dto.Admin.Content;

namespace Behlog.Services.Contracts.Admin {

    public interface IAdminSliderService
    {
        Task CreateAsync(AdminCreateSliderDto model);
    }
}
