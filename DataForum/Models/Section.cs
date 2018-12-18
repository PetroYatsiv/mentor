using System;
using System.Collections.Generic;

namespace Forum.Data.Models
{
    public partial class Section
    {
        public Section()
        {
            Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }
        public string SectionDescription { get; set; }

        public ICollection<Topic> Topics { get; set; }
    }
}
