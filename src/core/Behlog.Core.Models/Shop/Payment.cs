using System;
using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.Shop {
    
    public class Payment {

        public Payment() {

        }

        #region Properties
        public int Id { get; set; }

        /// <summary>
        /// The invoice that this payment belongs to.
        /// </summary>
        public int? InvoiceId { get; set; }

        /// <summary>
        /// This payment belongs to which customer. The customer's Id will saved for easier access.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Get or sets FirstName & LastName of customer that creates the payment at the time.
        /// </summary>
        public string CustomerTitle { get; set; }

        /// <summary>
        /// Total amount paid for this payment. The payment Fee.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Get or sets the Payment date and time.
        /// </summary>
        public DateTime? PayDate { get; set; }

        /// <summary>
        /// If the invoice will fully paid with this payment, this will set to true.
        /// </summary>
        public bool Paid { get; set; }

        /// <summary>
        /// This is for Online payments. Bank or gatway ReferenceId will be saved as TransactionId.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Get or sets the Method used to create payment.
        /// </summary>
        public PaymentMethod Method { get; set; }

        /// <summary>
        /// Get or sets Status of Payment.
        /// Determines Payment proccess success.
        /// </summary>
        public PaymentStatus Status { get; set; }

        public string GatewayUrl { get; set; }

        public string CallbackUrl { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }

        #endregion

        #region Navigations
        public Invoice Invoice { get; set; }
        public Customer Customer { get; set; }

        #endregion
    }
}
