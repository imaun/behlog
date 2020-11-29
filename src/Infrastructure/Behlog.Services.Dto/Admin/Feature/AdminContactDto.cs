using System;
using Behlog.Services.Dto.Core;

namespace Behlog.Services.Dto.Admin.Feature {
    
    public class AdminContactIndexDto {

        public AdminContactIndexDto() {
            DataSource = new DataGridDto<AdminContactIndexItemDto>();
        }

        public DataGridDto<AdminContactIndexItemDto> DataSource { get; set; }
    }

    public class AdminContactIndexItemDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public string SessionId { get; set; }
        public DateTime SentDate { get; set; }
    }

    public class AdminContactIndexFilter: DataGridFilter {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
