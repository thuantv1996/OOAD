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
        public const int ID_SUCCESS = 0;
        public const int ID_ERROR_BACK_LOGIN = 1;
        public const int ID_ERROR_CHANGE_PASSWORD = 2;

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

        public void Login(TaiKhoanEnity account, Action<List<MessageError>, int, string> completion)
        {
            var listMessageError = new List<MessageError>();
            var idScreen = ID_SUCCESS;
            var result = this.loginBusClient.DangNhapProcess(account, ref listMessageError, out idScreen);
            completion(listMessageError, idScreen, result);
        }
    }
}
