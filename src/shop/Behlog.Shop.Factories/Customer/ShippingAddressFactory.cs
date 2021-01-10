using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Shop;
using Behlog.Shop.Services.Data;
using Behlog.Shop.Factories.Contracts;

namespace Behlog.Shop.Factories {

    public class ShippingAddressFactory: IShippingAddressFactory {

        public ShippingAddress BuildShippingAddress(CreateShippingAddressDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var result = new ShippingAddress {
                Address = model.Address.ApplyCorrectYeKe(),
                CityId = model.CityId,
                CustomerId = model.CustomerId,
                PostalCode = model.PostalCode,
                Status = EntityStatus.Enabled,
                Street = model.Street
            };

            return result;
        }
    }
}
