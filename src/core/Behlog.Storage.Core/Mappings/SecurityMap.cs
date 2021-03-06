using Microsoft.EntityFrameworkCore;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Security;

namespace Behlog.Storage.Core.Mappings {
    public static partial class TableMapper {

        public static void AddUserMapping(this ModelBuilder builder) {
            builder.Entity<User>(map => {
                map.ToTable(DbConst.User_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.UserName).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.PasswordHash).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.WebUrl).HasMaxLength(2000);
                map.Property(_ => _.Phone).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(UserStatus.Enabled);
                map.Property(_ => _.PhotoUrl).HasMaxLength(2000).IsUnicode();
                
            });
        }

        public static void AddUserLoginMapping(this ModelBuilder builder) {
            builder.Entity<UserLogin>(map => {
                map.ToTable(DbConst.UserLogin_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.UserAgent).HasMaxLength(500).IsUnicode();
                map.Property(_ => _.IP).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.ReferUrl).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.ExtraInfo).HasMaxLength(4000).IsUnicode();

                map.HasOne(_=> _.Website)
                    .WithMany(_ => _.Logins)
                    .HasForeignKey(_ => _.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_=> _.User)
                    .WithMany(_ => _.Logins)
                    .HasForeignKey(_ => _.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddUserClaimMapping(this ModelBuilder builder) {
            builder.Entity<UserClaim>(map => {
                map.ToTable(DbConst.UserClaim_Table_Name).HasKey(_ => _.Id);

                map.HasOne(_=> _.User)
                    .WithMany(_ => _.Claims)
                    .HasForeignKey(_ => _.UserId);
            });
        }

        public static void AddUserTokenMapping(this ModelBuilder builder) {
            builder.Entity<UserToken>(map => {
                map.ToTable(DbConst.UserToken_Table_Name);

                map.HasOne(_=> _.User)
                    .WithMany(_ => _.Tokens)
                    .HasForeignKey(_ => _.UserId);
            });
        }

        public static void AddRoleMapping(this ModelBuilder builder) {
            builder.Entity<Role>(map => {
                map.ToTable(DbConst.Role_Table_Name).HasKey(_ => _.Id);
                
            });
        }

        public static void AddUserRoleMapping(this ModelBuilder builder) {
            builder.Entity<UserRole>(map => {
                map.ToTable(DbConst.UserRole_Table_Name);

                map.HasOne(_=> _.Role)
                    .WithMany(_ => _.Users)
                    .HasForeignKey(_ => _.RoleId);

                map.HasOne(_=> _.User)
                    .WithMany(_ => _.Roles)
                    .HasForeignKey(_ => _.UserId);
            });
        }

        public static void AddRoleClaimMapping(this ModelBuilder builder) {
            builder.Entity<RoleClaim>(map => {
                map.ToTable(DbConst.RoleClaims_Table_Name).HasKey(_ => _.Id);

                map.HasOne(_=> _.Role)
                    .WithMany(_ => _.Claims)
                    .HasForeignKey(_ => _.RoleId);

            });
        }
    }
}
