using System.Linq;
using Behlog.Core.Extensions;
using Behlog.Core.Models.System;
using Behlog.Core.Models.Content;
using Behlog.Services.Dto.System;
using Behlog.Services.Dto.Admin.Content;

namespace Behlog.Services.Extensions {
    
    public static class QueryFilter {

        public static IQueryable<Category> SetFilter(
            this IQueryable<Category> query,
            CategoryFilterDto filter) 
        {
            if (!string.IsNullOrWhiteSpace(filter.Title))
                query = query.Where(_ => _.Title.Contains(filter.Title));

            if (filter.LangId.HasValue)
                query = query.Where(_ => _.LangId == filter.LangId.Value);

            return query;
        }


        public static IQueryable<Post> SetFilter(
            this IQueryable<Post> query,
            AdminPostIndexFilter filter) {

            if (!filter.LangKey.IsNullOrEmpty())
                query = query.Where(_ => _.Language.LangKey.ToLower() == filter.LangKey.ToLower());

            if (!filter.Title.IsNullOrEmpty())
                query = query.Where(_ => _.Title.ToLower() == filter.Title.ToLower());

            if (filter.CategoryId.HasValue)
                query = query.Where(_ => _.CategoryId == filter.CategoryId.Value);

            if (filter.Status.HasValue)
                query = query.Where(_ => _.Status == filter.Status.Value);

            if (filter.UserId.HasValue)
                query = query.Where(_ => _.CreatorUserId == filter.UserId.Value
                    || _.ModifierUserId == filter.UserId.Value);

            return query;
        }
    }
}
