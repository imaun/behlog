using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Extensions;
using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop {

    public class ProductMetaRepository: BaseRepository<ProductMeta, int>, IProductMetaRepository {

        public ProductMetaRepository(IBehlogContext context): base(context) {  }

        public async Task<ProductMeta> GetProductMetaAsync(int productId, string metaKey)
            => await FirstOrDefaultAsync(_ => _.ProductId == productId && 
                                            _.MetaKey.ToUpper() == metaKey.ToUpper());

        public async Task<IEnumerable<ProductMeta>> GetProductMetaAsync(
            int productId, 
            int? langId = null, 
            string category = null) {
            var query = _dbSet.Where(_ => _.ProductId == productId);
            query = addFilter(query, langId, category);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<ProductMeta>> GetProductMetaWithProductAsync(
            int productId, 
            int? langId = null, 
            string category = null) {
            var query = _dbSet.Include(_ => _.Product)
                .Where(_ => _.ProductId == productId);
            query = addFilter(query, langId, category);

            return await query.ToListAsync();
        }

        private IQueryable<ProductMeta> addFilter(
            IQueryable<ProductMeta> query,
            int? langId = null,
            string category = null) {

            if (langId.HasValue)
                query = query.Where(_ => _.LangId == langId);

            if (category.IsNotNullOrEmpty())
                query = query.Where(_ => _.Category.ToUpper() == category.ToUpper());

            return query;
        }
    }
}
