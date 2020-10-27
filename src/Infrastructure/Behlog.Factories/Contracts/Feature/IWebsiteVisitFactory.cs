using System.Threading.Tasks;
using Behlog.Core.Models.Feature;

namespace Behlog.Factories.Contracts.Feature
{
    public interface IWebsiteVisitFactory
    {
        Task<WebsiteVisit> MakeAsync();
    }
}
