
using TASK_poiner.DTOS;
using TASK_poiner.models;
using TASK_poiner.Repository.Employees;
using TASK_poiner.Repository.property;


namespace TASK_poiner.Service.Employees
{
    public class EmployeePropertyService : IEmployeePropertyService
    {
        IEmployeeRepository employeeRepository;
        IPropertyRepository propertyRepository;
        public EmployeePropertyService(IPropertyRepository propertyRepository, IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this.propertyRepository = propertyRepository;

        }

        public void Create(EmployeeDTO employeedto)
        {
            var employee = new Employee
            {
                Name = employeedto.Name,
                Code = employeedto.Code,
                PropertyValues = employeedto.CustomProperteis.Select(customProperty => new PropertyValues
                {
                    PropertyId = customProperty.PropertyId,
                    Value = customProperty.Value
                }).ToList()
            };

           employeeRepository.CreateEmp(employee);
        }

        public void DeleteById(int id)
        {
            var employee = employeeRepository.GetByIdEmp(id);
            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }

            employeeRepository.DeleteEmp(id);
        }

        public List<EmployeeDTO> GetAllWithProperties()
        {
            var employees = employeeRepository.GetAllEmp();
            var globalProperties = propertyRepository.GetAllProperties();

            return employees.Select(employee => new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Code = employee.Code,
                CustomProperteis = globalProperties.Select(globalProp =>
                {
                    var propertyValue = employee.PropertyValues
                        .FirstOrDefault(p => p.PropertyId == globalProp.Id)?.Value;

                    return new PropertyDTO
                    {
                        PropertyId = globalProp.Id,
                        Name = globalProp.Name,
                        Type = globalProp.Type,
                        DropdownOptions = globalProp.DropdownOptions,
                        Value = propertyValue ?? string.Empty
                    };
                }).ToList()
            }).ToList();
        }

        public EmployeeDTO GetById(int id)
        {
            var employee = employeeRepository.GetByIdEmp(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            var globalProperties = propertyRepository.GetAllProperties();

            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Code = employee.Code,
                CustomProperteis = globalProperties.Select(globalProp =>
                {
                    var propertyValue = employee.PropertyValues
                        .FirstOrDefault(p => p.PropertyId == globalProp.Id)?.Value;

                    return new PropertyDTO
                    {
                        PropertyId = globalProp.Id,
                        Name = globalProp.Name,
                        Type = globalProp.Type,
                        DropdownOptions = globalProp.DropdownOptions,
                        Value = propertyValue ?? string.Empty
                    };
                }).ToList()
            };
        }


        public EmployeeDTO Update(int id, EmployeeDTO employeedto)
        {
            var employee = employeeRepository.GetByIdEmp(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            employee.Name = employeedto.Name;
            employee.Code = employeedto.Code;

            // Update property values
            foreach (var customProperty in employeedto.CustomProperteis)
            {
                var existingProperty = employee.PropertyValues
                    .FirstOrDefault(p => p.PropertyId == customProperty.PropertyId);

                if (existingProperty != null)
                {
                    existingProperty.Value = customProperty.Value;
                }
                else
                {

                    employee.PropertyValues.Add(new PropertyValues
                    {
                        PropertyId = customProperty.PropertyId,
                        Value = customProperty.Value
                    });
                }
            }

            var emp = employeeRepository.UpdateEmp(employee);
            return employeedto;
        }
    }


}
