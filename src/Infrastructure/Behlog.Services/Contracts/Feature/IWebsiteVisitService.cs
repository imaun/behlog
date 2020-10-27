using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Behlog.Services.Contracts.Feature
{
    public interface IWebsiteVisitService
    {
        Task CreateAsync(); 
    }
}
