using System.Text;

namespace Behlog.Web.Core.SEO
{
    public class OpenGraphTagInput
    {
        public OpenGraphTagInput() {
            Type = "article";
        }

        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string PageUrl { get; set; }
        public string SiteName { get; set; }

        public override string ToString() {
            var sb = new StringBuilder();
            sb.AppendLine($"<meta property=\"og:type\" content=\"{Type}\" />");
            sb.AppendLine($"<meta property=\"og:title\" content=\"{Title}\" />");
            sb.AppendLine($"<meta property=\"og:description\" content=\"{Description}\" />");
            sb.AppendLine($"<meta property=\"og:image\" content=\"{ImageUrl}\" />");
            sb.AppendLine($"<meta property=\"og:url\" content=\"{PageUrl}\" />");
            sb.AppendLine($"<meta property=\"og:site_name\" content=\"{SiteName}\" />");

            return sb.ToString();
        }
    }
}
