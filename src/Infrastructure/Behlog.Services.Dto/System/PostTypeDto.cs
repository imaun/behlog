using Behlog.Core.Models.Enum;

namespace Behlog.Services.Dto.System
{
    public class PostTypeResultDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public EntityStatus Status { get; set; }
    }
}
