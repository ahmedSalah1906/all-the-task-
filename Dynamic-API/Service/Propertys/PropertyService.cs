using TASK_poiner.models;
using TASK_poiner.Repository.property;

namespace TASK_poiner.Service.Propertys
{
    public class PropertyService:IPropertyService
    {
        IPropertyRepository repository;
        public PropertyService(IPropertyRepository repository)
        {
            this.repository = repository;
        }
        public PropertyForEmployee AddGlobalProperty(PropertyForEmployee property)

        {
            return repository.AddProperty(property);
        }

        public void DeleteProperty(int id)
        {
            repository.DeleteProperty(id);
        }

        public List<PropertyForEmployee> GetAllGlobalProperties()
        {
            return repository.GetAllProperties();
        }

        public PropertyForEmployee GetGlobalPropertyById(int id)
        {
            return repository.GetPropertyById(id);
        }

        public PropertyForEmployee UpdateGlobalProperty(PropertyForEmployee property)
        {
            return repository.UpdateProperty(property);

        }
    }

}

