using System.Collections.Generic;
using System.Linq;
using BUS.Service;
using DAO;
using DTO;
using COM;
using BUS.Entities;

namespace BUS.Imp
{
    public class PhongKhamImplement : IPhongKhamService
    {
        public string GetListPhongKham(out List<PhongKhamEnity> ListPhongKham, ref List<MessageError> Messages)
        {
            string ProgramName = "PhongKhamImplement_GetListPhongKham";
            // Danh sách phòng khám (DTO) trả về
            ListPhongKham = new List<PhongKhamEnity>();
            // Danh sách phòng khám (DAO) Nhận được từ function select
            List<PHONG> LstResult = null;
            // Result code
            string IdResult = "";
            // Khởi tạo Database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo lớp DAO
                DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                // Thực hiện lệnh SELECT
                IdResult = Dao.Select(db, out LstResult, ref Messages);
                // Nếu không thực hiện được lệnh SELECT
                if (IdResult == Constant.RES_FAI)
                {
                    Messages.Add(new MessageError
                    {
                        IdError = Constant.MES_DB,
                        Message = string.Format("Lỗi Database trong truy vấn select table PHONG - {0}", ProgramName)
                    });
                    // Return faild
                    return Constant.RES_FAI;
                }
                // Nếu không tìm thấy record
                if (LstResult.Count == 0)
                {
                    Messages.Add(new MessageError
                    {
                        IdError = Constant.MES_DB,
                        Message = string.Format("Không select được dữ liệu (Data is empty) - {0}", ProgramName)
                    });
                    // Return faild
                    return Constant.RES_FAI;
                }
            }
            // Sau khi lấy được danh sách, convert đối tượng PhongKham (DAO) sang PhongKhamEnity (DTO)
            foreach (PHONG phong in LstResult)
            {
                PhongKhamEnity temp = new PhongKhamEnity();
                BUS.Com.Utils.CopyPropertiesFrom(phong, temp);
                ListPhongKham.Add(temp);
            }
            // return 
            return IdResult;
        }

        public string GetInformationPhongKham(string MaPhongKham, out PhongKhamEnity InformationPhongKham, ref List<MessageError> Messages)
        {
            string ProgramName = "PhongKhamImplement_GetInformationPhongKham";
            // khởi tạo đối tượng Phòng Khám (DTO) trả về
            InformationPhongKham = new PhongKhamEnity();
            // Khai báo danh sách đối tượng Phòng Khám (DAO) đón nhận data từ function select 
            List<PHONG> LstResult = null;
            // Kết quả trả về
            string IdResult = "";
            // Khởi tạo Database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo lớp DAO
                DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                // Thực hiện lệnh SELECT
                IdResult = Dao.Select(db, bn => bn.MaPhong.Equals(MaPhongKham), out LstResult, ref Messages);
                // Nếu hàm select báo lỗi
                if (IdResult == Constant.RES_FAI)
                {
                    // Thêm thông báo lỗi
                    Messages.Add(new MessageError
                    {
                        IdError = Constant.MES_DB,
                        Message = string.Format("Lỗi truy vấn select table PHONG - {0}", ProgramName)
                    });
                    // Return faild
                    return Constant.RES_FAI;
                }
                // Nếu hàm select không trả về bất kỳ record nào
                if (LstResult.Count == 0)
                {
                    Messages.Add(new MessageError
                    {
                        IdError = Constant.MES_DB,
                        Message = string.Format("Không select được dữ liệu (Data is empty) - {0}", ProgramName)
                    });
                    // Return faild
                    return Constant.RES_FAI;
                }
            }
            // Lấy record trả về
            PHONG SearchResult = LstResult.ToList().ElementAt(0);
            BUS.Com.Utils.CopyPropertiesFrom(SearchResult, InformationPhongKham);
            // return 
            return Constant.RES_SUC;
        }
    }
}
