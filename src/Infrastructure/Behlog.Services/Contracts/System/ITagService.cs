using System;
using System.Threading.Tasks;
using System.Text;
using System.Collections;
using Behlog.Services.Dto.System;
using System.Collections.Generic;

namespace Behlog.Services.Contracts.System
{
    public interface ITagService
    {
        Task<IEnumerable<TagDto>> LoadAsync();

        Task<IEnumerable<TagDto>> SearchAsync(string search);
    }
}
