using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Contracts;
using Behlog.Core.Contracts.Repository.Feature;
using Behlog.Core.Models.Feature;

namespace Behlog.Repository.Feature
{
    public class SubscriberRepository : BaseRepository<Subscriber, long>, ISubscriberRepository
    {
        public SubscriberRepository(IBehlogContext context) : base(context) { }


        public async Task<Subscriber> FindByEmailAsync(string email) =>
            await _dbSet.FirstOrDefaultAsync(_ => _.Email.ToLower()
                                                        == email.ToLower());


    }
}
