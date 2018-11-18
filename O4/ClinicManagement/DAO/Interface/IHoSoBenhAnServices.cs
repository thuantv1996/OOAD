using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interface
{
    public interface IHoSoBenhAnServices : IBaseDAO<HOSOBENHAN>
    {
        string SearchHoSo(QLPHONGKHAMEntities db, object[] param, out List<HOSOBENHAN> listHoSo);
        string GetListHoSoWithRoomAndNode(QLPHONGKHAMEntities db, object[] param, out List<HOSOBENHAN> listHoSo);
        string GetRootHoSo(QLPHONGKHAMEntities db, string MaHoSoTruoc, out HOSOBENHAN hoSoBenhAnRoot);
        string CreateId(QLPHONGKHAMEntities db, out string Id);
        string GetListHoSoWithIdBenhNhan(QLPHONGKHAMEntities db, string MaBenhNhan, out List<HOSOBENHAN> ListHoSo);
    }
}
