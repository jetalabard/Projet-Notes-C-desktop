
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using MySql.Data.MySqlClient;
using DAO;
using Connection;

namespace DAOSQL
{
    public class CategoryDAO : AbstractCategoryDAO
    {

        public override List<BusinessObject> all(MyConnection connection)
        {
            List<BusinessObject> Categories = new List<BusinessObject>();
            string query = "SELECT * FROM Category";

            var cmd = new MySqlCommand(query, connection.ConnectionMysql);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Categories.Add(new Category((string)reader["Title"], (int)reader["ID"]));
            }
            return Categories;
        }

        public override void delete(MyConnection connection, BusinessObject obj)
        {
            throw new NotImplementedException();
        }

        public override BusinessObject get(MyConnection connection, int id)
        {
            Category Category = null;

            string query = "SELECT * FROM Category where ID = " + id;

            var cmd = new MySqlCommand(query, connection.ConnectionMysql);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Category = new Category((string)reader["Title"], (int)reader["ID"]);
            }

            return Category;
        }

        public override void create(MyConnection connection, BusinessObject obj)
        {
            throw new NotImplementedException();
        }

        public override void update(MyConnection connection, BusinessObject obj)
        {
            throw new NotImplementedException();
        }

        public override List<BusinessObject> allUserCategories(MyConnection instance, User user)
        {
            throw new NotImplementedException();
        }
    }
}
