


using CRUD_ENTITY_FRAMEWORK.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CRUD_ENTITY_FRAMEWORK.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
