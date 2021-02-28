using System.Threading.Tasks;
using Behlog.Services.Dto.Admin.Content;

namespace Behlog.Services.Contracts.Admin {

    public interface IAdminSliderService {

        Task<AdminSliderResultDto> CreateAsync(AdminCreateSliderDto model);

        Task<AdminSliderResultDto> GetForEditAsync(int postId);
    }
}
