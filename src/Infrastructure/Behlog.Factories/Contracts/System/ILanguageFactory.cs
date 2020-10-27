using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Models.System;

namespace Behlog.Factories.Contracts.System
{
    public interface ILanguageFactory {
        
        Tuple<Language, Language> CreateDefaultLanguages();
    }
}
