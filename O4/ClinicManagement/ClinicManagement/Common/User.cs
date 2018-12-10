using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Common
{
    public enum UserType
    {
        reception,
        analysis,
        examination
    }

    public class User
    {

        private static User sharedInstance;
        public static User SharedInstance
        {
            get
            {
                if (sharedInstance == null)
                    sharedInstance = new User();
                return sharedInstance;
            }
        }

        public UserType UserType { get; set; }

        public string UserName { get; set; }

        public string RoomId { get; set; }

        public string UserId { get; set; }

        public User(ClinicManagement.Common.UserType type)
        {
            this.UserType = type;
        }

        private User() { }
    }
}
