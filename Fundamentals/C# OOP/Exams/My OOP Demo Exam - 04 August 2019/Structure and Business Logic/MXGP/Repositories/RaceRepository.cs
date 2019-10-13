namespace MXGP.Repositories
{
    using MXGP.Models.Races.Contracts;
    using MXGP.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> collection;

        public RaceRepository()
        {
            this.collection = new List<IRace>();
        }

        public void Add(IRace model)
        {
            this.collection.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            IReadOnlyCollection<IRace> collectionToReturn = collection.AsReadOnly();
            return collectionToReturn;
        }

        public IRace GetByName(string name)
        {
            return this.collection.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IRace model)
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
