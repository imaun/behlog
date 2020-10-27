using System.Threading.Tasks;
using Behlog.Core.Models.System;

namespace Behlog.Factories.Contracts.System
{
    public interface ITagFactory
    {
        Task<Tag> MakeAsync(string tagTitle);
    }
}
