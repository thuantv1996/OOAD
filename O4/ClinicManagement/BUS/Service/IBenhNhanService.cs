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
        /// Lấy danh sách Bệnh Nhân
        /// </summary>
        /// <param name="ListBenhNhan">Danh sách Bệnh Nhân</param>
        /// <param name="MessageError">Thông báo lỗi</param>
        /// <returns>ID Result</returns>
        string GetListBenhNhan(out List<BenhNhanEnity> ListBenhNhan, out List<string> MessageError);
        /// <summary>
        /// Tìm bệnh nhân
        /// </summary>
        /// <param name="BenhNhanSearchEntity">Tên trường tìm kiếm</param>
        /// <param name="ListBenhNhan">Danh sách bệnh nhân</param>
        /// <param name="MessageError">Thông báo lỗi</param>
        /// <returns>ID Result</returns>
        string SearchBenhNhan(Enities.BenhNhanSearchEntity BenhNhanSearchEntity,out List<BenhNhanEnity> ListBenhNhan, out List<string> MessageError);
        /// <summary>
        /// Lấy thông tin Bệnh Nhân
        /// </summary>
        /// <param name="MaBenhNhan">Mã Bệnh Nhân</param>
        /// <param name="InformationBenhNhan">Thông tin Bệnh Nhân</param>
        /// <param name="MessageError">Thông báo lỗi</param>
        /// <returns>ID Result</returns>
        string GetInformationBenhNhan(string MaBenhNhan,out BENHNHAN InformationBenhNhan,out List<string> MessageError);
        /// <summary>
        /// Thêm mới Bệnh Nhân
        /// </summary>
        /// <param name="BenhNhan">Thông tin bệnh nhân</param>
        /// <param name="MessageError">Thông báo lỗi</param>
        /// <returns>ID Result</returns>
        string AddBenhNhan(BenhNhanEnity BenhNhan, out List<string> MessageError);
    }
}
