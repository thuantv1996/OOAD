using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using BUS.Entities;
using COM;

namespace BUS
{
    class MainTest
    {
        public static void Main(string[] args)
        {
            QLPHONGKHAMEntities db = new QLPHONGKHAMEntities();
            DAO.Imp.BaseDAO dao = new DAO.Imp.BaseDAO();
            List<LOAIHOSO> DSLHS = null;
            List<MessageError> Message = null;
            // select all not condition
            dao.Select<LOAIHOSO>(db, out DSLHS, ref Message);
            // select with condition
            dao.Select<LOAIHOSO>(db, lhs=>lhs.MaLoaiHoSo.Equals("LHS0000001"), out DSLHS, ref Message);
            // select with SQL
            string sql = "SELECT * FROM LOAIHOSO WHERE ";
            HoSoSearchEnity SearchEntity = new HoSoSearchEnity { Id = "LHS0000001", Name = "Hồ sơ khám mới" };
            bool HasPrevCondition = false;
            if (SearchEntity.Id != "")
            {
                sql += "MaLoaiHoSo LIKE {0} ";
                HasPrevCondition = true;
            }
            if (SearchEntity.Name != "")
            {
                if (HasPrevCondition)
                {
                    sql += "and ";
                }
                sql += "MaLoaiHoSo LIKE {1}";
                HasPrevCondition = true;
            }
            object[] param = { "LHS0000001", SearchEntity.Name };
            dao.Select<LOAIHOSO>(db, sql, param, out DSLHS, ref Message);
           // BUS.Imp.BenhNhanImplement imp= new Imp.BenhNhanImplement();
            //imp.SearchBenhNhan();
            int end = 0;
        }
    }

    class HoSoSearchEnity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

}
