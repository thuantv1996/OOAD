using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;


namespace BUS.Service
{
    interface IDangNhapService

    {
        string GetListTaiKhoan(Enities.DangNhapSearchEntity DangNhapSearchEntity, out List<DangNhapEnity> ListTaiKhoan, out List<string> MessageError);

        string UpdatePass(DangNhapEnity MaTaiKhoan, DangNhapEnity MatKhau, out List<string> MessageError);

        string DangNhapSelect(DangNhapEnity MaTaiKhoan, DangNhapEnity MatKhau, out List<string> MessageError);

        

        string Update(Enities.DangNhapSearchEntity DangNhapSearchEntity, out List<DangNhapEnity> ListTaiKhoan, out List<string> MessageError);

        string Delete(DangNhapEnity MaTaiKhoan, out List<string> MessageError);


    }
}
