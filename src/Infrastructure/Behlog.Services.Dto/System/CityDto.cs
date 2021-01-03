using Behlog.Core.Models.Enum;

namespace Behlog.Services.Dto.System
{
    public class CityResultDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public EntityStatus Status { get; set; }
        public int? ParentId { get; set; }
        public string ParentTitle { get; set; }
        public CityType Kind { get; set; }
        public string Description { get; set; }
    }
}
