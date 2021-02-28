using System.Threading.Tasks;
using Behlog.Factories.Contracts.Content;
using Behlog.Core.Extensions;
using Behlog.Services.Dto.Admin.Content;
using Behlog.Core.Contracts.Repository.Content;
using Behlog.Services.Contracts.Admin;
using Behlog.Core.Models.Enum;
using System.Collections.Generic;

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

        public async Task<AdminSliderResultDto> CreateAsync(AdminCreateSliderDto model) {
            model.CheckArgumentIsNull(nameof(model));

            var post = await _postFactory.MakeSliderPostAsync(
                title: model.Title,
                slug: model.Slug,
                langId: model.LangId,
                enabled: model.Enabled);

            foreach(var item in model.Items) {
                var file = await _fileFactory.MakeAsync(item);
                var postFile = await _postFileFactory.MakeAsync(
                    file, 
                    title: item.Title, 
                    postId: null, 
                    relatedFileId: null, 
                    item.OrderNum);
                post.PostFiles.Add(postFile);
            }

            await _postRepository.AddAndSaveAsync(post);

            var result = new AdminSliderResultDto {
                Enabled = model.Enabled,
                LangId = model.LangId,
                PostId = post.Id,
                Slug = post.Slug,
                Title = post.Title
            };

            var items = new List<AdminSliderResultItemDto>();
            foreach(var file in post.PostFiles) {
                items.Add(new AdminSliderResultItemDto {
                    FileId = file.FileId,
                    FilePath = file.File.FilePath,
                    OrderNum = file.OrderNum,
                    PostFileId = file.Id,
                    Title = file.Title,
                    Url = file.File.Url
                });
            }
            result.Items = items;

            return result;
        }

        public async Task<AdminSliderResultDto> GetForEditAsync(int postId) {
            var post = await _postRepository.GetWithPostFilesAsync(postId);
            var result = new AdminSliderResultDto {
                Enabled = post.Status == PostStatus.Published,
                LangId = post.LangId,
                PostId = post.Id,
                Slug = post.Slug,
                Title = post.Title
            };

            var items = new List<AdminSliderResultItemDto>();
            foreach (var file in post.PostFiles) {
                items.Add(new AdminSliderResultItemDto {
                    FileId = file.FileId,
                    FilePath = file.File.FilePath,
                    OrderNum = file.OrderNum,
                    PostFileId = file.Id,
                    Title = file.Title,
                    Url = file.File.Url
                });
            }
            result.Items = items;

            return result;
        }
    }
}
