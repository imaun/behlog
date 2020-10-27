using Microsoft.EntityFrameworkCore;
using Behlog.Storage.Core;

namespace Behlog.Storage.InMemory
{
    public class InMemoryDbContext : BehlogContext
    {
        public InMemoryDbContext(DbContextOptions options): base(options) { }
    }
}
