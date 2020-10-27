using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Core.Security;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Feature;
using Behlog.Services.Dto.Feature;
using Behlog.Core.Contracts.Services.Common;
using System;
using Behlog.Factories.Contracts.Feature;

namespace Behlog.Factories.Feature {

    public class PostVisitFactory: IPostVisitFactory {

        private readonly IDateService _dateService;
        private readonly IUserContext _userContext;

        public PostVisitFactory(
            IDateService dateService,
            IUserContext userContext) {

            dateService.CheckArgumentIsNull(nameof(dateService));
            _dateService = dateService;

            userContext.CheckArgumentIsNull(nameof(userContext));
            _userContext = userContext;
        }

        public async Task<PostVisit> MakeAsync(CreatePostVisitDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var entity = new PostVisit {
                AbseloutUrl = AppHttpContext.AbsoluteUrl,
                CreateDate = _dateService.UtcNow(),
                IP = AppHttpContext.IpAddress,
                OsPlatform = AppHttpContext.OsPlatform,
                UserAgent = AppHttpContext.UserAgent,
                PostId = model.PostId,
                PostTitle = model.Title,
                SessionId = AppHttpContext.SessionId,
                UrlReferrer = AppHttpContext.UrlReferer
            };

            //if (_userContext.IsAuthenticated)
            //    entity.UserId = _userContext.UserId;

            return await Task.FromResult(entity);
        }

        public PostVisit Make(CreatePostVisitDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var entity = new PostVisit {
                AbseloutUrl = AppHttpContext.AbsoluteUrl,
                CreateDate = _dateService.UtcNow(),
                IP = AppHttpContext.IpAddress,
                OsPlatform = AppHttpContext.OsPlatform,
                UserAgent = AppHttpContext.UserAgent,
                PostId = model.PostId,
                PostTitle = model.Title,
                SessionId = AppHttpContext.SessionId,
                UrlReferrer = AppHttpContext.UrlReferer
            };

            return entity;
        }

    }
}
