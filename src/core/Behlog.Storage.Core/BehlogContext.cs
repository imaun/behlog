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

        //Contents
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

        //Features
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<FormField> FormFields { get; set; }
        public virtual DbSet<FormFieldItem> FormFieldItems { get; set; }
        public virtual DbSet<FormFieldValue> FormFieldValues { get; set; }
        public virtual DbSet<PostVisit> PostVisits { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }
        public virtual DbSet<WebsiteVisit> WebsiteVisits { get; set; }

        //Security
        


        //System
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Layout> Layouts { get; set; }
        public virtual DbSet<Menu> MenuItems { get; set; }
        public virtual DbSet<PostType> PostTypes { get; set; } 
        public virtual DbSet<Website> Websites { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<UserMeta> UserMeta { get; set; }
        public virtual DbSet<WebsiteOption> Options { get; set; }

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

            builder.AddCategoryMapping();
            builder.AddCommentMapping();
            builder.AddContactMapping();
            builder.AddFileMapping();
            builder.AddFormFieldItemMapping();
            builder.AddFormFieldMapping();
            builder.AddFormFieldValueMapping();
            builder.AddFormMapping();
            builder.AddLanguageMapping();
            builder.AddLayoutMapping();
            builder.AddLinkMapping();
            builder.AddMenuMapping();
            builder.AddPostFileMapping();
            builder.AddPostLikeMapping();
            builder.AddPostMapping();
            builder.AddLanguageMapping();
            builder.AddPostMetaMapping();
            builder.AddPostTagMapping();
            builder.AddPostTypeMapping();
            builder.AddPostVisitMapping();
            builder.AddTagMapping();
            builder.AddUserMapping();
            builder.AddUserLoginMapping();
            builder.AddUserClaimMapping();
            builder.AddUserTokenMapping();
            builder.AddUserMetaMapping();
            builder.AddUserRoleMapping();
            builder.AddRoleMapping();
            builder.AddRoleClaimMapping();
            builder.AddWebsiteMapping();
            builder.AddWebsiteVisitMapping();
            builder.AddWebsiteOptionMapping();
            builder.AddErrorLogMapping();
            builder.AddSectionGroupMapping();
            builder.AddSectionMapping();
            builder.AddSubscriberMapping();

        }

        #endregion
    }
}
