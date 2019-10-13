namespace ViceCity.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Repositories.Contracts;

    public class GunRepository : IRepository<IGun>
    {
        private ICollection<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.guns.ToList().AsReadOnly();

        public void Add(IGun model)
        {
            if (this.guns.FirstOrDefault(x => x.Name == model.Name) == null)
            {
                this.guns.Add(model);
            }
        }

        public IGun Find(string name)
        {
            return this.guns.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IGun model)
        {
            var gunToRemove = this.guns.FirstOrDefault(x => x.Name == model.Name);
            if (gunToRemove != null)
            {
                this.guns.Remove(model);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
