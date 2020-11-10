namespace Behlog.Web.Core.Settings {
    public class AppConnectionString {
        public string SqlServer { get; set; }
        public string SQLite { get; set; }
        public LocalDb LocalDb { get; set; }
    }

    public class LocalDb {
        public string InitialCatalog { get; set; }
        public string AttachDbFilename { get; set; }
    }
}
