using System.Threading.Tasks;
using Behlog.Services.Dto.Content;

namespace Behlog.Services.Contracts.Content
{
    public interface IFileService
    {
        Task<FileResultDto> CreateAsync(CreateFileDto model);
        Task<FileResultDto> GetResultByIdAsync(long id);
    }
}
