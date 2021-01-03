using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop
{
    public class BrandRepository: BaseRepository<Brand, int>, IBrandRepository
    {

        public BrandRepository(IBehlogContext context): base(context) {  }


    }
}
