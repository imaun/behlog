using Behlog.Core.Contracts;
using Behlog.Core.Models.System;
using Behlog.Core.Contracts.Repository.System;

namespace Behlog.Repository.System
{
    public class ErrorLogRepository : BaseRepository<ErrorLog, long>, IErrorLogRepository
    {
        public ErrorLogRepository(IBehlogContext context) : base(context) {
        }
    }
}
