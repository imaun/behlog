using System.Threading.Tasks;
using System.Collections.Generic;
using Behlog.Core.Models.Shop;

namespace Behlog.Core.Contracts.Repository.Shop {
    
    public interface IProductMetaRepository: IBaseRepository<ProductMeta, int> {
        Task<ProductMeta> GetProductMetaAsync(int productId, string metaKey);
        Task<IEnumerable<ProductMeta>> GetProductMetaAsync(
            int productId, 
            int? langId = null, 
            string category = null);
        Task<IEnumerable<ProductMeta>> GetProductMetaWithProductAsync(
            int productId,
            int? langId = null,
            string category = null);
    }
}
