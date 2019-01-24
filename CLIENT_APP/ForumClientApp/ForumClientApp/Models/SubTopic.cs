using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumClientApp.Models
{
    public class SubTopic
    {
        public SubTopic()
        {
            Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
