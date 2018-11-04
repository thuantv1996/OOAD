using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum SexType
    {
        male,
        female,
        unknow
    }
    public struct StructSex
    {
        public SexType type;

        public StructSex(string sexString)
        {
            this.type = sexString.Equals("Nam") ? SexType.male : (sexString.Equals("Nữ") ? SexType.female : SexType.unknow);
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

    public class Patient
    {
        private string name;
        private DateTime birthDay;
        private string identityCardNumber;
        private StructSex sex;
        private string address;
        private string note;
        private string idNumber;
        private string phoneNumber;

        public Patient(string name, DateTime birthDay, string idNumber, StructSex sex, string address, string note)
        {
            this.name = name;
            this.birthDay = birthDay;
            this.idNumber = idNumber;
            this.sex = sex;
            this.address = address;
            this.note = note;
        }

        public Patient(string name, DateTime birthDay, StructSex sex, string address, string note)
        {
            this.name = name;
            this.birthDay = birthDay;
            this.sex = sex;
            this.address = address;
            this.note = note;
        }

        public Patient(string name, string birthDay, string idNumber, StructSex sex, string address, string note)
        {
            this.name = name;
            this.birthDay = this.convertDateTime(birthDay);
            this.idNumber = idNumber;
            this.sex = sex;
            this.address = address;
            this.note = note;
        }

        public Patient()
        {
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

        public StructSex Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public DateTime BirthDay
        {
            get { return this.birthDay; }
            set { this.birthDay = value; }
        }

        public string IdentityCardNumber
        {
            get { return this.identityCardNumber; }
            set { this.identityCardNumber = value; }
        }

        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public string Note
        {
            get { return this.note; }
            set { this.note = value; }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        public string IdNumber
        {
            get { return this.idNumber; }
            set { this.idNumber = value; }
        }

        public override string ToString()
        {
            return this.Name + "\n" + this.BirthDay + "\n" + this.IdentityCardNumber + "\n" + this.Sex.ToString() + "\n" + this.Address + "\n" + this.Note + "\n" + this.IdNumber + "\n" + this.PhoneNumber;
        }
    }
}
