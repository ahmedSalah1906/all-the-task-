using Microsoft.EntityFrameworkCore;
using TASK_poiner.models;

namespace TASK_poiner.Repository.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {

            private readonly TaskContext _context;

            public EmployeeRepository(TaskContext context)
            {
                _context = context;
            }


            public List<Employee> GetAllEmp()
            {
                return _context.Employees
                    .Include(e => e.PropertyValues)
                    .ToList();
            }



            public Employee GetByIdEmp(int id)
            {
                return _context.Employees
                    .Include(e => e.PropertyValues)
                    .FirstOrDefault(e => e.EmployeeId == id);
            }


            public Employee CreateEmp(Employee employee)
            {
                if (employee == null) throw new ArgumentNullException(nameof(employee));
                var entery = _context.Employees.Add(employee);
                Save();
                return entery.Entity;



            }



            public Employee UpdateEmp(Employee employee)
            {
                if (employee == null) throw new ArgumentNullException(nameof(employee));
                var entery = _context.Employees.Update(employee);
                Save();
                return entery.Entity;
            }


            public void DeleteEmp(int id)
            {
                var employee = GetByIdEmp(id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    Save();
                }
            }

            public void Save()
            {
                _context.SaveChanges();
            }
        }
    }

