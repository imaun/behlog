using Behlog.Services.Dto.System;
using System.Threading.Tasks;

namespace Behlog.Services.Contracts.System
{
    public interface IErrorLogService
    {
        Task CreateAsync(CreateErrorLogDto model);
    }
}
