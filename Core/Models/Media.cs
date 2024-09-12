namespace Core.Models
{
    public class Media : BaseEntity
    {
        public string ImagePath { get; set; }
        public ICollection<MediaErrorDefine> MediaErrorDefines { get; set; }
        public ICollection<MediaSolutionAndStandardizition> MediaSolutionAndStandardizitions { get; set; }
    }
}
