using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS.Com
{
    public class Utils
    {
        public static void CopyPropertiesFrom(object parent, object self)
        {
            var fromProperties = parent.GetType().GetProperties();
            var toProperties = self.GetType().GetProperties();

            foreach (var fromProperty in fromProperties)
            {
                foreach (var toProperty in toProperties)
                {
                    if (fromProperty.Name == toProperty.Name)
                    {
                        try
                        {
                            toProperty.SetValue(self, fromProperty.GetValue(parent));
                            break;
                        }
                        catch { }
                        
                    }
                }
            }
        }
    }
}
