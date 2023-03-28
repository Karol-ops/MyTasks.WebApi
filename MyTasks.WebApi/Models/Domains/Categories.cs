using System;
using System.Collections.Generic;

namespace MyTasks.WebApi.Models.Domains
{
    public partial class Categories
    {
        public Categories()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
