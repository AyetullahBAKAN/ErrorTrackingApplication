namespace Core.Models
{
    public class MediaErrorDefine
    {
        public Guid MediaId { get; set; }
        public virtual Media Media { get; set; }
        public Guid ErrorDefineId { get; set; }
        public virtual ErrorDefine ErrorDefine { get; set; }
    }
}
