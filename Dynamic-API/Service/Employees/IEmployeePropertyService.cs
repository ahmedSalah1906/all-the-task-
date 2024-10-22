using TASK_poiner.DTOS;

namespace TASK_poiner.Service.Employees
{
    public interface IEmployeePropertyService
    {
        public List<EmployeeDTO> GetAllWithProperties();
        public EmployeeDTO GetById(int id);
        public EmployeeDTO Update(int id, EmployeeDTO employeedto);
        public void DeleteById(int id);
        public void Create(EmployeeDTO employeedto);
    }
}
