namespace MXGP.Repositories
{
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class RiderRepository : IRepository<IRider>
    {
        private List<IRider> collection;

        public RiderRepository()
        {
            collection = new List<IRider>();
        }

        public void Add(IRider model)
        {
            this.collection.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            IReadOnlyCollection<IRider> collectionToReturn = collection.AsReadOnly();
            return collectionToReturn;
        }

        public IRider GetByName(string name)
        {
            return collection.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IRider model)
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
