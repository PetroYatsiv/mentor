using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumClientApp.Models
{
    public class SubTopicViewModel
    {
        public SubTopicViewModel()
        {
            Comments = new HashSet<CommentViewModel>();
        }
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public int TopicId { get; set; }
        public TopicViewModel Topic { get; set; }
    }
}
