using System.Collections.Generic;
using Behlog.Core.Models.Enum;
using Behlog.Web.ViewModels.Content;

namespace Behlog.Web.ViewModels.System
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int PostTypeId { get; set; }
        public int? ParentId { get; set; }
        public int LangId { get; set; }
        public string TreePath { get; set; }
        public int WebsiteId { get; set; }
        public EntityStatus Status { get; set; }
    }

    
    public class CategoryItemViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int? ParentId { get; set; }
    }

    public class CategoryPostListViewModel {
        public CategoryPostListViewModel() {
            Items = new List<CategoryPostListItemViewModel>();

        }
        public string Title { get; set; }
        public string PostTypeSlug { get; set; }
        public IEnumerable<CategoryPostListItemViewModel> Items { get; set; }
    }

    public class CategoryPostListItemViewModel {
        public CategoryPostListItemViewModel() {
            Posts = new List<PostItemViewModel>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string AltTitle { get; set; }
        public string Slug { get; set; }
        public IEnumerable<PostItemViewModel> Posts { get; set; }
    }
}
