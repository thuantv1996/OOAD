using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Enities;
using BUS.Service;
using DTO;
using DAO;
using COM;

namespace BUS.Imp
{
    class HoSoImplement : IHoSoService
    {
        public string AddHoSo(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSo, ref List<MessageError> Messages)
        {
            // Nếu HoSo là null thì 
            // Thêm message error 
            // Return fail

            // Tạo đối tượng HoSoDAO
            // Copy property từ HoSo sang HoSoDAO

            // Tạo đối tượng DAO
            // Thực thi insert HoSo

            // Nếu lệnh insert fail
            // Thêm Message Error
            // Return fail

            // return success

        }

        public string DeleteHoSo(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSo, ref List<MessageError> Messages)
        {
            // Nếu HoSo là null thì 
            // Thêm message error 
            // Return fail

            // Tạo đối tượng HoSoDAO
            // Copy property từ HoSo sang HoSoDAO

            // Tạo đối tượng DAO
            // Thực thi delete HoSo

            // Nếu lệnh delete fail
            // Thêm Message Error
            // Return fail

            // return success
        }

        public string GetInfomationHoSo(string MaHoSo, out HoSoBenhAnEntity HoSo, ref List<MessageError> Messages)
        {
            // khởi tạo đối tượng HoSo
            // Khởi tạo danh sách HoSoDAO trả về 
            // Khởi tạo DB
            // Khởi tạo transaction
            // Khởi tạo DAO
            // Thực thi lệnh Select 
            // nếu lệnh select return fail 
            // Thêm message error
            // Return fail
            // Nếu không select được bất cứ record nào
            // Thêm message error
            // Return fail
            // Tạo đối tượng HoSoDAO get record thứ 0 của danh sách trả về
            // copy property HoSoDAO sang HoSo Entity
            // return succes
        }

        public string GetListHoSo(out List<HoSoBenhAnEntity> ListHoSo, ref List<MessageError> Messages)
        {
            // khởi tạo đối tượng ListHoSo
            // Khởi tạo danh sách HoSoDAO trả về 
            // Khởi tạo DB
            // Khởi tạo transaction
            // Khởi tạo DAO
            // Thực thi lệnh Select 
            // nếu lệnh select return fail 
            // Thêm message error
            // Return fail
            // Nếu không select được bất cứ record nào
            // Thêm message error
            // Return fail
            // Duyệt qua danh sách trả về
            // Tạo mới một HoSoEntity
            // Copy property của từng đối tượng trong danh sách DAO trả về cho HoSoEntity
            // Add HoSoEntity vào ListHoSo
            // return succes
        }

        public string SearchHoSo(HoSoSearchEntity HoSoSearch, out List<HoSoBenhAnEntity> ListHoSo, ref List<MessageError> Messages)
        {
            // khởi tạo đối tượng ListHoSo
            // Khởi tạo danh sách HoSoDAO trả về 
            // Khởi tạo DB
            // Khởi tạo transaction
            // Khởi tạo DAO
            // Thực thi lệnh Select 
            // nếu lệnh select return fail 
            // Thêm message error
            // Return fail
            // Nếu không select được bất cứ record nào
            // Thêm message error
            // Return fail
            // Duyệt qua danh sách trả về
            // Tạo mới một HoSoEntity
            // Copy property của từng đối tượng trong danh sách DAO trả về cho HoSoEntity
            // Add HoSoEntity vào ListHoSo
            // return succes
        }

        public string UpdateHoSo(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSo, ref List<MessageError> Messages)
        {
            // Nếu HoSo là null thì 
            // Thêm message error 
            // Return fail

            // Tạo đối tượng HoSoDAO
            // Copy property từ HoSo sang HoSoDAO

            // Tạo đối tượng DAO
            // Thực thi delete HoSo

            // Nếu lệnh delete fail
            // Thêm Message Error
            // Return fail

            // return success
        }
    }
}
