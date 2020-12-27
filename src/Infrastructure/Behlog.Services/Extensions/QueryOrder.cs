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
                fieldName = "Id";

            fieldName = fieldName.ToLower();
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

                case "publishdate": return asc
                        ? query.OrderBy(_ => _.PublishDate)
                        : query.OrderByDescending(_ => _.PublishDate);

                case "slug": return asc
                        ? query.OrderBy(_ => _.Slug)
                        : query.OrderByDescending(_ => _.Slug);

                case "posttypeid": return asc
                        ? query.OrderBy(_ => _.PostTypeId)
                        : query.OrderByDescending(_ => _.PostTypeId);

                case "ordernumber": return asc
                        ? query.OrderBy(_ => _.OrderNumber)
                        : query.OrderByDescending(_ => _.OrderNumber);

                default:
                    return asc
                        ? query.OrderBy(_ => _.Id)
                        : query.OrderByDescending(_ => _.Id);
            }
        }


    }
}
