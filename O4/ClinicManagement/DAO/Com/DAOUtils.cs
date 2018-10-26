﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Com
{
    public class DAOUtils
    {
        public static void CopyProperties(object objSource, object objDestination)
        {
            //get the list of all properties in the destination object
            var destProps = objDestination.GetType().GetProperties();

            //get the list of all properties in the source object
            foreach (var sourceProp in objSource.GetType().GetProperties())
            {
                foreach (var destProperty in destProps)
                {
                    //if we find match between source & destination properties name, set
                    //the value to the destination property
                    if (destProperty.Name == sourceProp.Name &&
                            destProperty.PropertyType.IsAssignableFrom(sourceProp.PropertyType))
                    {
                        destProperty.SetValue(destProps, sourceProp.GetValue(
                            sourceProp, new object[] { }), new object[] { });
                        break;
                    }
                }
            }
        }

        public static string GetErrorFromException(Exception e)
        {
            // Nếu không có Exception inner
            if(e.InnerException == null)
            {
                // return thông điệp phát sinh lỗi
                return e.Message;
            }
            string Error = "";
            Exception InnerException = e.InnerException;
            // Trong khi còn InnerException
            do
            {
                // Thêm Message của InnerException vào Error
                Error = Error + InnerException.Message + "\n";
                InnerException = InnerException.InnerException;
            } while (InnerException != null);
            return Error;
        }
    }
}
