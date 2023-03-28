using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Models.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace MyTasks.WebApi.Models.Converters
{
    public static class CategoryConverter
    {
        public static CategoryDto ToDto(this Categories model)
        {
            return new CategoryDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static IEnumerable<CategoryDto> ToDtos(this IEnumerable<Categories> model)
        {
            if (model == null)
            {
                return Enumerable.Empty<CategoryDto>();
            }

            return model.Select(x => x.ToDto());
        }

        public static Categories ToDao(this CategoryDto model)
        {
            return new Categories
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
