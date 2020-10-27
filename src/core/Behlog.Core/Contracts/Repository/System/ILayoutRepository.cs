using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Models.System;

namespace Behlog.Core.Contracts.Repository.System
{
    public interface ILayoutRepository: IBaseRepository<Layout, int>
    {
        Task<Layout> GetByNameAsync(string name);
    }
}
