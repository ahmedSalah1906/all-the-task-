namespace TASK_poiner.models
{
    public enum PropertyType
    {
        String,
        Integer,
        Date,
        Dropdown
    }

    public class PropertyForEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PropertyType Type { get; set; }
        public bool IsRequired { get; set; }


        public List<string>? DropdownOptions { get; set; }
        public string? Value { get; set; }
        public int? EmployeeId { get; set; }
    }

}
