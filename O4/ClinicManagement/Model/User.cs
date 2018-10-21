using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum UserType
    {
        reception,
        analysis,
        examination
    }

    public class User
    {
        public UserType UserType { get; set; }

        public User(UserType type)
        {
            this.UserType = type;
        }
    }
}
