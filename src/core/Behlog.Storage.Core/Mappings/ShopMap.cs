using Microsoft.EntityFrameworkCore;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Shop;
using System;

namespace Behlog.Storage.Core.Mappings {
    public static partial class TableMapper {

        public static void AddBrandMapping(this ModelBuilder builder) {
            builder.Entity<Brand>(map => {
                map.ToTable(DbConst.Brand_Table_Name)
                    .HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(300).IsUnicode().IsRequired();
                map.Property(_ => _.Slug).HasMaxLength(500).IsUnicode().IsRequired();
                map.Property(_ => _.Description).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.CoverPhoto).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);
            });
        }

        public static void AddCustomerMapping(this ModelBuilder builder) {
            builder.Entity<Customer>(map => {
                map.ToTable(DbConst.Customer_Table_Name)
                    .HasKey(_ => _.Id);

                map.Property(_ => _.FirstName).HasMaxLength(300).IsUnicode();
                map.Property(_ => _.LastName).HasMaxLength(300).IsUnicode().IsRequired();
                map.Property(_ => _.NationalCode).HasMaxLength(50).IsUnicode();
                map.Property(_ => _.CompanyNationalCode).HasMaxLength(50).IsUnicode();
                map.Property(_ => _.FinancialCode).HasMaxLength(50).IsUnicode();
                map.Property(_ => _.Mobile).HasMaxLength(50).IsUnicode();
                map.Property(_ => _.Phone).HasMaxLength(50).IsUnicode();
                map.Property(_ => _.Email).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(CustomerStatus.Enabled);
                map.Property(_ => _.PersonalityType).HasDefaultValue(CustomerPersonalityType.Real);

                map.HasOne(_ => _.User)
                    .WithMany(_ => _.Customers)
                    .HasForeignKey(_ => _.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddInvoiceMapping(this ModelBuilder builder) {
            builder.Entity<Invoice>(map => {
                map.ToTable(DbConst.Invoice_Table_Name)
                    .HasKey(_=> _.Id);

                map.Property(_ => _.InvoiceNumnber).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(InvoiceStatus.Issued);

                map.HasOne(_ => _.Customer)
                    .WithMany(_ => _.Invoices)
                    .HasForeignKey(_ => _.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.Shipping)
                    .WithMany(_ => _.Invoices)
                    .HasForeignKey(_ => _.ShippingId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.ShippingAddress)
                    .WithMany(_ => _.Invoices)
                    .HasForeignKey(_ => _.ShippingAddressId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddOrderMapping(this ModelBuilder builder) {
            builder.Entity<Order>(map => {
                map.ToTable(DbConst.Order_Table_Name)
                    .HasKey(_ => _.Id);

                map.Property(_ => _.ProductTitle).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.UnitName).HasMaxLength(300).IsUnicode();
                map.Property(_ => _.Quantity).HasDefaultValue(1);

                map.HasOne(_ => _.Product)
                    .WithMany(_ => _.Orders)
                    .HasForeignKey(_ => _.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.Shipping)
                    .WithMany(_ => _.Orders)
                    .HasForeignKey(_ => _.ShippingId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.ShippingAddress)
                    .WithMany(_ => _.Orders)
                    .HasForeignKey(_ => _.ShippingAddressId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddPaymentMapping(this ModelBuilder builder) {
            builder.Entity<Payment>(map => {
                map.ToTable(DbConst.Payment_Table_Name)
                    .HasKey(_ => _.Id);

                map.Property(_ => _.CustomerTitle).HasMaxLength(600).IsUnicode().IsRequired();
                map.Property(_ => _.TransactionId).HasMaxLength(500).IsUnicode();
                map.Property(_ => _.Method).HasDefaultValue(PaymentMethod.Online);

                map.HasOne(_ => _.Invoice)
                    .WithMany(_ => _.Payments)
                    .HasForeignKey(_ => _.InvoiceId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.Customer)
                    .WithMany(_ => _.Payments)
                    .HasForeignKey(_ => _.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
        }

        public static void AddProductMapping(this ModelBuilder builder) {
            builder.Entity<Product>(map => {
                map.ToTable(DbConst.Product_Table_Name)
                    .HasKey(_=> _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.Slug).HasMaxLength(2000).IsUnicode().IsRequired();
                map.Property(_ => _.ShortDescription).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Description).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Orderable).HasDefaultValue(true);
                map.Property(_ => _.Status).HasDefaultValue(ProductStatus.Enabled);
                map.Property(_ => _.UnitName).HasMaxLength(300).IsUnicode();
                map.Property(_ => _.Sku).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Size).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Color).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.MetaDescription).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.MetaRobots).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Template).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.BodyType).HasDefaultValue(PostBodyType.Html);

                map.HasOne(_ => _.Category)
                    .WithMany(_ => _.Products)
                    .HasForeignKey(_ => _.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.Vendor)
                    .WithMany(_ => _.Products)
                    .HasForeignKey(_ => _.VendorId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.Brand)
                    .WithMany(_ => _.Products)
                    .HasForeignKey(_ => _.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);
                    
            });
        }

        public static void AddProductMetaMapping(this ModelBuilder builder) {
            builder.Entity<ProductMeta>(map => {
                map.ToTable(DbConst.ProductMeta_Table_Name)
                    .HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.MetaKey).HasMaxLength(1000).IsRequired().IsUnicode();
                map.Property(_ => _.MetaValue).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Category).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.IconName).HasMaxLength(300).IsUnicode();
                map.Property(_ => _.CoverPhoto).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);
                map.Property(_ => _.OrderNumber).HasDefaultValue(0);

                map.HasOne(_ => _.Product)
                    .WithMany(_ => _.Meta)
                    .HasForeignKey(_ => _.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.Language)
                    .WithMany(_ => _.ProductMeta)
                    .HasForeignKey(_ => _.LangId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddProductPriceMapping(this ModelBuilder builder) {
            builder.Entity<ProductPrice>(map => {
                map.ToTable(DbConst.ProductPrice_Table_Name)
                    .HasKey(_ => _.Id);

                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);

                map.HasOne(_ => _.Product)
                    .WithMany(_ => _.PriceHistory)
                    .HasForeignKey(_ => _.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.CreatorUser)
                    .WithMany(_ => _.CreatedProductPrices)
                    .HasForeignKey(_ => _.CreatorUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.ModifierUser)
                    .WithMany(_ => _.ModifiedProductPrices)
                    .HasForeignKey(_ => _.ModifierUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddProductReviewMapping(this ModelBuilder builder) {
            builder.Entity<ProductReview>(map => {
                map.ToTable(DbConst.ProductReview_Table_Name)
                    .HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(300).IsUnicode();
                map.Property(_ => _.Body).HasMaxLength(4000).IsUnicode().IsRequired();
                map.Property(_ => _.BodyType).HasDefaultValue(PostBodyType.Html);
                map.Property(_ => _.Status).HasDefaultValue(ProductReviewStatus.Waiting);
                map.Property(_ => _.Ip).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.UserAgent).HasMaxLength(500).IsUnicode();
                map.Property(_ => _.SessionId).HasMaxLength(1000).IsUnicode();

                map.HasOne(_ => _.Product)
                    .WithMany(_ => _.Reviews)
                    .HasForeignKey(_ => _.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.Customer)
                    .WithMany(_ => _.Reviews)
                    .HasForeignKey(_ => _.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.ModifierUser)
                    .WithMany(_ => _.ModifiedProductReviews)
                    .HasForeignKey(_ => _.ModifierUserId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
        }

        public static void AddShippingMapping(this ModelBuilder builder) {
            builder.Entity<Shipping>(map => {
                map.ToTable(DbConst.Shipping_Table_Name)
                    .HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(300).IsUnicode().IsRequired();
                map.Property(_ => _.Description).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);

                map.HasData(new[] { 
                    new Shipping {
                        Id = 1,
                        Title = "پست",
                        CreateDate = DateTime.UtcNow,
                        IsFree = true,
                        ModifyDate = DateTime.UtcNow,
                        Status = EntityStatus.Enabled
                    }
                });

            });
        }

        public static void AddShippingAddressMapping(this ModelBuilder builder) {
            builder.Entity<ShippingAddress>(map => {
                map.ToTable(DbConst.ShippingAddress_Table_Name)
                    .HasKey(_ => _.Id);

                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);
                map.Property(_ => _.Address).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Street).HasMaxLength(300).IsUnicode();
                map.Property(_ => _.PostalCode).HasMaxLength(50).IsUnicode();

                map.HasOne(_ => _.Customer)
                    .WithMany(_ => _.ShippingAddresses)
                    .HasForeignKey(_ => _.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.City)
                    .WithMany(_ => _.ShippingAddresses)
                    .HasForeignKey(_ => _.CityId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddVendorMapping(this ModelBuilder builder) {
            builder.Entity<Vendor>(map => {
                map.ToTable(DbConst.Vendor_Table_Name)
                    .HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.Slug).HasMaxLength(2000).IsUnicode().IsRequired();
                map.Property(_ => _.Email).HasMaxLength(2000).IsUnicode().IsRequired();
                map.Property(_ => _.Website).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Description).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(VendorStatus.Enabled);

                map.HasOne(_ => _.User)
                    .WithMany(_ => _.Vendors)
                    .HasForeignKey(_ => _.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
        }
    }
}
