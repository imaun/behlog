using Behlog.Core.Exceptions;
using Behlog.Core.Models.Shop;
using Behlog.Core.Models.Enum;
using Behlog.Core.Extensions;
using DNTPersianUtils.Core;

namespace Behlog.Shop.Services.Validation {

    public interface ICustomerValidator
    {
        bool ValidateCreate(Customer customer);
    }

    public class CustomerValidator: ICustomerValidator {

        public bool ValidateCreate(Customer customer) {
            if (customer.FirstName.IsNullOrEmpty())
                throw new EntityInsufficientDataException(nameof(customer.FirstName));

            if (customer.LastName.IsNullOrEmpty())
                throw new EntityInsufficientDataException(nameof(customer.LastName));

            if (customer.PersonalityType == CustomerPersonalityType.Real && 
                    !customer.NationalCode.IsValidIranianNationalCode())
                        throw new EntityDataIsWrongException(
                            nameof(customer.NationalCode), 
                            customer.NationalCode);

            if (customer.Mobile.IsNullOrEmpty())
                throw new EntityInsufficientDataException(nameof(customer.Mobile));

            if (!customer.Mobile.IsValidIranianMobileNumber())
                throw new EntityDataIsWrongException(
                    nameof(customer.Mobile), customer.Mobile);

            return true;
        }


    }
}
