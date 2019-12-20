using System;
using System.Collections.Generic;

namespace _04DataFirstCore.Models
{
    public partial class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
