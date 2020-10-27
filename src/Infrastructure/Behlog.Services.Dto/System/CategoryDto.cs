using System;
using System.Collections.Generic;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Services.Dto.Content;
using Behlog.Services.Dto.Core;

namespace Behlog.Services.Dto.System
{
    public class CategoryResultDto
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
        public string ParentTitle { get; set; }
    }

    public class CategoryCreateDto {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int PostTypeId { get; set; }
        public int? ParentId { get; set; }
        public int LangId { get; set; }
        public int WebsiteId { get; set; }
        public EntityStatus Status { get; set; }
    }

    public class CategoryEditDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int? ParentId { get; set; }
        public int LangId { get; set; }
        public bool Enabled { get; set; }
    }

    public class CategoryGridItemDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public int? ParentId { get; set; }
        public int? LangId { get; set; }
        public EntityStatus Status { get; set; }
        public string ParentTitle { get; set; }
        public string LanguageTitle { get; set; }
        public string StatusText => Status.ToText();
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }

    }

    public class CategoryGridOptions : DataGridOptions {
        public CategoryFilterDto Filter { get; set; }
    }

    public class CategoryFilterDto {
        public string Title { get; set; }
        public int? LangId { get; set; }
    }

    public class CategoryItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public int? ParentId { get; set; }
        public string Description { get; set; }
    }

    public class CategoryPostListDto {

        public string Title { get; set; }
        public string PostTypeSlug { get; set; }

        public CategoryPostListDto() {
            Items = new List<CategoryPostListItemDto>();
        }

        public IEnumerable<CategoryPostListItemDto> Items { get; set; }
    }

    public class CategoryPostListItemDto {

        public CategoryPostListItemDto() {
            Posts = new List<PostItemDto>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public IEnumerable<PostItemDto> Posts { get; set; }
    }
}

