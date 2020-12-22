using Behlog.Core.Models.Enum;
using Behlog.Web.ViewModels.Core;

namespace Behlog.Web.ViewModels.Content
{
    public class FileViewModel: BaseViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public PostFileType FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public FileStatus Status { get; set; }
        public int WebsiteId { get; set; }
    }


}
