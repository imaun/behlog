using Behlog.Core.Contracts;
using Behlog.Core.Models.Content;
using Behlog.Core.Contracts.Repository.Content;

namespace Behlog.Repository.Content
{
    public class FileRepository: BaseRepository<File, long>, IFileRepository
    {
        public FileRepository(IBehlogContext context) : base(context) {
        }
    }
}
