using System.Linq;
using System.Collections.Generic;
using Behlog.Core.Models.Content;
using Behlog.Services.Dto.Admin.Content;
using Behlog.Services.Dto.Content;
using Mapster;
using Behlog.Services.Extensions;

namespace Behlog.Services.Dto {

    public static class MappingConfig {

        public static void AddDtoMappingConfig() {
            TypeAdapterConfig<Post, PostResultDto>
                .NewConfig()
                .Map(d => d.PostTypeTitle, s => s.PostType.Title)
                .Map(d => d.PostTypeSlug, s => s.PostType.Slug)
                .Map(d => d.CategoryTitle, s => s.Category != null ? s.Category.Title : "")
                .Map(d => d.CategorySlug, s => s.Category != null ? s.Category.Slug : "")
                .Map(d => d.LangKey, s => s.Language != null ? s.Language.LangKey : "")
                .Map(d => d.LanguageTitle, s => s.Language != null ? s.Language.Title : "")
                .Map(d => d.Author, s => s.CreatorUser != null ? s.CreatorUser.Title : "")
                .Map(d => d.Tags, s => s.PostTags != null 
                    ? s.PostTags.ExtractTags() 
                    : new List<PostTagItemDto>());
            
            TypeAdapterConfig<Post, PostSummaryDto>
                .NewConfig()
                .Map(d => d.PostTypeSlug, s => s.PostType != null ? s.PostType.Slug : "")
                .Map(d => d.PostTypeTitle, s => s.PostType != null ? s.PostType.Title : "")
                .Map(d => d.Author, s => s.CreatorUser != null ? s.CreatorUser.Title : "")
                .Map(d => d.UserId, s => s.CreatorUser.Id);

            TypeAdapterConfig<Post, PostItemDto>
                .NewConfig()
                .Map(d => d.Author, s => s.CreatorUser != null ? s.CreatorUser.Title : "")
                .Map(d => d.PostTypeSlug, s => s.PostType != null ? s.PostType.Slug : "")
                .Map(d => d.CategoryTitle, s => s.Category != null ? s.Category.Title : "")
                .Map(d => d.CategorySlug, s => s.Category != null ? s.Category.Slug : "")
                .Map(d => d.Tags, s => s.PostTags != null
                     ? s.PostTags.ExtractTags()
                     : new List<PostTagItemDto>())
                ;

            TypeAdapterConfig<Comment, CommentResultDto>
                .NewConfig()
                .Map(d => d.UserTitle, s => s.User != null ? s.User.Title : "")
                .Map(d => d.PostTitle, s => s.Post != null ? s.Post.Title : "");

            TypeAdapterConfig<Post, AdminPostIndexItemDto>
                .NewConfig()
                .Map(d => d.LanguageTitle, s => s.Language != null ? s.Language.Title : "")
                .Map(d => d.LangKey, s => s.Language != null ? s.Language.LangKey : "")
                .Map(d => d.CategoryTitle, s => s.Category != null ? s.Category.Title : "")
                .Map(d => d.CreatorUserTitle, s => s.CreatorUser != null ? s.CreatorUser.Title : "")
                .Map(d => d.ModifierUserTitle, s => s.ModifierUser != null ? s.ModifierUser.Title : "")
                .Map(d => d.Tags, s => s.PostTags.Any() 
                    ? s.PostTags.Select(_ => _.Tag.Slug).ToList() 
                    : new List<string>());

            TypeAdapterConfig<Post, SearchResultItemDto>
                .NewConfig()
                .Map(d=> d.PostId, s => s.Id)
                .Map(d => d.CategoryTitle, s => s.CategoryId.HasValue ? s.Category.Title : "")
                .Map(d => d.LangTitle, s => s.Language != null ? s.Language.Title : "")
                .Map(d => d.LangKey, s => s.Language != null ? s.Language.LangKey : "")
                .Map(d => d.CreatorUserTitle, s => s.CreatorUser != null ? s.CreatorUser.Title : "")
                .Map(d => d.PostTypeSlug, s => s.PostType != null ? s.PostType.Slug : "")
                .Map(d => d.PostTypeTitle, s => s.PostType != null ? s.PostType.Title : "")
                .Map(d => d.Tags, s => s.PostTags.Any()
                     ? s.PostTags.Select(_ => _.Tag.Slug).ToList()
                     : new List<string>());
        }
    }
}
