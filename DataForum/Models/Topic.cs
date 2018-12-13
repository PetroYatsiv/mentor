using System;
using System.Collections.Generic;

namespace Forum.Data.Models
{
    public partial class Topic
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }

        public Section Section { get; set; }
    }
}
