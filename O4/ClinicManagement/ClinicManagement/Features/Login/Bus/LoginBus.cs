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

        public void Login(TaiKhoanDTO account, Action<List<MessageError>, string> completion)
        {
            var listMessageError = new List<MessageError>();
            var result = this.loginBusClient.DangNhapProcess(account);
            completion(listMessageError, result);
        }
    }
}
