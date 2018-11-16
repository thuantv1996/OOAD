using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Common
{
    public class LogManager
    {
        public static string GetErrorFromException(Exception e)
        {
            // get curent time
            string systemTime = DateTime.Now.ToString() + "\t";
            // Nếu không có Exception inner
            if (e.InnerException == null)
            {
                // return thông điệp phát sinh lỗi
                return systemTime + e.Message;
            }
            string Error = "";
            Exception InnerException = e.InnerException;
            // Trong khi còn InnerException
            do
            {
                // Thêm Message của InnerException vào Error
                Error = Error + systemTime + InnerException.Message + "\r\n";
                InnerException = InnerException.InnerException;
            } while (InnerException != null);
            return Error;
        }

        public static void WriteLog(string log)
        {
            // open file logs
            StreamWriter logFile = null;
            try
            {
                // check exist path
                if (!Directory.Exists(Environment.CurrentDirectory + "/Logs"))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + "/Logs");
                }
                // check exist file
                if (!File.Exists(Environment.CurrentDirectory + DAOCommon.LOG_PATH))
                {
                    File.Create(Environment.CurrentDirectory + DAOCommon.LOG_PATH);
                }
                // open file with path and append file
                FileStream fileStream = new FileStream(Environment.CurrentDirectory + DAOCommon.LOG_PATH, FileMode.Append ,FileAccess.Write);
                logFile = new StreamWriter(fileStream);
                logFile.WriteLine(log);
            }
            // process exception when io
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                // close file
                logFile.Close();
            }
        }
    }
}
