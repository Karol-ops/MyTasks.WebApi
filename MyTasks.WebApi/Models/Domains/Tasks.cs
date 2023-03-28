using System;
using System.Collections.Generic;

namespace MyTasks.WebApi.Models.Domains
{
    public partial class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime Term { get; set; }
        public bool IsExecuted { get; set; }

        public virtual Categories Category { get; set; }
    }
}
