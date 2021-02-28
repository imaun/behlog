using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Core.Contracts.Repository.Content;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Content;
using Behlog.Core.Models.Enum;
using Behlog.Core.Security;
using Behlog.Core.Utils;
using Behlog.Factories.Contracts.Content;
using Behlog.Factories.Contracts.System;
using Behlog.Factories.Extensions;
using Behlog.Services.Dto.Content;
using Mapster;

namespace Behlog.Factories.Content {

    public class PostFactory : IPostFactory {

        private readonly IDateService _dateService;
        private readonly IUserContext _userContext;
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ITagFactory _tagFactory;
        private readonly IWebsiteInfo _websiteInfo;

        public PostFactory(
            IDateService dateService,
            IUserContext userContext,
            IPostRepository postRepository,
            ITagRepository tagRepository,
            ITagFactory tagFactory,
            IWebsiteInfo websiteInfo
        ) {
            dateService.CheckArgumentIsNull();
            _dateService = dateService;

            userContext.CheckArgumentIsNull();
            _userContext = userContext;

            postRepository.CheckArgumentIsNull();
            _postRepository = postRepository;

            tagRepository.CheckArgumentIsNull(nameof(tagRepository));
            _tagRepository = tagRepository;

            tagFactory.CheckArgumentIsNull(nameof(tagFactory));
            _tagFactory = tagFactory;

            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;
        }

        public async Task<Post> MakeAsync(PostCreateDto model) {
            model.CheckArgumentIsNull();

            var post = model.Adapt<Post>();
            post.CreateDate = post.ModifyDate = _dateService.UtcNow();
            post.CreatorUserId = _userContext.UserId;
            post.WebsiteId = _userContext.WebsiteId;
            if (string.IsNullOrWhiteSpace(model.Slug))
                post.Slug = model.Title;
            post.Slug = post.Slug.MakeSlug();

            if (post.Status == PostStatus.Published || post.Status == PostStatus.Planned)
                post.PublishDate = model.PublishDate;
            else
                post.PublishDate = null;

            if(!model.Tags.IsNullOrEmpty())
                foreach (var tag in model.Tags.Split(',')) {
                    var existingTag = await _tagRepository.GetByTitleAsync(tag, _websiteInfo.Id);
                    if (existingTag != null) {
                        post.PostTags.Add(new PostTag {
                            TagId = existingTag.Id
                        });
                    }
                    else {
                        var newTag = await _tagFactory.MakeAsync(tag);
                        await _tagRepository.AddAndSaveAsync(newTag);
                        post.PostTags.Add(new PostTag {
                            TagId = newTag.Id
                        });
                    }
                }

            return post;
        }

        public async Task<Post> MakeAsync(PostEditDto model) {
            model.CheckArgumentIsNull();
            var post = await _postRepository.FindAsync(model.Id);
            post.GetData(model);
            post.ModifyDate = _dateService.UtcNow();
            post.ModifierUserId = _userContext.UserId;

            if (post.Status == PostStatus.Published || post.Status == PostStatus.Planned)
                post.PublishDate = model.PublishDate;
            else
                post.PublishDate = null;

            return await Task.FromResult(post);
        }

        public async Task<Post> MarkAsDeletedAsync(int postId) {
            var post = await _postRepository.FindAsync(postId);
            post.CheckReferenceIsNull();
            post.Status = PostStatus.Deleted;

            return await Task.FromResult(post);
        }

        public async Task<Post> MakeSliderPostAsync(
            string title, 
            string slug, 
            int langId, 
            bool enabled) {

            var post = new Post {
                Title = title.ApplyCorrectYeKe(),
                Slug = slug,
                LangId = langId,
                Status = enabled ? PostStatus.Published : PostStatus.Draft,
                CreateDate = _dateService.UtcNow(),
                ModifyDate = _dateService.UtcNow(),
                WebsiteId = _userContext.WebsiteId,
                CreatorUserId = _userContext.UserId,
                ModifierUserId = _userContext.UserId,
            };

            if (post.Slug.IsNotNullOrEmpty())
                post.Slug = title.MakeSlug();
            else
                post.Slug = slug.MakeSlug();

            if (enabled)
                post.PublishDate = _dateService.UtcNow();

            return await Task.FromResult(post);
        }
    }
}
