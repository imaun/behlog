using System;

namespace Behlog.Services.Dto.Feature {

    public class CreateContactDto {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }

    public class ContactResultDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public DateTime SentDate { get; set; }
        public int WebsiteId { get; set; }
    }
}
