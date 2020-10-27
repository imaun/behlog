using Behlog.Core.Models.Enum;

namespace Behlog.Services.Dto.System
{
    public class LanguageResultDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LangKey { get; set; }
        public EntityStatus Status { get; set; }
    }
}
