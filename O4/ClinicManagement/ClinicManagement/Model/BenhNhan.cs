using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Model
{
    public class BenhNhan
    {
        public enum Sex
        {
            MALE,
            FEMALE,
            UNKNOWN
        }
        private string name;
        private string birthDay;
        private string identityCardNumber;
        private Sex sex;
        private string address;
        private string note;
    

        public BenhNhan(string name, string birthDay, string identityCardNumber, Sex sex, string address, string note)
        {
            this.name = name;
            this.birthDay = birthDay;
            this.identityCardNumber = identityCardNumber;
            this.sex = sex;
            this.address = address;
            this.note = note;
        }

        internal string getName()
        {
            return this.name;
        }

        public BenhNhan()
        {
        }

        public bool isValid(BenhNhan bn)
        {
            return true;
        }

        internal string getBirthDay()
        {
            return this.birthDay;
        }

        internal string getIdentityCardNumber()
        {
            return this.identityCardNumber;
        }

        internal string getNote()
        {
            return this.note;
        }

        internal string getSex()
        {
            switch (this.sex) {
                case Sex.MALE: return "Nam";
                case Sex.FEMALE: return "Nữ";
                default: return "Không biết";
            }
        }
    }
}
