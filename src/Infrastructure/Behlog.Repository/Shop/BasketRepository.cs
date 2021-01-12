using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;
using Behlog.Core.Contracts;

namespace Behlog.Repository.Shop {

    public class BasketRepository : BaseRepository<Basket, Guid>, IBasketRepository {

        public BasketRepository(IBehlogContext context) : base(context) { }

        public async Task<Basket> GetWithCustomerInfoAsync(Guid id) 
            => await _dbSet
                .Include(_ => _.Customer)
                .Include(_ => _.Items)
                .FirstOrDefaultAsync(_ => _.Id == id);
            
    }
}
