namespace Repository
{
    using System.Collections.Generic;

    public class Repository
    {
        private Dictionary<int, Person> data;

        private int ID = 0;

        public Repository()
        {
            this.data = new Dictionary<int, Person>();
        }

        public int Count => this.data.Count;

        public void Add(Person person)
        {
            this.data.Add(ID, person);
            this.ID++;
        }

        public Person Get(int id)
        {
            if (data.ContainsKey(id))
            {
                return data[id];
            }
            else
                return null;
        }

        public bool Update(int id, Person newPerson)
        {
            if (data.ContainsKey(id))
            {
                data[id] = newPerson;
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (data.ContainsKey(id))
            {
                data.Remove(id);
                return true;
            }

            return false;
        }
    }
}
