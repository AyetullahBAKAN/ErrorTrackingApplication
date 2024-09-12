namespace Core.Models
{
    public class Mail
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
        public bool IsDeleted { get; set; }
    }
}
