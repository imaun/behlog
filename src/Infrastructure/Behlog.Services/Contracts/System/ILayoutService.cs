using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Services.Dto.System;

namespace Behlog.Services.Contracts.System
{
    public interface ILayoutService {
        Task<LayoutResultDto> CreateAsync(LayoutCreateDto model);
        Task<LayoutResultDto> GetByNameAsync(string name);
    }
}
