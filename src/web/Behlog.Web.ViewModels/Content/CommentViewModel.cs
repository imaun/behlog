using Behlog.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using Behlog.Web.ViewModels.Core;
using System.ComponentModel.DataAnnotations;
using Behlog.Resources.Strings;

namespace Behlog.Web.ViewModels.Content
{
    public class CommentViewModel: BaseViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int PostId { get; set; }
        public string Email { get; set; }
        public string WebUrl { get; set; }
        public string Body { get; set; }
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public string SessionId { get; set; }
        public CommentStatus Status { get; set; }
        public long? ParentId { get; set; }
        public Guid? UserId { get; set; }
        public string UserTitle { get; set; }
        public string PostTitle { get; set; }
    }


    public class PostCommentViewModel {

        public PostCommentViewModel() {
            Items = new List<PostCommentViewModel>();
        }

        public string Description { get; set; }
        public IEnumerable<PostCommentViewModel> Items { get; set; }
    }

    public class PostCommentItemViewModel
    {
        public long Id { get; set; }
        public string UserPhotoUrl { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string WebUrl { get; set; }
        public string Body { get; set; }
        public string IP { get; set; }
        public long? ParentId { get; set; }
        public Guid? UserId { get; set; }
        public string UserTitle { get; set; }
    }

    public class CreateCommentViewModel: BaseViewModel {

        [Display(ResourceType = typeof(ModelText), Name = "Comment_Title")]
        [MaxLength(300, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public string Title { get; set; }
        
        public int PostId { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Comment_Email")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        [EmailAddress(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Email_Wrong")]
        public string Email { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Comment_Website")]
        [MaxLength(2000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string WebUrl { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Comment_Body")]
        [MaxLength(4000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public string Body { get; set; }

        public long? ParentId { get; set; }

    }
}
