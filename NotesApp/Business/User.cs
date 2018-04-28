using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class User : BusinessObject, IComparable<User>
    {
        public User(int id, string password,string name)
        {
            this.ID = id;
            this.Name = name;
            this.Password = password;
            this.Items = null;
        }

        public User(int id, string password, string email,List<Item> items)
            :this(id, password,email)
        {
            this.Items = items;
        }

        public int ID
        {
            get;
        }

        public string Name
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public List<Item> Items
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            User user = obj as User;

            return user.Name == this.Name && user.Password == this.Password;
        }

        public override int GetHashCode()
        {
            return ID;
        }

        public int CompareTo(User other)
        {
            return Name.CompareTo(other.Name);
        }
        

        public override String ToString()
        {
            return Name + " " + ID;
        }

    }


}
