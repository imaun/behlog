using Behlog.Core.Models.System;
using Behlog.Services.Dto.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Behlog.Factories.Contracts.System
{
    public interface IErrorLogFactory
    {
        Task<ErrorLog> MakeAsync(CreateErrorLogDto model);
    }
}
