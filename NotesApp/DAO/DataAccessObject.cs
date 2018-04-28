using Connection;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public abstract class DataAccessObject
    {
        public abstract List<BusinessObject> all(MyConnection connection);

        public abstract BusinessObject get(MyConnection connection,int id);

        public abstract void update(MyConnection connection,BusinessObject obj);

        public abstract void create(MyConnection connection, BusinessObject obj);

        public abstract void delete(MyConnection connection,BusinessObject obj);

    }

}
