using System;
using System.Collections.Generic;
using System.Text;
using Behlog.Core.Models.System;
using Behlog.Services.Dto.System;

namespace Behlog.Factories.Contracts.System
{
    public interface ILayoutFactory {
        Layout Make(LayoutCreateDto model);
    }
}
