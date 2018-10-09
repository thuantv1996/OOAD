using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Common.Model
{
    public class Patient
    {
        public enum SexType {
            male,
            female,
            unknow
        }
        public struct Sex
        {
            public SexType type;

            public Sex(string sexString)
            {
                this.type = sexString.Equals("Nam") ? SexType.male : (sexString.Equals("Nữ") ? SexType.female : SexType.female); 
            }

            public override string ToString()
            {
                switch (type)
                {
                    case SexType.male: return "Nam";
                    case SexType.female: return "Nữ";
                    default: return "Không biết";
                }
            }
        }

        private string name;
        private DateTime birthDay;
        private string identityCardNumber;
        private Sex sex;
        private string address;
        private string note;
        private string idNumber;

        public Patient(string name, DateTime birthDay, string idNumber, Sex sex, string address, string note)
        {
            this.name = name;
            this.birthDay = birthDay;
            this.idNumber = idNumber;
            this.sex = sex;
            this.address = address;
            this.note = note;
        }

        public Patient(string name, string birthDay, string idNumber, Sex sex, string address, string note)
        {
            this.name = name;
            this.birthDay = this.convertDateTime(birthDay);
            this.idNumber = idNumber;
            this.sex = sex;
            this.address = address;
            this.note = note;
        }

        private DateTime convertDateTime(string dateString)
        {
            var elements = dateString.Split('/').ToList();
            var month = int.Parse(elements.First());
            var year = int.Parse(elements.Last());
            elements.Remove(elements.First());
            var day = int.Parse(elements.First());
            return new DateTime(year, month, day);
        }

        internal Sex getSex()
        {
            return this.sex;
        }

        internal string getName()
        {
            return this.name;
        }

        internal DateTime getBirthDay()
        {
            return this.birthDay;
        }

        internal string getIdentityCardNumber()
        {
            return this.identityCardNumber;
        }

        internal string getAddress()
        {
            return this.address;
        }

        internal string getNote()
        {
            return this.note;
        }
    }
}
