using System;
using System.Collections.Generic;

namespace Forum.Data.Models
{
    public partial class Section
    {
        public Section()
        {
            Topic = new HashSet<Topic>();
        }

        public int Id { get; set; }
        public string SectionDescription { get; set; }

        public ICollection<Topic> Topic { get; set; }
    }
}
