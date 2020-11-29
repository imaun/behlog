using Microsoft.EntityFrameworkCore;
using Behlog.Core.Models.Feature;
using Behlog.Core.Models.Enum;

namespace Behlog.Storage.Core.Mappings {
    public static partial class TableMapper {

        public static void AddContactMapping(this ModelBuilder builder) {
            builder.Entity<Contact>(map => {
                map.ToTable(DbConst.Contact_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Name).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Email).HasMaxLength(2000).IsUnicode().IsRequired();
                map.Property(_ => _.Phone).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Message).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Ip).HasMaxLength(100).IsUnicode().IsRequired();
                map.Property(_ => _.UserAgent).HasMaxLength(500).IsUnicode();
                map.Property(_ => _.Title).HasMaxLength(300).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(ContactMessageStatus.Sent);

                map.HasOne(_=> _.Website)
                    .WithMany(_ => _.Contacts)
                    .HasForeignKey(_ => _.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddFormMapping(this ModelBuilder builder) {
            builder.Entity<Form>(map => {
                map.ToTable(DbConst.Form_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsRequired().IsUnicode();
                map.Property(_ => _.Name).HasMaxLength(1000).IsRequired().IsUnicode();
                map.Property(_ => _.Description).HasMaxLength(2000).IsUnicode();

                map.HasOne(_=> _.Website)
                    .WithMany(_ => _.Forms)
                    .HasForeignKey(_ => _.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddFormFieldMapping(this ModelBuilder builder) {
            builder.Entity<FormField>(map => {
                map.ToTable(DbConst.FormField_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Name).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.Description).HasMaxLength(2000).IsUnicode();

                map.HasOne(_=> _.Form)
                    .WithMany(_ => _.Fields)
                    .HasForeignKey(_ => _.FormId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddFormFieldItemMapping(this ModelBuilder builder) {
            builder.Entity<FormFieldItem>(map => {
                map.ToTable(DbConst.FormFieldItem_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.Value).HasMaxLength(1000).IsUnicode();

                map.HasOne(_=> _.Field)
                    .WithMany(_ => _.Items)
                    .HasForeignKey(_ => _.FormFieldId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddFormFieldValueMapping(this ModelBuilder builder) {
            builder.Entity<FormFieldValue>(map => {
                map.ToTable(DbConst.FormFieldValue_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.TextValue).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.SelectedValue).HasMaxLength(1000).IsUnicode();

                map.HasOne(_=> _.Field)
                    .WithMany(_ => _.Values)
                    .HasForeignKey(_ => _.FormFieldId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_=> _.FieldItem)
                    .WithMany(_ => _.Values)
                    .HasForeignKey(_ => _.FormFieldItemId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddPostVisitMapping(this ModelBuilder builder) {
            builder.Entity<PostVisit>(map => {
                map.ToTable(DbConst.PostVisit_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.SessionId).HasMaxLength(1000).IsRequired();
                map.Property(_ => _.AbseloutUrl).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.UrlReferrer).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.IP).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.UserAgent).HasMaxLength(500);
                map.Property(_ => _.OsPlatform).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Country).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.City).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Region).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Description).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.PostTitle).HasMaxLength(2000).IsUnicode();

                map.HasOne(_=> _.Post)
                    .WithMany(_ => _.Visits)
                    .HasForeignKey(_ => _.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public static void AddWebsiteVisitMapping(this ModelBuilder builder) {
            builder.Entity<WebsiteVisit>(map => {
                map.ToTable(DbConst.WebsiteVisit_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.SessionId).HasMaxLength(1000).IsRequired();
                map.Property(_ => _.AbseloutUrl).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.UrlReferrer).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.IP).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.UserAgent).HasMaxLength(500);
                map.Property(_ => _.OsPlatform).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Country).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.City).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Region).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Description).HasMaxLength(2000).IsUnicode();

                map.HasOne(_=> _.Website)
                    .WithMany(_ => _.Visits)
                    .HasForeignKey(_ => _.WebsiteId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public static void AddSubscriberMapping(this ModelBuilder builder) {
            builder.Entity<Subscriber>(map => {
                map.ToTable(DbConst.Subscription_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Email).HasMaxLength(1000).IsRequired().IsUnicode();
                map.Property(_ => _.Name).HasMaxLength(300).IsUnicode();

                map.HasOne(_ => _.Website)
                    .WithMany(_ => _.Subscribers)
                    .HasForeignKey(_ => _.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
