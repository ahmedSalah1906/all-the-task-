namespace TASK_poiner.models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }


        public ICollection<PropertyValues> PropertyValues { get; set; }
    }
}
