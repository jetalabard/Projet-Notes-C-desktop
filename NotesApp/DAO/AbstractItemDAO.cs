using Business;
using Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public abstract class AbstractItemDAO : DataAccessObject
    {
        public abstract List<BusinessObject> getUserItems(MyConnection connection, User user);

        public abstract void updateToUser(MyConnection instance, Item item, User currentUser);
    }
}
