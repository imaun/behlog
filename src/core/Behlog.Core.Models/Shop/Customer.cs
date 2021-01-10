using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Security;
using Behlog.Core.Models.System;

namespace Behlog.Core.Models.Shop {

    public class Customer {

        public Customer() {
            ShippingAddresses = new HashSet<ShippingAddress>();
            Invoices = new HashSet<Invoice>();
            Payments = new HashSet<Payment>();
            Reviews = new HashSet<ProductReview>();
            Baskets = new HashSet<Basket>();
        }

        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        /// <summary>
        /// Get or sets the value of کد ملی
        /// </summary>
        public string NationalCode { get; set; }
        /// <summary>
        /// Get or sets the value of کد ملی شرکت
        /// </summary>
        public string CompanyNationalCode { get; set; }
        /// <summary>
        /// Get or sets the value of شماره اقتصادی
        /// </summary>
        public string FinancialCode { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid? UserId { get; set; }
        public int WebsiteId { get; set; }
        public CustomerStatus Status { get; set; }
        /// <summary>
        /// Get or sets حقیقی یا حقوقی
        /// </summary>
        public CustomerPersonalityType PersonalityType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        
        #endregion

        #region Navigations
        public User User { get; set; }
        public Website Website { get; set; }
        public ICollection<ShippingAddress> ShippingAddresses { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<ProductReview> Reviews { get; set; }
        public ICollection<Basket> Baskets { get; set; }
        #endregion

        #region Calculated 

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        #endregion
    }
}
