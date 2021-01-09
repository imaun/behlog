using Behlog.Core.Models.Enum;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Shop;
using Behlog.Shop.Services.Data;

namespace Behlog.Shop.Factories.Contracts
{
    public interface IShippingAddressFactory
    {
        ShippingAddress BuildShippingAddress(CreateShippingAddressDto model);
    }
}
