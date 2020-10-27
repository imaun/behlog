using System;
using System.Collections.Generic;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;
using Behlog.Factories.Contracts.System;
using Behlog.Resources.Strings;

namespace Behlog.Factories.System
{
    public class LanguageFactory: ILanguageFactory {

        public Tuple<Language, Language> CreateDefaultLanguages() =>
            new Tuple<Language, Language>(
                new Language {
                    LangKey = Language.KEY_fa_IR,
                    Status = EntityStatus.Enabled,
                    Title = AppTextDisplay.LangFaTitle
                },
                new Language {
                    LangKey = Language.KEY_en_US,
                    Status = EntityStatus.Enabled,
                    Title = AppTextDisplay.LangEnTItle
                }
            );
    }
}
