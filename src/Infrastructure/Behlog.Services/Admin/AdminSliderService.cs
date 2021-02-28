using System.Threading.Tasks;
using Behlog.Factories.Contracts.Content;
using Behlog.Core.Extensions;
using Behlog.Services.Dto.Admin.Content;
using Behlog.Core.Contracts.Repository.Content;
using Behlog.Services.Contracts.Admin;

namespace Behlog.Services.Admin {

    public class AdminSliderService: IAdminSliderService {

        private readonly IPostFactory _postFactory;
        private readonly IFileFactory _fileFactory;
        private readonly IPostFileFactory _postFileFactory;
        private readonly IPostRepository _postRepository;

        public AdminSliderService(
            IPostFactory postFactory, 
            IFileFactory fileFactory,
            IPostFileFactory postFileFactory) {
            postFactory.CheckArgumentIsNull(nameof(postFactory));
            _postFactory = postFactory;

            fileFactory.CheckArgumentIsNull(nameof(fileFactory));
            _fileFactory = fileFactory;

            postFileFactory.CheckArgumentIsNull(nameof(postFileFactory));
            _postFileFactory = postFileFactory;
        }

        public async Task CreateAsync(AdminCreateSliderDto model) {
            model.CheckArgumentIsNull(nameof(model));

            var post = await _postFactory.MakeSliderPostAsync(
                title: model.Title,
                slug: model.Slug,
                langId: model.LangId,
                enabled: model.Enabled);

            foreach(var item in model.Items) {
                var file = await _fileFactory.MakeAsync(item);
                var postFile = await _postFileFactory.MakeAsync(file, 
                    title: item.Title, null, null, item.OrderNum);
                post.PostFiles.Add(postFile);
            }

            await _postRepository.AddAndSaveAsync(post);
        }
    }
}
