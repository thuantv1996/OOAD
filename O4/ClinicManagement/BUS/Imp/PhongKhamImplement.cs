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
        /// <summary>
        /// LẤY DANH SÁCH PHÒNG KHÁM
        /// </summary>
        /// <param name="ListPhongKham"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
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
                // Khởi tạo Transaction
                using (var trans = db.Database.BeginTransaction())
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
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = Constant.RES_FAI;
                        // return 
                        return IdResult;
                    }
                    // Nếu không tìm thấy trường
                    if (LstResult.Count == 0)
                    {
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Không select được dữ liệu (Data is empty) - {0}", ProgramName)
                        });
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = Constant.RES_FAI;
                        // return 
                        return IdResult;
                    }
                }
            }
            // Sau khi lấy được danh sách, convert đối tượng PhongKham (DAO) sang PhongKhamEnity (DTO)
            foreach (PHONG PhongKham in LstResult)
            {
                PhongKhamEnity temp = new PhongKhamEnity();
                BUS.Com.Utils.CopyPropertiesFrom(PhongKham, temp);
                ListPhongKham.Add(temp);
            }
            // return 
            return IdResult;
        }

        /// <summary>
        /// LẤY THÔNG TIN PHÒNG KHÁM THEO MÃ PHÒNG KHÁM
        /// </summary>
        /// <param name="MaPhongKham"></param>
        /// <param name="InformationPhongKham"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
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
                //Khởi tạo transaction
                using (var trans = db.Database.BeginTransaction())
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
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = Constant.RES_FAI;
                        // return 
                        return IdResult;
                    }
                    // Nếu hàm select không trả về bất kỳ record nào
                    if (LstResult.Count == 0)
                    {
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Không select được dữ liệu (Data is empty) - {0}", ProgramName)
                        });
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = Constant.RES_FAI;
                        // return 
                        return IdResult;
                    }
                }
            }
            // Vì search trên Key nên chỉ trả về nhiều nhất 1 record 
            // Lấy record trả về
            PHONG SearchResult = LstResult.ToList().ElementAt(0);
            // Vì PHONG là kiểu dữ liệu của DAO nên không thể gửi lên GUI
            // => cần chuyển đối tượng DAO sang DTO vì GUI có thể sử dụng DTO
            // convert SearchResult từ DAO sang DTO
            BUS.Com.Utils.CopyPropertiesFrom(SearchResult, InformationPhongKham);
            // return 
            return IdResult;
        }
    }
}
