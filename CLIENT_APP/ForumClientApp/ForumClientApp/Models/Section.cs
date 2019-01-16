﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumClientApp.Models
{
    public class Section
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
