namespace Core.Models
{
    public class RootAnalysis : BaseEntity
    {
        public string WhyOne { get; set; }
        public string WhyTwo { get; set; }
        public string WhyThree { get; set; }
        public string WhyRoot { get; set; }
        public string Result { get; set; }
        public ICollection<ErrorCard> ErrorCards { get; set; }
    }
}
