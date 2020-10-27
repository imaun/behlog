using System;
using System.Collections.Generic;
using System.Text;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Extensions;
using Behlog.Core.Models.System;
using Behlog.Factories.Contracts.System;
using Behlog.Services.Dto.System;
using Mapster;

namespace Behlog.Factories.System
{
    public class LayoutFactory: ILayoutFactory {

        private readonly IDateService _dateSvc;


        public LayoutFactory(
            IDateService dateSvc
        ) {
            dateSvc.CheckArgumentIsNull();
            _dateSvc = dateSvc;
        }

        public Layout Make(LayoutCreateDto model) {
            var result = model.Adapt<Layout>();
            result.CreateDate = result.ModifyDate = _dateSvc.UtcNow();

            return result;
        }
    }
}
