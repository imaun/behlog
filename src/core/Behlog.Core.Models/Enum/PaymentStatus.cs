namespace Behlog.Core.Models.Enum {
    public enum PaymentStatus {
        Deleted = -1,
        Created = 0,
        Successful = 1,
        SuccessfulAndFullyPaid = 2,
        SuccessfulButHasRemaining = 3,
        Unsuccessful = 4,
    }
}
