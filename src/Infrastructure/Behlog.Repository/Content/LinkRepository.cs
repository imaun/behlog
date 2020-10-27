using Behlog.Core.Contracts;
using Behlog.Core.Models.Content;
using Behlog.Core.Contracts.Repository.Content;

namespace Behlog.Repository.Content
{
    public class LinkRepository: BaseRepository<Link, int>, ILinkRepository
    {
        public LinkRepository(IBehlogContext context) : base(context) {
        }
    }
}
