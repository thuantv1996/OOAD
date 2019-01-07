using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Report
{
    public class ConnectionDatabase
    {
        public static string GetConnection()
        {
            string connectionString = "Data Source=" + GetContentFile("connectionString.txt")
                + ";Initial Catalog=QLPHONGKHAM;Integrated Security=True";
            return connectionString;
        }

        private static string GetContentFile(string path)
        {
            string content = "";
            content = File.ReadAllLines(path)[0];
            return content;
        }
    }
}
