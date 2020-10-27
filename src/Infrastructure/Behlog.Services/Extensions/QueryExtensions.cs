using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Models.Content;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;

namespace Behlog.Services.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<Post> AddPublishedRules(this IQueryable<Post> query) {
            query = query
                .Where(_ => _.Status == PostStatus.Published)
                .Where(_ => _.PublishDate.HasValue && _.PublishDate.Value <= DateTime.UtcNow);
            return query;
        }

        public static IQueryable<Post> WithPostType(this IQueryable<Post> query, string postTypeSlug) {
            query = query
                .Where(_ => _.PostType.Slug == postTypeSlug);
            return query;
        }

        public static IQueryable<Post> WithPostType(this IQueryable<Post> query, int postTypeId) {
            query = query
                .Where(_ => _.PostTypeId == postTypeId);
            return query;
        }

        public static IQueryable<Post> HasLanguage(this IQueryable<Post> query, string langKey) {
            query = query
                .Where(_ => _.Language.LangKey == langKey);
            return query;
        }

        public static IQueryable<Post> HasLanguage(this IQueryable<Post> query, int langId) {
            query = query
                .Where(_ => _.LangId == langId);
            return query;
        }

        public static IQueryable<Post> HasCategory(this IQueryable<Post> query, string categorySlug) {
            query = query
                .Where(_ => _.Category.Slug.ToLower() == categorySlug.ToLower());
            return query;
        }

        public static IQueryable<Post> HasCategory(this IQueryable<Post> query, int categoryId) {
            query = query
                .Where(_ => _.CategoryId == categoryId);
            return query;
        }

        public static IQueryable<Post> BelongsToWebsite(
            this IQueryable<Post> query, int websiteId) {
            query = query
                .Where(_ => _.WebsiteId == websiteId);
            return query;
        }

        public static IQueryable<Post> IncludeFiles(this IQueryable<Post> query) {
            query = query
                .Include(_ => _.PostFiles)
                .ThenInclude(_ => _.File);
            return query;
        }

        public static IQueryable<Category> Enabled(this IQueryable<Category> query) {
            query = query
                .Where(_ => _.Status == EntityStatus.Enabled);
            return query;
        }
    }
}
