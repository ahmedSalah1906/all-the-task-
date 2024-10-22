using TASK_poiner.models;

namespace TASK_poiner.Service.Propertys
{
    public interface IPropertyService
    {
        public List<PropertyForEmployee> GetAllGlobalProperties();
        public PropertyForEmployee GetGlobalPropertyById(int id);
        public void DeleteProperty(int id);
        public PropertyForEmployee UpdateGlobalProperty(PropertyForEmployee property);
        public PropertyForEmployee AddGlobalProperty(PropertyForEmployee property);

    }
}
