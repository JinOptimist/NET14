using System.Collections.Generic;

namespace TeamLearningEnglish.Models
{
    public class IndexBookViewModel
    {
        public int Page { get; set; }
        public List<char> Text { get; set; }
        public virtual BookViewModel Book { get; set; }
    }
}
