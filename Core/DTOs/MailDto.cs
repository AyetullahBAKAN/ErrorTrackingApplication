using Microsoft.AspNetCore.Identity;

namespace Core.DTOs
{
    public class MailDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}






