using Business;
using Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public abstract class AbstractCategoryDAO: DataAccessObject
    {
        public abstract List<BusinessObject> allUserCategories(MyConnection instance, User user);
    }
}
