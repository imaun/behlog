using System.Linq;
using Behlog.Core.Models.System;
using Behlog.Core.Models.Content;

namespace Behlog.Services.Extensions
{
    public static class QueryOrder
    {

        public static IQueryable<Category> SetOrder(
            this IQueryable<Category> query, 
            string fieldName, 
            bool asc = true) 
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                return query;

            switch (fieldName.ToLower()) {
                case "title": return asc
                        ? query.OrderBy(_ => _.Title)
                        : query.OrderByDescending(_ => _.Title);

                case "slug": return asc
                        ? query.OrderBy(_ => _.Slug)
                        : query.OrderByDescending(_ => _.Slug);

                case "status": return asc
                        ? query.OrderBy(_ => _.Status)
                        : query.OrderByDescending(_ => _.Status);

                default:
                    return asc
                        ? query.OrderBy(_ => _.Id)
                        : query.OrderByDescending(_ => _.Id);
            }
        }


        public static IQueryable<Post> SetOrder(
            this IQueryable<Post> query,
            string fieldName,
            bool asc = true) {
            if (string.IsNullOrWhiteSpace(fieldName))
                return query;

            switch(fieldName) {
                case "title": return asc
                        ? query.OrderBy(_ => _.Title)
                        : query.OrderByDescending(_ => _.Title);

                case "ordernum": return asc
                        ? query.OrderBy(_ => _.OrderNumber)
                        : query.OrderByDescending(_ => _.OrderNumber);

                case "status": return asc
                        ? query.OrderBy(_ => _.Status)
                        : query.OrderByDescending(_ => _.Status);

                default:
                    return asc
                        ? query.OrderBy(_ => _.Id)
                        : query.OrderByDescending(_ => _.Id);
            }
        }


    }
}
