using System;

namespace MyTasks.WebApi.Models.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime Term { get; set; }
        public bool IsExecuted { get; set; }
    }
}
