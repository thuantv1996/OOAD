
using System.Collections.Generic;
using DTO;
using COM;
using BUS.Entities;


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
        string GetListBenhNhan(out List<BenhNhanEnity> ListBenhNhan, ref List<MessageError> Messages);

        /// <summary>
        /// TÌM KIẾM THÔNG TIN BỆNH NHÂN
        /// </summary>
        /// <param name="BenhNhanSearchEntity">Key Search</param>
        /// <param name="ListBenhNhan">Danh sách Bệnh nhân trả về</param>
        /// <param name="MessageError">Thông điệp lỗi</param>
        /// <returns>Result Code</returns>
        string SearchBenhNhan(BenhNhanSearchEntity BenhNhanSearchEntity,out List<BenhNhanEnity> ListBenhNhan, ref List<MessageError> Messages);
        
        /// <summary>
        /// LẤY THÔNG TIN BỆNH NHÂN KHI BIẾT MÃ
        /// </summary>
        /// <param name="MaBenhNhan">Mã bệnh nhân</param>
        /// <param name="InformationBenhNhan">Kết quả trả về</param>
        /// <param name="MessangeError">Thông điệp lỗi</param>
        /// <returns>Result Code</returns>
        string GetInformationBenhNhan(string MaBenhNhan,out BenhNhanEnity InformationBenhNhan, ref List<MessageError> Messages);
        
        /// <summary>
        /// THÊM MỚI MỘT BỆNH NHÂN
        /// </summary>
        /// <param name="BenhNhan">Thông tin bệnh nhân</param>
        /// <param name="MessageError">Thông báo lỗi</param>
        /// <returns>ID Result</returns>
        string InsertBenhNhan(BenhNhanEnity BenhNhan, ref List<MessageError> Messages);

        /// <summary>
        /// UPDATE THÔNG TIN BỆNH NHÂN
        /// </summary>
        /// <param name="BenhNhan"></param>
        /// <param name="MessagError"></param>
        /// <returns></returns>
        string UpdateBenhNhan(BenhNhanEnity BenhNhan, ref List<MessageError> Messages);
    }
}
