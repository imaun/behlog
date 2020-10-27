using Behlog.Core.Models.Enum;
using Behlog.Resources.Strings;

namespace Behlog.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string ToDisplay(this PostStatus status) {
            switch (status) {
                case PostStatus.Deleted: return AppTextDisplay.PostStatusDeleted;
                case PostStatus.Draft: return AppTextDisplay.PostStatusDraft;
                case PostStatus.Planned: return AppTextDisplay.PostStatusPlanned;
                case PostStatus.Published: return AppTextDisplay.PostStatusPublished;
                default: return AppTextDisplay.StatusUnknown;
            }
        }


    }
}
