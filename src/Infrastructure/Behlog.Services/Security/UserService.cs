using System;
using System.Collections.Generic;
using Mapster;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Behlog.Core.Extensions;
using Behlog.Core.Exceptions;
using Behlog.Services.Dto.Admin.Security;
using Behlog.Core.Contracts.Repository.Security;
using Behlog.Services.Extensions;
using Behlog.Services.Contracts.Security;
using Behlog.Factories.Contracts.Security;
using Behlog.Core;
using System.Security.Claims;

namespace Behlog.Services.Security
{
    public class UserService: IUserService {

        private readonly IUserRepository _repository;
        private readonly IUserFactory _factory;
        private readonly IAppUserManager _userManager;
        private readonly IWebsiteInfo _websiteInfo; 

        public UserService(
            IUserRepository repository,
            IUserFactory factory,
            IAppUserManager userManager,
            IWebsiteInfo websiteInfo) {
            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;

            factory.CheckArgumentIsNull(nameof(factory));
            _factory = factory;

            userManager.CheckArgumentIsNull(nameof(userManager));
            _userManager = userManager;

            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;
        }

        
        public async Task<AdminUserIndexDto> GetAdminIndexAsyc(AdminUserIndexFilter filter) {
            filter.CheckArgumentIsNull(nameof(filter));

            var query = _repository
                .Query()
                .SetFilter(filter);

            var result = new AdminUserIndexDto();
            result.DataSource.TotalCount = await query.CountAsync();
            result.DataSource.PageIndex = filter.PageIndex;
            result.DataSource.PageSize = filter.PageSize;

            query = query
                .Skip(filter.StartIndex)
                .Take(filter.PageSize);

            var users = await query.ToListAsync();

            result.DataSource.Items = users
                .Select(_ => _.Adapt<AdminUserIndexItemDto>())
                .ToList();

            return await Task.FromResult(result);
        }

        public async Task CreateAsync(AdminCreateUserDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var user = await _userManager.FindByNameAsync(model.UserName);
            if(user != null) {
                throw new UserNameExistException();
            }

            user = await _factory.MakeAsync(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if(result == IdentityResult.Failed()) {
                var msg = $"User Registration failed : {result.DumpErrors()}";
                throw new UserRegistrationException(message: msg);
            }

            await _userManager.AddClaimAsync(user, new Claim(
                    "WebsiteId", _websiteInfo.Id.ToString()
                ));
            
        }

    }
}
