using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Services.Dto.Feature;

namespace Behlog.Services.Contracts.Feature
{
    public interface IContactService {
        Task<ContactResultDto> CreateAsync(CreateContactDto model);
    }
}
