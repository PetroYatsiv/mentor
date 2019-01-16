using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumClientApp.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }

        public Section Section { get; set; }
    }
}
