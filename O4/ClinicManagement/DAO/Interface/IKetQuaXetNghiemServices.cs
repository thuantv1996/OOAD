using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interface
{
    public interface IKetQuaXetNghiemServices : IBaseDAO<KETQUAXETNGHIEM>
    {
        string GetKetQuaXetNghiemWithIdHoSo(QLPHONGKHAMEntities db, string MaHoSo, out List<KETQUAXETNGHIEM> ListKetQuaXetNghiem);
    }
}
