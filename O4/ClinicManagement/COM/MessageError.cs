using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM
{
    public class MessageError
    {
        public string IdError { get; set; }
        public string Message { get; set; }

        public void SetMessage(string Id,string Mes)
        {
            IdError = Id;
            Message = Mes;
        }
    }
}
