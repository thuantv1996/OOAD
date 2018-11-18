using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interface
{
    public interface INhanVienServices : IBaseDAO<NHANVIEN>
    {
        string GetListNhanVienWithIdRoom(QLPHONGKHAMEntities db, object[] param, out List<NHANVIEN> listEntity);
    }
}
