using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using MySql.Data.MySqlClient;
using Connection;
using DAO;
using DAOSQL;

namespace AccessData
{
    
    public class AccessSQL : AccessData
    {

        public AccessSQL()
        {
            this.ItemDao = new DAOSQL.ItemDAO();
            this.UserDao = new DAOSQL.UserDAO();
            this.CategoryDao = new DAOSQL.CategoryDAO();
        }

        public override void Connect()
        {
            if (!MyConnection.Instance.HasMySQLConnection()) { 
                MyConnection.Instance.InitSQL(MyDatabase.DATABASE_NAME, MyDatabase.PASSWORD, MyDatabase.PORT,MyDatabase.SERVOR, MyDatabase.USER_ID);
            }
        }

        public override void CloseConnect()
        {
            MyConnection.Instance.ConnectionMysql.Close();
            MyConnection.Instance.ConnectionMysql = null;
        }

       
    }
    class MyDatabase
    {
        public const string DATABASE_NAME = "u543404562_notes";

        public const string USER_ID = "u543404562_admin";

        public const string PASSWORD = "9*65C08ab";

        public const string SERVOR = "mysql.hostinger.fr";

        public const string PORT = "3306";
    }
}
