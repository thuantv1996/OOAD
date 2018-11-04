using System.Collections.Generic;
using System.Linq;
using BUS.Service;
using DAO;
using DTO;
using COM;
using BUS.Entities;

namespace BUS.Imp
{
    public class TrangThaiPhongImplement : ITrangThaiPhongService
    {
        /// <summary>
        /// LẤY THÔNG TIN TRẠNG THÁI PHÒNG
        /// </summary>
        /// <param name="MaPhongKham"></param>
        /// <param name="NgayThang"></param>
        /// <param name="TrangThaiPhong"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
        public string GetTrangThaiPhong(string MaPhongKham, string NgayThang, out TrangThaiPhongEnity TrangThaiPhong, ref List<MessageError> Messages)
        {
            string ProgramName = "TrangThaiPhongImplement_GetTrangThaiPhong";
            // khởi tạo đối tượng Trạng thái phòng (DTO) trả về
            TrangThaiPhong = new TrangThaiPhongEnity();
            // Khai báo danh sách đối tượng Trạng thái phòng (DAO) đón nhận data từ function select 
            List<TRANGTHAIPHONG> LstResult = null;
            // Kết quả trả về
            string IdResult = "";
            // Khởi tạo database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo lớp DAO
                DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                // Thực hiện lệnh SELECT
                IdResult = Dao.Select(db, tt => tt.MaPhong.Equals(MaPhongKham) && tt.NgayKham.Equals(NgayThang), out LstResult, ref Messages);
                // Nếu hàm select báo lỗi
                if (IdResult == Constant.RES_FAI)
                {
                    // Thêm thông báo lỗi
                    Messages.Add(new MessageError
                    {
                        IdError = Constant.MES_DB,
                        Message = string.Format("Lỗi truy vấn select table TRANGTHAIPHONG - {0}", ProgramName)
                    });
                    // Return faild
                    IdResult = Constant.RES_FAI;
                    // return 
                    return IdResult;
                }
                // Nếu hàm select không trả về bất kỳ record nào
                if (LstResult.Count == 0)
                {
                    // Khởi tạo transaction
                    using (var trans = db.Database.BeginTransaction())
                    {
                        // Tạo đối tượng trạng thái phòng
                        TRANGTHAIPHONG TrangThai = new TRANGTHAIPHONG { MaPhong = TrangThaiPhong.MaPhong, NgayKham = TrangThaiPhong.NgayKham, SttCaoNhat = 0 };
                        // Thực hiện lệnh insert
                        IdResult = Dao.Insert(TrangThaiPhong, db, ref Messages);
                        // Nếu sai
                        if(IdResult == Constant.RES_FAI)
                        {
                            return Constant.RES_FAI;
                        }
                        trans.Commit();
                        // Hàm đệ quy
                        return GetTrangThaiPhong(MaPhongKham, NgayThang, out TrangThaiPhong, ref Messages);
                    }
                }

                // Tạo đổi tượng TranThaiPhongEnity
                TrangThaiPhong = new TrangThaiPhongEnity();
                // Lấy ra record đầu tiên sau khi select
                TRANGTHAIPHONG SearchResultTT = LstResult.ToList().ElementAt(0);
                // Convert SearchResult từ DAO sang DTO
                BUS.Com.Utils.CopyPropertiesFrom(SearchResultTT, TrangThaiPhong);
                // Return
                return Constant.RES_SUC;
            }
        }
    
        /// <summary>
        /// UPDATE TRẠNG THÁI PHÒNG
        /// </summary>
        /// <param name="TrangThaiPhong"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
        public string UpdateTrangThaiPhong(TrangThaiPhongEnity TrangThaiPhong, ref List<MessageError> Messages)
        {
            string ProgramName = "TrangThaiPhongImplement_UpdateTrangThaiPhong";
            // Kết quả trả về
            string IdResult = "";
            // Tạo đối tượng TRANGTHAIPHONG kết quả
            TRANGTHAIPHONG TrangThaiPhongResult = new TRANGTHAIPHONG();
            // Convert đối tượng từ DTO sang DAO
            BUS.Com.Utils.CopyPropertiesFrom(TrangThaiPhong, TrangThaiPhongResult);
            // Khởi tạo Database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo transaction 
                using (var trans = db.Database.BeginTransaction())
                {
                    // Khởi tạo lớp DAO
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    // Thực hiện lệnh INSERT
                    IdResult = Dao.Update(TrangThaiPhongResult, db, ref Messages);
                    // Nếu hàm INSERT báo lỗi
                    if (IdResult == Constant.RES_FAI)
                    {
                        // Thêm thông báo lỗi
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Lỗi khi Update vao Table TRANGTHAIPHONG - {0}", ProgramName)
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
            return IdResult;
        }
    }
    }
}
