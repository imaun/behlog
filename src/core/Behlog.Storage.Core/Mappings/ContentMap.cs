using Microsoft.EntityFrameworkCore;
using Behlog.Core.Models.Content;
using Behlog.Core.Models.Enum;

namespace Behlog.Storage.Core.Mappings {
    public static partial class TableMapper {

        public static void AddCommentMapping(this ModelBuilder builder) {
            builder.Entity<Comment>(map => {

                map.ToTable(DbConst.Comment_Table_Name);
                map.HasKey(_ => _.Id);
                map.Property(_ => _.Title).HasMaxLength(1000).IsRequired().IsUnicode();
                map.Property(_ => _.Email).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.WebUrl).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Body).HasMaxLength(4000).IsRequired().IsUnicode();
                map.Property(_ => _.IP).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.UserAgent).HasMaxLength(500).IsUnicode();
                map.Property(_ => _.SessionId).HasMaxLength(2000).IsRequired();

                map.HasOne(_=> _.User)
                    .WithMany(__ => __.Comments)
                    .HasForeignKey(_ => _.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.ModifierUser)
                    .WithMany(__ => __.ModifiedComments)
                    .HasForeignKey(_ => _.ModifierUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_=> _.Post)
                    .WithMany(__ => __.Comments)
                    .HasForeignKey(_ => _.PostId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
        }

        public static void AddFileMapping(this ModelBuilder builder) {
            builder.Entity<File>(map => {
                map.ToTable(DbConst.File_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.FilePath).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Url).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Extension).HasMaxLength(20);
                map.Property(_ => _.Description).HasMaxLength(1000).IsUnicode();

                map.HasOne(_=> _.Website)
                    .WithMany(_ => _.Files)
                    .HasForeignKey(_ => _.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddLinkMapping(this ModelBuilder builder) {
            builder.Entity<Link>(map => {

                map.ToTable(DbConst.Link_Table_Name);
                map.HasKey(_ => _.Id);
                map.Property(_ => _.Title).IsRequired().HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Url).IsRequired().HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Target).HasMaxLength(100);
                map.Property(_ => _.Description).HasMaxLength(2000).IsUnicode();

                map.HasOne(_=> _.Category)
                    .WithMany(_ => _.Links)
                    .HasForeignKey(_ => _.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_=> _.Website)
                    .WithMany(_ => _.Links)
                    .HasForeignKey(_ => _.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddPostMapping(this ModelBuilder builder) {
            builder.Entity<Post>(map => {
                map.ToTable(DbConst.Post_Table_Name).HasKey(_=> _.Id);

                map.Property(_ => _.Title).IsRequired().HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Slug).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Body).HasColumnType("nTEXT");
                map.Property(_ => _.Summary).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Password).HasMaxLength(100);
                map.Property(_ => _.CoverPhoto).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.CategoryPath).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.AltTitle).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.IconName).HasMaxLength(300).IsUnicode();
                map.Property(_ => _.Template).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.ViewPath).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.MetaDescription).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.MetaRobots).HasMaxLength(100).IsUnicode();

                map.HasOne(_=> _.Website)
                    .WithMany(_ => _.Posts)
                    .HasForeignKey(_ => _.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_=> _.CreatorUser)
                    .WithMany(_ => _.CreatedPosts)
                    .HasForeignKey(_ => _.CreatorUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_=> _.ModifierUser)
                    .WithMany(_ => _.ModifiedPosts)
                    .HasForeignKey(_ => _.ModifierUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_=> _.PostType)
                    .WithMany(_ => _.Posts)
                    .HasForeignKey(_ => _.PostTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_=> _.Language)
                    .WithMany(_ => _.Posts)
                    .HasForeignKey(_ => _.LangId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_=> _.Category)
                    .WithMany(_ => _.Posts)
                    .HasForeignKey(_ => _.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_=> _.Layout)
                    .WithMany(_ => _.Posts)
                    .HasForeignKey(_ => _.LayoutId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddPostFileMapping(this ModelBuilder builder) {
            builder.Entity<PostFile>(map => {
                map.ToTable(DbConst.PostFile_Table_Name).HasKey(_ => _.Id);
                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode();

                map.HasOne(_=> _.Post)
                    .WithMany(_ => _.PostFiles)
                    .HasForeignKey(_ => _.PostId)
                    .OnDelete(DeleteBehavior.Cascade);

                map.HasOne(_=> _.File)
                    .WithMany(_ => _.PostFiles)
                    .HasForeignKey(_ => _.FileId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddPostLikeMapping(this ModelBuilder builder) {

            builder.Entity<PostLike>(map => {
                map.ToTable(DbConst.PostLike_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.SessionId).HasMaxLength(2000).IsRequired();
                map.Property(_ => _.IP).HasMaxLength(100);

                map.HasOne(_=> _.User)
                    .WithMany(_ => _.Likes)
                    .HasForeignKey(_ => _.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                map.HasOne(_=> _.Post)
                    .WithMany(_ => _.Likes)
                    .HasForeignKey(_ => _.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
                
            });
        }

        public static void AddPostMetaMapping(this ModelBuilder builder) {
            builder.Entity<PostMeta>(map => {
                map.ToTable(DbConst.PostMeta_Table_Name).HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.MetaKey).HasMaxLength(1000).IsRequired().IsUnicode();
                map.Property(_ => _.MetaValue).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Category).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.IconName).HasMaxLength(300).IsUnicode();
                map.Property(_ => _.CoverPhoto).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Status).HasDefaultValue(EntityStatus.Enabled);
                map.Property(_ => _.OrderNumber).HasDefaultValue(0);

                map.HasOne(_=> _.Post)
                    .WithMany(_ => _.Meta)
                    .HasForeignKey(_ => _.PostId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                map.HasOne(_=> _.Language)
                    .WithMany(_ => _.PostMeta)
                    .HasForeignKey(_ => _.LangId)
                    .OnDelete(DeleteBehavior.Cascade);
                
            });
        }

        public static void AddPostTagMapping(this ModelBuilder builder) {
            builder.Entity<PostTag>(map => {
                map.ToTable(DbConst.PostTag_Table_Name)
                    .HasKey(_=> new { _.PostId, _.TagId });

                map.HasOne(_=> _.Post)
                    .WithMany(_ => _.PostTags)
                    .HasForeignKey(_ => _.PostId)
                    .OnDelete(DeleteBehavior.Cascade);

                map.HasOne(_=> _.Tag)
                    .WithMany(_ => _.PostTags)
                    .HasForeignKey(_ => _.TagId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
        }

        public static void AddSectionGroupMapping(this ModelBuilder builder) {
            builder.Entity<SectionGroup>(map => {
                map.ToTable(DbConst.SectionGroup_Table_Name)
                    .HasKey(_ => _.Id);

                map.HasOne(_ => _.Website)
                    .WithMany(_ => _.SectionGroups)
                    .HasForeignKey(_ => _.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.Parent)
                    .WithMany(_ => _.SubGroups)
                    .HasForeignKey(_ => _.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
        }

        public static void AddSectionMapping(this ModelBuilder builder) {
            builder.Entity<Section>(map => {
                map.ToTable(DbConst.Section_Table_Name)
                    .HasKey(_ => _.Id);

                map.HasOne(_ => _.SectionGroup)
                    .WithMany(_ => _.Sections)
                    .HasForeignKey(_ => _.SectionGroupId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.RelatedSection)
                    .WithMany(_ => _.RelatedSections)
                    .HasForeignKey(_ => _.RelatedSectionId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.RelatedPost) //TODO : think about this relationship before Add-Migrations
                    .WithMany(_ => _.RelatedSections)
                    .HasForeignKey(_ => _.RelatedPostId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.Language)
                    .WithMany(_ => _.Sections)
                    .HasForeignKey(_ => _.LangId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

    }
}
