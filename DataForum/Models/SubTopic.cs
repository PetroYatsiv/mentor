using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Models
{
   public  class SubTopic
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
