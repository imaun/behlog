using Mapster;
using Behlog.Services.Dto.Content;
using Behlog.Web.ViewModels.Content;
using Behlog.Web.Data.Extensions;

namespace Behlog.Web.Mapping
{
    public static class MappingConfig
    {
        public static void AddViewModelMappingConfig() {
            TypeAdapterConfig<PostResultDto, PostEditViewModel>
                .NewConfig()
                .Map(d => d.Tags, s => s.Tags.GetTagsAsString()
            );
        }
    }
}
