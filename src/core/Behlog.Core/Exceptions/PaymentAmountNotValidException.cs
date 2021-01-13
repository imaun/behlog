namespace Behlog.Core.Exceptions {

    public class PaymentAmountNotValidException: BehlogException {
        public PaymentAmountNotValidException(decimal amount)
            : base(message: $"The value '{amount}' is not valid for payment.") 
            { }
    }
}
