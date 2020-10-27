using Behlog.Core.Utils.Db;
using Behlog.Storage.Core;
using Microsoft.EntityFrameworkCore;

namespace Behlog.Storage.SQLite
{
    public class SQLiteDbContext: BehlogContext
    {
        public SQLiteDbContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.AddDateTimeOffsetConverter();
        }
    }
}
