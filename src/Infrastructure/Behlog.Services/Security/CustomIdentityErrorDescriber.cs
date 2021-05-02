using Microsoft.AspNetCore.Identity;

namespace Behlog.Services.Security
{
    /// <summary>
    /// More info: http://www.dotnettips.info/post/2582
    /// </summary>
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber {

        public override IdentityError ConcurrencyFailure()
            => new IdentityError {
                Code = nameof(ConcurrencyFailure),
                Description = "رکورد جاری پیشتر ویرایش شده‌است و تغییرات شما آن‌را بازنویسی خواهد کرد."
            };
        
        public override IdentityError DefaultError()
            => new IdentityError {
                Code = nameof(DefaultError),
                Description = "خطایی رخ داده‌است."
            };
        
        public override IdentityError DuplicateEmail(string email) 
            => new IdentityError {
                Code = nameof(DuplicateEmail),
                Description = string.Format("ایمیل '{0}' هم اکنون مورد استفاده است.", email)
            };

        public override IdentityError DuplicateRoleName(string role)
            => new IdentityError {
                Code = nameof(DuplicateRoleName),
                Description = string.Format("نقش '{0}' هم اکنون مورد استفاده‌است.", role)
            };

        public override IdentityError DuplicateUserName(string userName)
            => new IdentityError {
                Code = nameof(DuplicateUserName),
                Description = string.Format("نام کاربری '{0}' هم اکنون مورد استفاده‌است.", userName)
            };

        public override IdentityError InvalidEmail(string email)
            => new IdentityError {
                Code = nameof(InvalidEmail),
                Description = string.Format("ایمیل '{0}' معتبر نیست.", email)
            };

        public override IdentityError InvalidRoleName(string role)
            => new IdentityError {
                Code = nameof(InvalidRoleName),
                Description = string.Format("نقش '{0}' معتبر نیست.", role)
            };

        public override IdentityError InvalidToken()
            => new IdentityError {
                Code = nameof(InvalidToken),
                Description = "توکن غیر معتبر."
            };

        public override IdentityError InvalidUserName(string userName)
            => new IdentityError {
                Code = nameof(InvalidUserName),
                Description = string.Format("نام کاربری '{0}' معتبر نیست و تنها می‌تواند حاوی حروف و یا ارقام باشد.", userName)
            };

        public override IdentityError LoginAlreadyAssociated()
            => new IdentityError {
                Code = nameof(LoginAlreadyAssociated),
                Description = "این کاربر پیشتر اضافه شده‌است."
            };

        public override IdentityError PasswordMismatch()
            => new IdentityError {
                Code = nameof(PasswordMismatch),
                Description = "کلمه‌ی عبور نامعتبر."
            };

        public override IdentityError PasswordRequiresDigit()
            => new IdentityError {
                Code = nameof(PasswordRequiresDigit),
                Description = "کلمه‌ی عبور باید حداقل دارای یک رقم بین 0 تا 9 باشد."
            };

        public override IdentityError PasswordRequiresLower()
            => new IdentityError {
                Code = nameof(PasswordRequiresLower),
                Description = "کلمه‌ی عبور باید حداقل دارای یک حرف کوچک انگلیسی باشد."
            };

        public override IdentityError PasswordRequiresNonAlphanumeric()
            => new IdentityError {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "کلمه‌ی عبور باید حداقل دارای یک حرف خارج از حروف الفبای انگلیسی و همچنین اعداد باشد."
            };

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars) 
            => new IdentityError {
                Code = nameof(PasswordRequiresUniqueChars),
                Description = "کلمه‌ی عبور باید حداقل داراى {0} حرف متفاوت باشد."
            };

        public override IdentityError PasswordRequiresUpper() 
            => new IdentityError {
                Code = nameof(PasswordRequiresUpper),
                Description = "کلمه‌ی عبور باید حداقل دارای یک حرف بزرگ انگلیسی باشد."
            };

        public override IdentityError PasswordTooShort(int length) 
            => new IdentityError {
                Code = nameof(PasswordTooShort),
                Description = string.Format("کلمه‌ی عبور باید حداقل {0} حرف باشد.", length)
            };

        public override IdentityError RecoveryCodeRedemptionFailed()
            => new IdentityError {
                Code = nameof(RecoveryCodeRedemptionFailed),
                Description = "بازیابى با شکست مواجه شد."
            };

        public override IdentityError UserAlreadyHasPassword()
            => new IdentityError {
                Code = nameof(UserAlreadyHasPassword),
                Description = "کلمه‌ی عبور کاربر پیشتر تنظیم شده‌است."
            };

        public override IdentityError UserAlreadyInRole(string role)
            => new IdentityError {
                Code = nameof(UserAlreadyInRole),
                Description = string.Format("کاربر هم اکنون دارای نقش '{0}' است.", role)
            };

        public override IdentityError UserLockoutNotEnabled() 
            => new IdentityError {
                Code = nameof(UserLockoutNotEnabled),
                Description = "قفل شدن اکانت برای این کاربر تنظیم نشده‌است."
            };

        public override IdentityError UserNotInRole(string role)
            => new IdentityError {
                Code = nameof(UserNotInRole),
                Description = "کاربر دارای نقش '{0}' نیست."
            };

    }
}
