using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interface
{
    public interface IBenhNhanServices : IBaseDAO<BENHNHAN>
    {
        string GetDataWithParameter(QLPHONGKHAMEntities db, object[] param, out List<BENHNHAN> listBenhNhan);
    }
}
