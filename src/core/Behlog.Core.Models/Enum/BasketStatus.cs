namespace Behlog.Core.Models.Enum {
    public enum BasketStatus {
        Deleted = -1,
        Active = 0,
        Completed = 1,
        Abandoned = 2,
        Failed = 3
    }

    public enum BasketItemStatus { 
        Deleted = -1,
        Added = 0,
        Invoiced = 1
    }
}
