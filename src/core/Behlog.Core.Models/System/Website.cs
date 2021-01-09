using System;
using System.Collections.Generic;
using Behlog.Core.Models.Content;
using Behlog.Core.Models.Feature;
using Behlog.Core.Models.Security;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Shop;

namespace Behlog.Core.Models.System {
    
    public class Website {

        public Website() {
            Files = new HashSet<File>();
            Categories = new HashSet<Category>();
            Contacts = new HashSet<Contact>();
            Posts = new HashSet<Post>();
            Visits = new HashSet<WebsiteVisit>();
            Logins = new HashSet<UserLogin>();
            MenuItems = new HashSet<Menu>();
            Links = new HashSet<Link>();
            Forms = new HashSet<Form>();
            Options = new HashSet<WebsiteOption>();
            Errors = new HashSet<ErrorLog>();
            SectionGroups = new HashSet<SectionGroup>();
            Subscribers = new HashSet<Subscriber>();
            Tags = new HashSet<Tag>();
            Customers = new HashSet<Customer>();
            Products = new HashSet<Product>();
            Invoices = new HashSet<Invoice>();
            Baskets = new HashSet<Basket>();
        }

        #region Proeprties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Url { get; set; }
        public EntityStatus Status { get; set; }
        public Guid OwnerId { get; set; }
        public int DefaultLangId { get; set; }
        public int? DefaultCurrencyId { get; set; }
        public int? DefaultShippingId { get; set; }
        public int LayoutId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        #endregion

        #region Navigations
        public User Owner { get; set; }
        public Language DefaultLanguage { get; set; }
        public Layout Layout { get; set; }
        public Currency DefaultCurrency { get; set; }
        public Shipping DefaultShipping { get; set; }
        public ICollection<File> Files { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<WebsiteVisit> Visits { get; set; }
        public ICollection<UserLogin> Logins { get; set; }
        public ICollection<Menu> MenuItems { get; set; }
        public ICollection<Link> Links { get; set; }
        public ICollection<Form> Forms { get; set; }
        public ICollection<WebsiteOption> Options { get; set; }
        public ICollection<ErrorLog> Errors { get; set; }
        public ICollection<SectionGroup> SectionGroups { get; set; }
        public ICollection<Subscriber> Subscribers { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Basket> Baskets { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        #endregion

    }
}
