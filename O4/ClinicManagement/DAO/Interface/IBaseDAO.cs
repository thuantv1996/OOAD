using System.Collections.Generic;
using System.Data.Entity;

namespace DAO.Interface
{
    public interface IBaseDAO<T> where T : class
    {
        string Save(DbContext db, T entity);

        string Delete(DbContext db, T entity);

        string Select(DbContext db, out List<T> listObject);

        string FindById(DbContext db,object[] id, out T entity);
    }
}
