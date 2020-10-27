using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Services.Dto.System;

namespace Behlog.Factories.Contracts.System
{
    public interface IPostTypeService {
        Task<PostTypeResultDto> GetResultByIdAsync(int id);
        Task<PostTypeResultDto> GetBySlugAsync(string slug);
    }
}
