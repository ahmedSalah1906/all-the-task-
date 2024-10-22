
using TASK_poiner.models;

namespace TASK_poiner.Repository.property
{
    public class PropertyRepository : IPropertyRepository
    {
        TaskContext context;
        public PropertyRepository(TaskContext context)
        {
            this.context = context;
        }
        public PropertyForEmployee AddProperty(PropertyForEmployee property)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            var entery = context.propirtyForEmployees.Add(property);
            Save();
            return entery.Entity;

        }

        public void DeleteProperty(int id)
        {
            var pro = GetPropertyById(id);
            if (pro != null)
            {
                context.propirtyForEmployees.Remove(pro);
                Save();
            }

        }

        public List<PropertyForEmployee> GetAllProperties()
        {
            return context.propirtyForEmployees.ToList();
        }

        public PropertyForEmployee GetPropertyById(int id)
        {

            var pro = context.propirtyForEmployees.FirstOrDefault(x => x.Id == id);
            if (pro != null)
            { return pro; }
            return null;

        }


        public PropertyForEmployee UpdateProperty(PropertyForEmployee property)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            var entery = context.propirtyForEmployees.Update(property);
            Save();
            return entery.Entity;
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
