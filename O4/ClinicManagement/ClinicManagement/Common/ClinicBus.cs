using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.ComponentModel;

namespace ClinicManagement.Common
{
    public class ClinicBus
    {
        protected ClinicBus() { }
        public DataTable getAllPetient()
        {
            return new DataTable();
        }

        static public DataTable ConvertToDatatable<T>(List<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        static public string convertDateToView(string date)
        {
            var year = date.Substring(0, 4);
            var month = date.Substring(4, 2);
            var day = date.Substring(6, 2);
            return String.Format("{0}/{1}/{2}", day, month, year);
        }

        static public string convertViewToDate(string date)
        {
            var list = date.Split('/');
            var day = list.First();
            var month = list[1];
            var year = list.Last();
            return String.Format("{0}{1}{2}", year, month, day);
        }
    }

   
}
