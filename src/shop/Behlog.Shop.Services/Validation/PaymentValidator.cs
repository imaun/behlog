using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Core.Exceptions;
using Behlog.Shop.Services.Data;

namespace Behlog.Shop.Services.Validation
{
    public interface IPaymentValidator
    {
        Task<bool> ValidateCreateOnlinePaymentAsync(CreateOnlinePaymentDto model);
    }

    public class PaymentValidator : IPaymentValidator {


        public PaymentValidator() {

        }

        public async Task<bool> ValidateCreateOnlinePaymentAsync(
            CreateOnlinePaymentDto model) {
            model.CheckArgumentIsNull(nameof(model));
            if (model.Amount <= 0 || model.Amount == decimal.MaxValue)
                throw new PaymentAmountNotValidException(model.Amount);

            return true;
        }
    }
}
