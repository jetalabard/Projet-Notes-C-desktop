using DAO;
using Business;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection;

namespace DAOSQL
{
    public class UserDAO: AbstractUserDAO
    {
        public override List<BusinessObject> all(MyConnection connection)
        {
            List<BusinessObject> Users = new List<BusinessObject>();
                string query = "SELECT * FROM User";

                var cmd = new MySqlCommand(query, connection.ConnectionMysql);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Users.Add(new User((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2)));
                }
               
            return Users;
        }


        public override void create(MyConnection connection, BusinessObject obj)
        {
            throw new NotImplementedException();
        }

        public override void delete(MyConnection connection, BusinessObject obj)
        {
            throw new NotImplementedException();
        }

        public override  BusinessObject get(MyConnection connection, int id)
        {
            throw new NotImplementedException();
        }
        

        public override void update(MyConnection connection, BusinessObject obj)
        {
            throw new NotImplementedException();
        }
    }
}
