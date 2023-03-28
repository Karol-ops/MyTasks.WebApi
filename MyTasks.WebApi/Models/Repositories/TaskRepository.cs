using MyTasks.WebApi.Models.Domains;
using System.Collections.Generic;
using System.Linq;

namespace MyTasks.WebApi.Models.Repositories
{
    public class TaskRepository
    {
        private readonly MyTasksWebApiContext _context;
        public TaskRepository(MyTasksWebApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Tasks> Get()
        {
            return _context.Tasks;
        }

        public Tasks Get(int id)
        {
            return _context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Tasks> Get(int recordsCount, int page)
        {
            return _context.Tasks.Skip((page - 1) * recordsCount).Take(recordsCount);
        }

        public void Add(Tasks task)
        {
            _context.Tasks.Add(task);
        }

        public void Update(Tasks task)
        {
            var taskToUpdate = _context.Tasks.First(x => x.Id == task.Id);

            taskToUpdate.CategoryId = task.CategoryId;
            taskToUpdate.Description = task.Description;
            taskToUpdate.Title = task.Title;
            taskToUpdate.Term = task.Term;
            taskToUpdate.IsExecuted = task.IsExecuted;
        }

        public void Delete(int id)
        {
            var taskToDelete = _context.Tasks.First(x => x.Id == id);

            _context.Tasks.Remove(taskToDelete);
        }
    }
}
