using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Services.Dto.Feature;
using Behlog.Services.Dto.Admin.Feature;

namespace Behlog.Services.Contracts.Feature
{
    public interface IContactService {
        Task<ContactResultDto> CreateAsync(CreateContactDto model);

        Task<AdminContactIndexDto> GetAdminIndexAsync(AdminContactIndexFilter filter);
    }
}
