using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    class MainTest
    {
        public static void Main(string[] args)
        {
            A a = new A { A1 = "a", A2 = "b"};
            B b = new BUS.B();
            BUS.Com.Utils.CopyPropertiesFrom(a, b);
            int end = 0;
        }
    }

    class A
    {
        public string A1 { get; set; }
        public string A2 { get; set; }
        public Nullable<int> A3 { get; set; }
    }

    class B
    {
        public string A1 { get; set; }
        public string A2 { get; set; }
        public int A3 { get; set; }
    }
}
