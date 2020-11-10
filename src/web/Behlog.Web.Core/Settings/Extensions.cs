using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Web.Core.Settings {
    public static class Extensions {

        public static string GetConnectionString(this BehlogSetting setting) {
            switch (setting.DbType) {
                case AppDatabaseType.SqlServer:
                    return setting.ConnectionStrings.SqlServer;
                case AppDatabaseType.SQLite:
                    return setting.ConnectionStrings.SQLite;

                default:
                    throw new NotSupportedException("The database type is not supported.");
            }
        }
    }
}
