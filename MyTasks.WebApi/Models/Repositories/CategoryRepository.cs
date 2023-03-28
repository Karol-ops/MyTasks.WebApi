using MyTasks.WebApi.Models.Domains;
using System.Collections.Generic;
using System.Linq;

namespace MyTasks.WebApi.Models.Repositories
{
    public class CategoryRepository
    {
        private readonly MyTasksWebApiContext _context;
        public CategoryRepository(MyTasksWebApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Categories> Get()
        {
            return _context.Categories;
        }

        public Categories Get(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Categories> Get(int recordsCount, int page)
        {
            return _context.Categories.Skip((page - 1) * recordsCount).Take(recordsCount);
        }

        public void Add(Categories category)
        {
            _context.Categories.Add(category);
        }

        public void Update(Categories category)
        {
            var categoryToUpdate = _context.Categories.First(x => x.Id == category.Id);

            categoryToUpdate.Name = category.Name;
        }

        public void Delete(int id)
        {
            var categoryToDelete = _context.Categories.First(x => x.Id == id);

            _context.Categories.Remove(categoryToDelete);
        }
    }
}
