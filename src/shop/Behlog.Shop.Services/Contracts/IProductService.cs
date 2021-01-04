using Behlog.Shop.Services.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Behlog.Shop.Services.Contracts
{
    public interface IProductService
    {
        Task<ProductResultDto> GetResultByIdAsync(int id);
    }
}
