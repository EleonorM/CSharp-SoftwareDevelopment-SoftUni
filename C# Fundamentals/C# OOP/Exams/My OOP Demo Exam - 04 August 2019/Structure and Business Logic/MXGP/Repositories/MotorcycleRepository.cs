namespace MXGP.Repositories
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private List<IMotorcycle> collection;

        public MotorcycleRepository()
        {
            this.collection = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle model)
        {
            this.collection.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            IReadOnlyCollection<IMotorcycle> collectionToReturn = collection.AsReadOnly();
            return collectionToReturn;
        }

        public IMotorcycle GetByName(string name)
        {
            return this.collection.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(IMotorcycle model)
        {
            if (this.collection.Contains(model))
            {
                this.collection.Remove(model);
                return true;
            }

            return false;
        }
    }
}
