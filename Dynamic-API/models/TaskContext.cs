using Microsoft.EntityFrameworkCore;
namespace TASK_poiner.models
{
    public class TaskContext:DbContext
    {
        public TaskContext() : base()
        { }
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PropertyForEmployee> propirtyForEmployees { get; set; }
        public DbSet<PropertyValues> propirtyValues { get; set; }

    }
}
