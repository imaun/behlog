using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Models.Feature;
using Behlog.Services.Dto.Feature;

namespace Behlog.Factories.Contracts.Feature
{
    public interface IContactFactory {
        Task<Contact> MakeAsync(CreateContactDto model);
    }
}
