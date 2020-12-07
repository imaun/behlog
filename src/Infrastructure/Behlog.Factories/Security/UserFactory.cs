using Behlog.Core.Models.Security;
using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Services.Dto.Admin.Security;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Factories.Contracts.Security;

namespace Behlog.Factories.Security
{
    public class UserFactory: IUserFactory
    {
        private readonly IDateService _dateService;

        public UserFactory(IDateService dateService) {
            dateService.CheckArgumentIsNull(nameof(dateService));
            _dateService = dateService;

        }

        public async Task<User> MakeAsync(AdminCreateUserDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var user = new User {
                Description = model.Description,
                Email = model.Email,
                Status = model.Status,
                WebUrl = model.WebUrl,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName,
                RegisterDate = _dateService.UtcNow(),
                Title = model.Title
            };

            return await Task.FromResult(user);
        }

    }
}
