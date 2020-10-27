using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Models.System;
using Behlog.Services.Dto.System;

namespace Behlog.Factories.Contracts.System
{
    public interface ICategoryFactory {
        Category Make(CategoryCreateDto model);
        Category Make(CategoryEditDto model);
    }
}
