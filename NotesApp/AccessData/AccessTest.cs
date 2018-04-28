using Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOTest;

namespace AccessData
{
    public class AccessTest : AccessData
    {

        public AccessTest()
        {
            this.ItemDao = new DAOTest.ItemDAO();
            this.UserDao = new DAOTest.UserDAO();
            this.CategoryDao = new DAOTest.CategoryDAO();
        }
        public override void CloseConnect()
        {
        }

        public override void Connect()
        {
        }

    }
}

