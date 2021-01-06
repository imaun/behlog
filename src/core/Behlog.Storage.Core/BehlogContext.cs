using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Behlog.Core.Contracts;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Security;
using Behlog.Core.Models.Content;
using Behlog.Core.Models.System;
using Behlog.Core.Models.Feature;
using Behlog.Storage.Core.Mappings;
using Behlog.Core.Models.Shop;

namespace Behlog.Storage.Core {

    public class BehlogContext : IdentityDbContext<
        User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>,
        IBehlogContext 
    {

        public BehlogContext(DbContextOptions options): base(options) { }

        #region Fields

        private IDbContextTransaction _transaction;

        #endregion

        #region Tables

        #region Content Sets
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Link> Links { get; set; }
        public virtual DbSet<PostFile> PostFiles { get; set; }
        public virtual DbSet<PostLike> PostLikes { get; set; }
        public virtual DbSet<PostMeta> PostMeta { get; set; }
        public virtual DbSet<PostTag> PostTags { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<SectionGroup> SectionGroups { get; set; }

        #endregion

        #region Feature Sets
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<FormField> FormFields { get; set; }
        public virtual DbSet<FormFieldItem> FormFieldItems { get; set; }
        public virtual DbSet<FormFieldValue> FormFieldValues { get; set; }
        public virtual DbSet<PostVisit> PostVisits { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }
        public virtual DbSet<WebsiteVisit> WebsiteVisits { get; set; }

        #endregion

        #region System Sets
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Layout> Layouts { get; set; }
        public virtual DbSet<Menu> MenuItems { get; set; }
        public virtual DbSet<PostType> PostTypes { get; set; }
        public virtual DbSet<Website> Websites { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<UserMeta> UserMeta { get; set; }
        public virtual DbSet<WebsiteOption> Options { get; set; }

        #endregion

        #region Shop Module Sets
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductMeta> ProductMeta { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; } 
        public virtual DbSet<ProductReview> ProductReviews { get; set; }
        public virtual DbSet<Shipping> Shippings { get; set; }
        public virtual DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        #endregion

        #endregion

        #region Interface Methods

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class {
            Set<TEntity>().AddRange(entities);
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class {
            Set<TEntity>().RemoveRange(entities);
        }

        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class {
            Update(entity);
        }

        public int ExecuteSqlCommand(string query) {
            return Database.ExecuteSqlRaw(query);
        }

        public Task<int> ExecuteSqlCommandAsync(string query, params object[] parameters) {
            return Database.ExecuteSqlRawAsync(query, parameters);
        }

        public void SetAsNoTrackingQuery() {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override int SaveChanges() {
            ChangeTracker.DetectChanges();
            BeforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false;
            var result = base.SaveChanges();
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess) {
            ChangeTracker.DetectChanges();
            BeforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChanges(acceptAllChangesOnSuccess);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken()) {
            ChangeTracker.DetectChanges();
            BeforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false;
            var result = base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) {
            ChangeTracker.DetectChanges();
            BeforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChangesAsync(cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public void BeginTransaction() {
            _transaction = Database.BeginTransaction();
        }

        public void RollbackTransaction() {
            if (_transaction == null) {
                throw new NullReferenceException("Please call `BeginTransaction()` method first.");
            }
            _transaction.Rollback();
        }

        public void CommitTransaction() {
            if (_transaction == null) {
                throw new NullReferenceException("Please call `BeginTransaction()` method first.");
            }
            _transaction.Commit();
        }

        public override void Dispose() {
            _transaction?.Dispose();
            base.Dispose();
        }

        public void ExecuteSqlInterpolatedCommand(FormattableString query) {
            Database.ExecuteSqlInterpolated(query);
        }

        public void ExecuteSqlRawCommand(string query, params object[] parameters) {
            Database.ExecuteSqlRaw(query, parameters);
        }

        #endregion

        #region Private Methods

        private void BeforeSaveTriggers() {
            this.CorrectYeKe();
        }

        #endregion

        #region Mappings

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            #region Content
            builder.AddCommentMapping();
            builder.AddFileMapping();
            builder.AddLinkMapping();
            builder.AddPostFileMapping();
            builder.AddPostLikeMapping();
            builder.AddPostMapping();
            builder.AddPostMetaMapping();
            builder.AddPostTagMapping();
            builder.AddSectionGroupMapping();
            builder.AddSectionMapping();
            #endregion

            #region Feature
            builder.AddContactMapping();
            builder.AddFormFieldItemMapping();
            builder.AddFormFieldMapping();
            builder.AddFormFieldValueMapping();
            builder.AddFormMapping();
            builder.AddPostVisitMapping();
            builder.AddWebsiteVisitMapping();
            builder.AddSubscriberMapping();
            #endregion

            #region System
            builder.AddCategoryMapping();
            builder.AddCityMapping();
            builder.AddCurrencyMapping();
            builder.AddErrorLogMapping();
            builder.AddLanguageMapping();
            builder.AddLayoutMapping();
            builder.AddMenuMapping();
            builder.AddPostTypeMapping();
            builder.AddTagMapping();
            builder.AddWebsiteMapping();
            builder.AddWebsiteOptionMapping();
            #endregion

            #region Security 
            builder.AddUserMapping();
            builder.AddUserLoginMapping();
            builder.AddUserClaimMapping();
            builder.AddUserTokenMapping();
            builder.AddUserMetaMapping();
            builder.AddUserRoleMapping();
            builder.AddRoleMapping();
            builder.AddRoleClaimMapping();
            #endregion

            #region Shop 
            builder.AddBrandMapping();
            builder.AddBasketMapping();
            builder.AddBasketItemMapping();
            builder.AddCustomerMapping();
            builder.AddInvoiceMapping();
            builder.AddOrderMapping();
            builder.AddPaymentMapping();
            builder.AddProductMapping();
            builder.AddProductMetaMapping();
            builder.AddProductModelMapping();
            builder.AddProductPriceMapping();
            builder.AddProductReviewMapping();
            builder.AddShippingMapping();
            builder.AddShippingAddressMapping();
            builder.AddVendorMapping();

            #endregion

        }

        #endregion
    }
}
