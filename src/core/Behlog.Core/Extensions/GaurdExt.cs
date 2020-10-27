using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DNTPersianUtils.Core;

namespace Behlog.Core.Extensions {
    public static class GuardExt {

        /// <summary>
        /// Checks if the argument is null.
        /// </summary>
        public static void CheckArgumentIsNull(this object o, string name = "") {
            if (string.IsNullOrWhiteSpace(name))
                name = nameof(o);
            if (o == null)
                throw new ArgumentNullException(name);
        }

        public static void CheckReferenceIsNull(this object o, string name = "") {
            if (string.IsNullOrWhiteSpace(name))
                name = nameof(o);
            if (o == null)
                throw new NullReferenceException(name);
        }

        /// <summary>
        /// Checks if the parameter is null.
        /// </summary>
        public static void CheckMandatoryOption(this string s, string name) {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentException(name);
        }

        public static bool ContainsNumber(this string inputText) {
            return !string.IsNullOrWhiteSpace(inputText) && inputText.ToEnglishNumbers().Any(char.IsDigit);
        }

        public static bool HasConsecutiveChars(this string inputText, int sequenceLength = 3) {
            var charEnumerator = StringInfo.GetTextElementEnumerator(inputText);
            var currentElement = string.Empty;
            var count = 1;
            while (charEnumerator.MoveNext()) {
                if (currentElement == charEnumerator.GetTextElement()) {
                    if (++count >= sequenceLength) {
                        return true;
                    }
                }
                else {
                    count = 1;
                    currentElement = charEnumerator.GetTextElement();
                }
            }
            return false;
        }

        public static bool IsEmailAddress(this string inputText) {
            return !string.IsNullOrWhiteSpace(inputText) && new EmailAddressAttribute().IsValid(inputText);
        }

        public static bool IsNumeric(this string inputText) {
            if (string.IsNullOrWhiteSpace(inputText)) return false;
            return long.TryParse(inputText.ToEnglishNumbers(), out _);
        }

        public static string GetValidationErrors(this DbContext context) {
            var errors = new StringBuilder();
            var entities = context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .Select(e => e.Entity);
            foreach (var entity in entities) {
                var validationContext = new ValidationContext(entity);
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(entity, validationContext, validationResults, validateAllProperties: true)) {
                    foreach (var validationResult in validationResults) {
                        var names = validationResult.MemberNames.Aggregate((s1, s2) => $"{s1}, {s2}");
                        errors.AppendFormat("{0}: {1}", names, validationResult.ErrorMessage);
                    }
                }
            }

            return errors.ToString();
        }
    }

}
