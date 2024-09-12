namespace Core.Models
{
    public class ErrorDefine : BaseEntity
    {
        public string ErrorExplain { get; set; }
        public ICollection<ErrorCard> ErrorCards { get; set; }
        public ICollection<MediaErrorDefine> MediaErrorDefines { get; set; }
    }
}
