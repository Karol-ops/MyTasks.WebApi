using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Models.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace MyTasks.WebApi.Models.Converters
{
    public static class TaskConverter
    {
        public static TaskDto ToDto(this Tasks model)
        {
            return new TaskDto
            {
                CategoryId = model.CategoryId,
                Term = model.Term,
                Description = model.Description,
                Id = model.Id,
                Title = model.Title,
                IsExecuted = model.IsExecuted
            };
        }

        public static IEnumerable<TaskDto> ToDtos(this IEnumerable<Tasks> model)
        {
            if (model == null)
            {
                return Enumerable.Empty<TaskDto>();
            }

            return model.Select(x => x.ToDto());
        }

        public static Tasks ToDao(this TaskDto model)
        {
            return new Tasks
            {
                CategoryId = model.CategoryId,
                Term = model.Term,
                Description = model.Description,
                Id = model.Id,
                Title = model.Title,
                IsExecuted = model.IsExecuted
            };
        }
    }
}
