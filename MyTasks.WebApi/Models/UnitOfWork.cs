using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Models.Repositories;

namespace MyTasks.WebApi.Models
{
    public class UnitOfWork
    {
        private readonly MyTasksWebApiContext _context;
        public UnitOfWork(MyTasksWebApiContext context)
        {
            _context = context;
            Task = new TaskRepository(context);
            Category = new CategoryRepository(context);
        }

        public TaskRepository Task { get; }
        public CategoryRepository Category { get; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
