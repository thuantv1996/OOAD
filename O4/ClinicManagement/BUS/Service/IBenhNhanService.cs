using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;


namespace BUS.Service
{
    interface IBenhNhanService
    {
        /// <summary>
        /// HÀM LẤY DANH SÁCH BỆNH NHÂN
        /// </summary>
        /// <param name="ListBenhNhan">Danh sách Bệnh nhân trả về</param>
        /// <param name="MessageError">Thông điệp lỗi</param>
        /// <returns>Result Code</returns>
        string GetListBenhNhan(out List<BenhNhanEnity> ListBenhNhan, out List<string> MessageError);

        /// <summary>
        /// TÌM KIẾM THÔNG TIN BỆNH NHÂN
        /// </summary>
        /// <param name="BenhNhanSearchEntity">Key Search</param>
        /// <param name="ListBenhNhan">Danh sách Bệnh nhân trả về</param>
        /// <param name="MessageError">Thông điệp lỗi</param>
        /// <returns>Result Code</returns>
        string SearchBenhNhan(Enities.BenhNhanSearchEntity BenhNhanSearchEntity,out List<BenhNhanEnity> ListBenhNhan, out List<string> MessageError);
        
        /// <summary>
        /// LẤY THÔNG TIN BỆNH NHÂN KHI BIẾT MÃ
        /// </summary>
        /// <param name="MaBenhNhan">Mã bệnh nhân</param>
        /// <param name="InformationBenhNhan">Kết quả trả về</param>
        /// <param name="MessangeError">Thông điệp lỗi</param>
        /// <returns>Result Code</returns>
        string GetInformationBenhNhan(string MaBenhNhan,out BenhNhanEnity InformationBenhNhan,out List<string> MessageError);
        
        /// <summary>
        /// THÊM MỚI MỘT BỆNH NHÂN
        /// </summary>
        /// <param name="BenhNhan">Thông tin bệnh nhân</param>
        /// <param name="MessageError">Thông báo lỗi</param>
        /// <returns>ID Result</returns>
        string AddBenhNhan(BenhNhanEnity BenhNhan, out List<string> MessageError);
    }
}
