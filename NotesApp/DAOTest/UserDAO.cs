using Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection;
using DAO;

namespace DAOTest
{
    public class UserDAO : AbstractUserDAO
    {
        List<BusinessObject> users = new List<BusinessObject>{ new User(1, "password", "name") };

        public override List<BusinessObject> all(MyConnection connection)
        {
            return users;
        }

        public override void create(MyConnection connection, BusinessObject obj)
        {
            users.Add(new User(2, "password2", "name2"));
        }

        public override void delete(MyConnection connection, BusinessObject obj)
        {
            users.Remove((User)obj)
;        }

        public override BusinessObject get(MyConnection connection, int id)
        {
            List<User> Users= users.Cast<User>().ToList();
            return (User) Users.Where(user => user.ID == id).Take(0);
        }

        public override void update(MyConnection connection, BusinessObject obj)
        {
            List<User> Users = users.Cast<User>().ToList();
            User userObj = (User)obj;
            User theUser = (User) Users.Where(user => user.ID == userObj.ID).Take(0);
            theUser.Items = userObj.Items;
            theUser.Name = userObj.Name;
            theUser.Password = userObj.Password;
        }
    }
}
