using System;
using System.Collections.Generic;
using System.Text;
using Behlog.Storage.Core;
using Microsoft.EntityFrameworkCore;

namespace Behlog.Storage.SqlServer {
    public class SqlServerDbContext: BehlogContext {

        public SqlServerDbContext(DbContextOptions options): base(options) {

        }

    }
}
