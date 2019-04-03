using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumClientApp.Models
{
    public class SectionViewModel
    {
        public SectionViewModel()
        {
            Topics = new HashSet<TopicViewModel>();
        }

        public int Id { get; set; }
        public string SectionDescription { get; set; }

        public ICollection<TopicViewModel> Topics { get; set; }
    }
}
