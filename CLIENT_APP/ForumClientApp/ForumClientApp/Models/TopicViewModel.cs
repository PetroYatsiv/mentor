using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumClientApp.Models
{
    public class TopicViewModel
    {
        public TopicViewModel()
        {
            SubTopics = new HashSet<SubTopicViewModel>();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }

        public ICollection<SubTopicViewModel> SubTopics { get; set; }

        public SectionViewModel Section { get; set; }
    }
}
