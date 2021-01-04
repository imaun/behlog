using Behlog.Core.Models.Shop;
using System.Threading.Tasks;

namespace Behlog.Core.Contracts.Repository.Shop {
    public interface IProductRepository: IBaseRepository<Product, int> {
        Task<Product> GetByIdAsync(int id);
    }
}
