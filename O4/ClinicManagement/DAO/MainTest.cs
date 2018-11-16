using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COM;
using System.IO;
using DAO.Common;

namespace DAO
{
    class MainTest
    {
        public static void Main(string[] args)
        {
            QLPHONGKHAMEntities db = new QLPHONGKHAMEntities();
            BENHNHAN entity = new BENHNHAN { MaBenhNhan = "BN00000001", HoTen = "THUAn" };
            BENHNHAN benhNhan = db.BENHNHANs.Find(entity.MaBenhNhan);

            (db as QLPHONGKHAMEntities).Entry(benhNhan).CurrentValues.SetValues(entity);
            db.SaveChanges();

        }
    }
}
