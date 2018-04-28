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
    public class ItemDAO : AbstractItemDAO
    {
        public override List<BusinessObject> all(MyConnection connection)
        {
            List<BusinessObject> Items = new List<BusinessObject>(); ;
            
                string query = "SELECT * FROM Item";
                var cmd = new MySqlCommand(query, connection.ConnectionMysql);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Items.Add(new Item((string)reader["Title"],
                        (int)reader["ID"],
                        (Category)new CategoryDAO().get(connection, (int)reader["Category"]),
                        DateTime.Parse((string)reader["creationDate"]),
                        DateTime.Parse((string)reader["toDoForDate"]),
                        (string)reader["Commentary"],
                        (int)reader["user"]));
                }
            
            return Items;
        }

        public override void create(MyConnection connection, BusinessObject obj)
        {
            throw new NotImplementedException();
        }

        public override void delete(MyConnection connection, BusinessObject obj)
        {
            throw new NotImplementedException();
        }

        public override BusinessObject get(MyConnection connection, int id)
        {
            throw new NotImplementedException();
        }

        public override List<BusinessObject> getUserItems(MyConnection connection, User user)
        {
            throw new NotImplementedException();
        }

        public override void update(MyConnection connection, BusinessObject obj)
        {
            throw new NotImplementedException();
        }

        public override void updateToUser(MyConnection instance, Item item, User currentUser)
        {
            throw new NotImplementedException();
        }
    }
}
