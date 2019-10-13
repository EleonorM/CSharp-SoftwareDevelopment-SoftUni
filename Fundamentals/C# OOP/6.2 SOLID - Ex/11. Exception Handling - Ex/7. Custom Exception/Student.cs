using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7._Custom_Exception
{
    public class Student
    {
        private string name;
        private string email;

        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.ToCharArray().Select(x => char.IsLetter(x)).Contains(false))
                {
                    throw new InvalidPersonNameException("The name should contains only letters");
                }
                this.name = value;
            }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}
