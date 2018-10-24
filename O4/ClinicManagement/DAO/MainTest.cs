using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class MainTest
    {
        public static void Main(string[] args)
        {
            List<My> res = null;
            List<string> mes = null;
            DAOAdvance<My>.SqlSelExe(get,out res, mes);

            foreach(var i in res)
            {
                My l = i as My;
                System.Console.Write(l.Loai);
            }
        }

        private static List<My> get()
        {
            using (var db = new QLPHONGKHAMEntities())
            {
                List<My> res = (from l in db.LOAIHOSOes
                                      select new My { Loai = l.TenLoaiHoSo }).ToList();
                return res;
            }
        }
    }
    class My
    {
        public string Loai;
    }
}
