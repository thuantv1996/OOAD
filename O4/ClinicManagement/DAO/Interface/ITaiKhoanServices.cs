using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interface
{
    public interface ITaiKhoanServices : IBaseDAO<TAIKHOAN>
    {
        string FindByParameter(QLPHONGKHAMEntities db, object[] param, out TAIKHOAN taiKhoan);
    }
}
