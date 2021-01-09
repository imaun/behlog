using Microsoft.EntityFrameworkCore;
using Behlog.Core.Models.System;
using Behlog.Core.Models.Enum;
using Behlog.Storage.Core.Internal;

namespace Behlog.Storage.Core.Mappings {
    public partial class TableMapper {

        public static void AddCategoryMapping(this ModelBuilder builder) {
            builder.Entity<Category>(map => {
                map.ToTable(DbConst.Category_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.Description).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Slug).HasMaxLength(2000).IsUnicode().IsRequired();
                map.Property(_ => _.TreePath).HasMaxLength(4000).IsUnicode();

                map.HasOne(_=> _.Website)
                    .WithMany(__ => __.Categories)
                    .HasForeignKey(_ => _.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_=> _.PostType)
                    .WithMany(__ => __.Categories)
                    .HasForeignKey(_ => _.PostTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_=> _.Language)
                    .WithMany(__ => __.Categories)
                    .HasForeignKey(_ => _.LangId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
        
        public static void AddCityMapping(this ModelBuilder builder) {
            builder.Entity<City>(map => {
                map.ToTable(DbConst.City_Table_Name)
                    .HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(500).IsUnicode().IsRequired();
                map.Property(_ => _.Code).HasMaxLength(50).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);
                map.Property(_ => _.Kind).HasDefaultValue(CityType.City);
                map.Property(_ => _.Description).HasMaxLength(1000).IsUnicode();

                map.HasData(CityDataProvider.GetIranCities());
            });
        }

        public static void AddCurrencyMapping(this ModelBuilder builder) {
            builder.Entity<Currency>(map => {
                map.ToTable(DbConst.Currency_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(100).IsUnicode().IsRequired();
                map.Property(_ => _.Sign).HasMaxLength(50).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);
                map.Property(_ => _.Description).HasMaxLength(1000).IsUnicode();

                map.HasData(new[] {
                    new Currency {
                        Id = 1,
                        Title = "ریال",
                        Sign = "ریال",
                        IsBase = true,
                        Rate = 1,
                        Status = EntityStatus.Enabled
                    },
                    new Currency {
                        Id = 2,
                        Title = "تومان",
                        Sign = "T",
                        IsBase = false,
                        Rate = 0.1m,
                        Status = EntityStatus.Enabled
                    }
                });

            });
        }

        public static void AddLanguageMapping(this ModelBuilder builder) {
            builder.Entity<Language>(map => {
                map.ToTable(DbConst.Language_Table_Name).HasKey(_ => _.Id);
                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.LangKey).HasMaxLength(20).IsUnicode().IsRequired();
                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);
            });
        }

        public static void AddLayoutMapping(this ModelBuilder builder) {
            builder.Entity<Layout>(map => {
                map.ToTable(DbConst.Layout_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.Name).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.Description).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Author).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.AuthorEmail).HasMaxLength(2000).IsUnicode().IsRequired();
                map.Property(_ => _.AuthorWebUrl).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Path).HasMaxLength(2000).IsUnicode().IsRequired();
                map.Property(_ => _.OrderNumber).HasDefaultValue(1);
                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);
                
            });
        }

        public static void AddMenuMapping(this ModelBuilder builder) {
            builder.Entity<Menu>(map => {
                map.ToTable(DbConst.Menu_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(2000).IsUnicode().IsRequired();
                map.Property(_ => _.Description).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Url).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Action).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Controller).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Parameters).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);
                map.Property(_ => _.CssClass).HasMaxLength(500).IsUnicode();
                map.Property(_ => _.CssStyle).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Target).HasMaxLength(200).IsUnicode();

                map.HasOne(_=> _.Website)
                    .WithMany(__ => __.MenuItems)
                    .HasForeignKey(_ => _.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.Language)
                    .WithMany(__ => __.MenuItems)
                    .HasForeignKey(_ => _.LangId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddPostTypeMapping(this ModelBuilder builder) {
            builder.Entity<PostType>(map => {
                map.ToTable(DbConst.PostType_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(500).IsUnicode().IsRequired();
                map.Property(_ => _.Description).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Slug).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);

                map.HasData(new[] {
                    new PostType {
                        Id = 1, Title = "Page", Status = EntityStatus.Enabled, Slug = "page"
                    },
                    new PostType {
                        Id = 2, Title = "Blog", Status = EntityStatus.Enabled, Slug = "blog"
                    },
                    new PostType {
                        Id = 3, Title = "Product", Status = EntityStatus.Enabled, Slug = "product"
                    },
                    new PostType {
                        Id = 4, Title = "Service", Status = EntityStatus.Enabled, Slug = "service"
                    },
                    new PostType {
                        Id = 5, Title = "Gallery", Status = EntityStatus.Enabled, Slug = "gallery"
                    },
                    new PostType {
                        Id = 6, Title = "Article", Status = EntityStatus.Enabled, Slug = "article"
                    },
                    new PostType {
                        Id = 7, Title = "News", Status = EntityStatus.Enabled, Slug = "news"
                    },
                    new PostType {
                        Id = 8, Title = "Links", Status = EntityStatus.Enabled, Slug = "link"
                    }
                });
            });
        }

        public static void AddTagMapping(this ModelBuilder builder) {
            builder.Entity<Tag>(map => {
                map.ToTable(DbConst.Tag_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.Slug).HasMaxLength(2000).IsUnicode().IsRequired();
                map.Property(_ => _.Description).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);


                map.HasOne(_ => _.Website)
                    .WithMany(_ => _.Tags)
                    .HasForeignKey(_ => _.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddUserMetaMapping(this ModelBuilder builder) {
            builder.Entity<UserMeta>(map => {
                map.ToTable(DbConst.UserMeta_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.MetaKey).HasMaxLength(255).IsUnicode().IsRequired();
                map.Property(_ => _.MetaValue).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Category).HasMaxLength(255).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);

                map.HasOne(_=> _.User)
                    .WithMany(_ => _.Meta)
                    .HasForeignKey(_ => _.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_=> _.Language)
                    .WithMany(_ => _.UserMeta)
                    .HasForeignKey(_ => _.LangId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(false);
            });
        }

        public static void AddWebsiteMapping(this ModelBuilder builder) {
            builder.Entity<Website>(map => {
                map.ToTable(DbConst.Website_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.Description).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Keywords).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Url).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);

                map.HasOne(_=> _.Owner)
                    .WithMany(_ => _.Websites)
                    .HasForeignKey(_ => _.OwnerId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_=> _.DefaultLanguage)
                    .WithMany(_ => _.Websites)
                    .HasForeignKey(_ => _.DefaultLangId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.Layout)
                    .WithMany(_ => _.Websites)
                    .HasForeignKey(_ => _.LayoutId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.DefaultCurrency)
                    .WithMany(_ => _.WebsitesHasThisAsDefault)
                    .HasForeignKey(_ => _.DefaultCurrencyId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.DefaultShipping)
                    .WithMany(_ => _.WebsitesHasThisAsDefaultShipping)
                    .HasForeignKey(_ => _.DefaultShippingId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }

        public static void AddWebsiteOptionMapping(this ModelBuilder builder) {
            builder.Entity<WebsiteOption>(map => {
                map.ToTable(DbConst.WebsiteOptions_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.Key).HasMaxLength(255).HasColumnName("Option_Key").IsUnicode().IsRequired();
                map.Property(_ => _.Value).HasMaxLength(4000).HasColumnName("Option_Value").IsUnicode();
                map.Property(_ => _.Category).HasMaxLength(255).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);
                map.Property(_ => _.Description).HasMaxLength(2000).IsUnicode();

                map.HasOne(_=> _.Website)
                    .WithMany(_ => _.Options)
                    .HasForeignKey(_ => _.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.Language)
                    .WithMany(_ => _.Options)
                    .HasForeignKey(_ => _.LangId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }

        public static void AddErrorLogMapping(this ModelBuilder builder) {
            builder.Entity<ErrorLog>(map => {
                map.ToTable(DbConst.ErrorLogs_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Exception).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.StackTrace).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.RequestUrl).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Ip).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.UserAgent).HasMaxLength(300).IsUnicode();

                map.HasOne(_ => _.Website)
                    .WithMany(_ => _.Errors)
                    .HasForeignKey(_ => _.WebsiteId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        
    }
}
