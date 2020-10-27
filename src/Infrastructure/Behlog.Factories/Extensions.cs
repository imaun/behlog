using Behlog.Core.Models.Content;
using Behlog.Core.Utils;
using Behlog.Services.Dto.Content;
using Behlog.Core.Models.Enum;
using Behlog.Core.Utils.IO;

namespace Behlog.Factories.Extensions
{
    public static class Extensions
    {
        public static void GetData(this Post post, PostEditDto data) {
            post.LangId = data.LangId;
            post.Commenting = data.Commenting;
            post.AltTitle = data.AltTitle;
            post.Password = data.Password;
            post.Summary = data.Summary;
            post.OrderNumber = data.OrderNumber;
            post.Body = data.Body;
            post.CategoryId = data.CategoryId;
            post.CoverPhoto = data.CoverPhoto;
            post.LayoutId = data.LayoutId;
            post.ParentId = data.ParentId;
            post.Title = data.Title;
            post.Status = data.Status;
            post.Slug = !string.IsNullOrWhiteSpace(data.Slug) 
                ? data.Slug.MakeSlug() 
                : data.Title.MakeSlug();
            post.PublishDate = data.PublishDate;
        }

        public static PostFileType GetPostFileType(this string filePath) {
            if (filePath.IsImage())
                return PostFileType.Image;

            if (filePath.IsAudio())
                return PostFileType.Audio;

            if (filePath.IsDocument())
                return PostFileType.Document;

            if (filePath.IsVideo())
                return PostFileType.Video;

            return PostFileType.Common;
        }



    }
}
