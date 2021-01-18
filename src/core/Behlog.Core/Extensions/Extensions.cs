using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Behlog.Core.Models.Enum;
using DNTPersianUtils.Core;

namespace Behlog.Core.Extensions {
    public static class Extensions
    {

        private static readonly System.Type _typeOfString = typeof(string);

        public const char ArabicYeChar = (char)1610;
        public const char PersianYeChar = (char)1740;

        public const char ArabicKeChar = (char)1603;
        public const char PersianKeChar = (char)1705;

        public static string ApplyCorrectYeKe(this string data) {
            return string.IsNullOrWhiteSpace(data) ?
                data :
                data.Replace(ArabicYeChar, PersianYeChar)
                    .Replace(ArabicKeChar, PersianKeChar)
                    .Trim();
        }

        public static void CorrectYeKe(this DbContext dbContext) {
            if (dbContext == null)
                return;

            var changedEntities = dbContext.ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var item in changedEntities) {
                if (item.Entity == null)
                    continue;

                var propertyInfos = item.Entity.GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == _typeOfString);

                var propertyReflector = new PropertyReflector();

                foreach (var propertyInfo in propertyInfos) {
                    var propName = propertyInfo.Name;
                    var value = propertyReflector.GetValue(item.Entity, propName);
                    if (value != null) {
                        var strValue = value.ToString();
                        var newVal = strValue.ApplyCorrectYeKe();
                        if (newVal == strValue)
                            continue;

                        propertyReflector.SetValue(item.Entity, propName, newVal);
                    }
                }
            }
        }

        public static string ToText(this EntityStatus status) 
            => status switch
            {
                EntityStatus.Enabled => "فعال",
                EntityStatus.Disabled => "غیرفعال",
                EntityStatus.Deleted => "حذف شده",
                _ => "نامشخص",
            };
        
        public static bool IsNullOrEmpty(this string value)
            => string.IsNullOrWhiteSpace(value);

        public static bool IsNotNullOrEmpty(this string value)
            => !IsNullOrEmpty(value);
    }
}
