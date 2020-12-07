using System;
using Behlog.Services.Dto.Core;
using Behlog.Core.Models.Enum;

namespace Behlog.Services.Dto.Admin.Security
{
    public class AdminUserIndexDto
    {
        public AdminUserIndexDto() {
            DataSource = new DataGridDto<AdminUserIndexItemDto>();
        }

        public DataGridDto<AdminUserIndexItemDto> DataSource { get; set; }
    }

    public class AdminUserIndexItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public UserStatus Status { get; set; }
        public string WebUrl { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string UserName { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Description { get; set; }
        public bool TwoFactorEnabled { get; set; }
    }

    public class AdminUserIndexFilter: DataGridFilter
    {
        public string Title { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserStatus? Status { get; set; }
        public string UserName { get; set; }
    }

    public class AdminCreateUserDto
    {
        public string Title { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public UserStatus Status { get; set; }
        public string WebUrl { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
    }

}
