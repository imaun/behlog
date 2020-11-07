using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using Behlog.Services.Dto.Feature;
using Behlog.Services.Contracts.Feature;
using Behlog.Core.Extensions;
using Behlog.Core.Contracts.Repository.Content;

namespace Behlog.Web.Common.Filters {

    public class CountPostVisitFilter: ActionFilterAttribute {

        private static readonly TimeSpan callDbTime = new TimeSpan(0, 0, 10);
        private readonly IPostVisitService _postVisitService;
        private readonly IPostRepository _postRepository;

        public CountPostVisitFilter(IPostVisitService postVisitService,
            IPostRepository postRepository) {
            postVisitService.CheckArgumentIsNull(nameof(postVisitService));
            _postVisitService = postVisitService;

            postRepository.CheckArgumentIsNull(nameof(postRepository));
            _postRepository = postRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            var args = context.ActionArguments;
            if (args == null || !args.Any())
                return;

            int postId = 0;
            string postTitle = string.Empty;

            if(args.ContainsKey("id")) {
                postId = int.Parse(args.First(_ => _.Key == "id").Value.ToString());
            }

            if(args.ContainsKey("postType") && args.ContainsKey("slug") && postId == 0) {
                var postType = args.First(_ => _.Key == "postType").Value.ToString();
                var slug = args.First(_ => _.Key == "slug").Value.ToString();
                var post = _postRepository
                    .Query()
                    .FirstOrDefault(_ => _.Slug.ToLower() == slug.ToLower() &&
                        _.PostType.Slug.ToLower() == postType.ToLower());
                if(post != null) {
                    postId = post.Id;
                    postTitle = post.Title;
                }
            }
            
            if(postId > 0) {
                var cachKey = string.Format("POST-CNT-{0}", postId);
                //TODO: Must Use cache
                //var cachedResult = 
                var data = new CreatePostVisitDto {
                    PostId = postId,
                    Title = postTitle
                };
                _postVisitService.Create(data);
            }

            base.OnActionExecuting(context);
        }


    }
}
