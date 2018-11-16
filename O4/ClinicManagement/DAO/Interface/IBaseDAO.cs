using COM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interface
{
    interface IBaseDAO<T> where T : class
    {
        string Save(DbContext db, T entity);

        string Delete(DbContext db, T entity);

        string Select(DbContext db, out List<T> listObject);

        string FindById(DbContext db,object[] id, out T entity);
    }
}
