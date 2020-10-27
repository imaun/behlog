using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Utils;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;
using Behlog.Core.Security;
using Behlog.Factories.Contracts.System;
using Behlog.Services.Dto.System;
using Behlog.Core.Extensions;
using Mapster;

namespace Behlog.Factories.System
{
    public class CategoryFactory: ICategoryFactory
    {
        private readonly IDateService _dateService;
        private readonly IUserContext _userContext;
        private readonly ICategoryRepository _repo;

        public CategoryFactory(
            IDateService dateService,
            IUserContext userContext,
            ICategoryRepository repo
        ) {
            dateService.CheckArgumentIsNull();
            _dateService = dateService;

            userContext.CheckArgumentIsNull();
            _userContext = userContext;

            repo.CheckArgumentIsNull();
            _repo = repo;
        }

        public Category Make(CategoryCreateDto model) {
            var result = model.Adapt<Category>();
            result.Slug = result.Slug.MakeSlug();
            result.CreatorUserId = _userContext.UserId;
            result.CreateDate = result.ModifyDate = _dateService.UtcNow();
            result.WebsiteId = _userContext.WebsiteId;

            return result;
        }

        public Category Make(CategoryEditDto model) {
            var result = _repo.Find(model.Id);
            result.Slug = model.Slug.MakeSlug();
            result.Title = model.Title;
            result.Description = model.Description;
            result.ParentId = model.ParentId;
            result.LangId = model.LangId;
            result.Status = model.Enabled 
                ? EntityStatus.Enabled 
                : EntityStatus.Disabled;
            result.ModifyDate = _dateService.UtcNow();
            result.ModifierUserId = _userContext.UserId;

            return result;
        }

    }
}
