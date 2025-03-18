using WebApplication6.Interface;
using WebApplication6.Models;

namespace WebApplication6.Services
{
    public class TaskService: ItaskService
    {
        private readonly List<Task1> tasks = new List<Task1>()
        {
        new Task1 { Id=1, Description="Hello", Title ="abc"}
        };
        public async Task<List<Task1>> GetTasks()
        {
            return tasks;
        }
    }
}
