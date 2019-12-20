using System;
using System.Collections.Generic;

namespace _04DataFirstCore.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Subject = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Subject> Subject { get; set; }
    }
}
