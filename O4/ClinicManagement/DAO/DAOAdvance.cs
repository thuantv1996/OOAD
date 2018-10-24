using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAOAdvance<T>
    {
        /// <summary>
        /// Thực thi lấy dữ liệu từ database từ sql được viết trong function
        /// </summary>
        /// <param name="SqlFunc">Hàm chứa sql (Linq)</param>
        /// <returns>Danh sách dữ liệu gửi về</returns>
        public static string SqlSelExe(Func<List<T>> SqlFunc,out List<T> LstEntRes,List<String> Messages)
        {
            using (var db = new QLPHONGKHAMEntities())
            {
                try
                {
                    LstEntRes = SqlFunc();
                }
                catch(Exception e)
                {
                    LstEntRes = null;
                    Messages = new List<string>();
                    Messages.Add(DAOMessage.MES_DAO_001);
                    return DAOConstant.RES_FAI;
                }           
            }
            return DAOConstant.RES_SUC;
        }
    }
}
