using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS;
using DTO;
using COM;

namespace ClinicManagement.Features.Login.Bus
{
    class LoginBus
    {
        private static LoginBus instance;
        public static LoginBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoginBus();
                return instance;
            }
        }

        private BUS.Mdl.DangNhapModule loginBusClient;

        private LoginBus()
        {
            this.loginBusClient = new BUS.Mdl.DangNhapModule();
        }

        public void Login(TaiKhoanDTO account, Action<List<MessageError>, string, string> completion)
        {
            var listMessageError = new List<MessageError>();
            string MaNV = null;
            var result = this.loginBusClient.DangNhapProcess(account, out MaNV);
            completion(listMessageError, result, MaNV);
        }

        public DTO.NhanVienDTO getNhanVienInformation(string MaNhanVien)
        {
            DTO.NhanVienDTO nhanVien = null;
            this.loginBusClient.GetInformationNhanVien(MaNhanVien, out nhanVien);
            return nhanVien;
        }
    }
}
