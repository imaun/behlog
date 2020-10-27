using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Extensions;
using Behlog.Factories.Contracts.System;
using Behlog.Services.Dto.System;
using Mapster;

namespace Behlog.Services.System
{
    public class PostTypeService: IPostTypeService {

        private readonly IPostTypeRepository _repo;
        

        public PostTypeService(
            IPostTypeRepository repo
        ) {
            repo.CheckArgumentIsNull();
            _repo = repo;
        }

        //public async Task<PostTypeResultDto> GetResultByIdAsync(int id) => await
        //    Task.FromResult(_repo.FindAsync(id)
        //        .Adapt<PostTypeResultDto>()
        //    );


        public async Task<PostTypeResultDto> GetResultByIdAsync(int id) {
            var result = await _repo.FindAsync(id);
            return result.Adapt<PostTypeResultDto>();
        }

        //public async Task<PostTypeResultDto> GetBySlugAsync(string slug) => await
        //    Task.FromResult(_repo.GetBySlugAsync(slug)
        //        .Adapt<PostTypeResultDto>()
        //    );


        public async Task<PostTypeResultDto> GetBySlugAsync(string slug) {
            var result = await _repo.GetBySlugAsync(slug);
            return result.Adapt<PostTypeResultDto>();
        }

    }
}
