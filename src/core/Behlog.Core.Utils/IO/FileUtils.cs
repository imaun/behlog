using System.IO;
using System.Linq;

namespace Behlog.Core.Utils.IO {

    public static class FileUtils {

        private static string[] imageExts = new string[] { 
            ".jpg", ".jpeg", ".png", ".gif", ".tiff", ".bmp"
        };

        private static string[] videoExts = new string[] {
            ".flv", ".mov", ".webm", ".mp4", ".mkv"
        };

        private static string[] audioExts = new string[] {
            ".mp3", ".wav", ".aiff", ".aif", ".rm", ".ra", ".mid", ".wma"
        };

        private static string[] documentExts = new string[] {
            ".doc", ".docx", ".xls", ".xlsx", ".pdf", ".txt", ".rtf", ".odt", ".ppt", ".pptx"
        };

        public static string GetFileExtension(this string filePath)
            => Path.GetExtension(filePath);

        public static bool IsImage(this string filePath)
            => imageExts.Contains(GetFileExtension(filePath));

        public static bool IsVideo(this string filePath)
            => videoExts.Contains(GetFileExtension(filePath));

        public static bool IsAudio(this string filePath)
            => audioExts.Contains(GetFileExtension(filePath));

        public static bool IsDocument(this string filePath)
            => documentExts.Contains(GetFileExtension(filePath));

        public static string GetFileTitle(this string filePath)
            => Path.GetFileNameWithoutExtension(filePath);
        
    }
}
