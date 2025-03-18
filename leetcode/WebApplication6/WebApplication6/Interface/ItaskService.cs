using WebApplication6.Models;

namespace WebApplication6.Interface
{
    public interface ItaskService
    {
        Task<List<Task1>> GetTasks();
    }
}
