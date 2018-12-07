using System;
using System.Diagnostics;
using System.IO;

namespace RadiusCore.SqlAccess
{
    public class Logs
    {
        public const string BasePath = "c:\\app\\";
        public const string Title = "AcmToSignal";
        public static string ConfigFileName = "ServerConfiguration.ini";

        public static string ErrorFileName = "Error.log";

        private string sqlStatus = string.Empty;
        private SQL_Access sql = new SQL_Access();
        public void ErrorLogEntry(string errorMessage)
        {
            errorMessage = errorMessage.Replace(",", " ");
            errorMessage = System.DateTime.Now.ToString() + "," + errorMessage.Replace(System.Environment.NewLine, " ");
            WriteAddText(BasePath, ErrorFileName, errorMessage);
        }

        /// <summary>
        /// Inserts into the log in the database using the title as the log type
        /// </summary>
        /// <param name="LogType"></param>
        /// <param name="LogMessage"></param>
        public void InsertLogger(StatCodes LogType, string LogMessage)
        {
            try
            {
                sql.QuerySQL("Insert into dataTblLogs (LogSource,LogType,LogMessage) Values ('" + Title + "','" + LogType + "','" + LogMessage + "')", ref sqlStatus);
            }
            catch (Exception ex)
            {
                ErrorLogEntry(ex.Message);
            }
        }

        /// <summary>
        /// Inserts into the log in the database
        /// </summary>
        /// <param name="LogType"></param>
        /// <param name="LogMessage"></param>
        public void InsertLogger(string LogSource, StatCodes LogType, string LogMessage)
        {
            try
            {
                string logType = "Unknown";
                switch (LogType)
                {
                    case StatCodes.Statistic:
                        logType = "Stat";
                        break;
                    case StatCodes.Info:
                        logType = "Info";
                        break;
                    case StatCodes.Error:
                        logType = "Error";
                        break;
                    default:
                        logType = "Unknown";
                        break;
                }
                sql.QuerySQL("Insert into dataTblLogs (LogSource,LogType,LogMessage) Values ('" + LogSource + "','" + logType + "','" + LogMessage + "')", ref sqlStatus);
            }
            catch(Exception ex)
            {
                ErrorLogEntry(ex.Message);
            }
        }

        /// <summary>
        /// Status codes for the Log
        /// </summary>
        public enum StatCodes
        {
            /// <summary>
            /// Statistical Data
            /// </summary>
            Statistic = -1,
            /// <summary>
            /// Information
            /// </summary>
            Info = 0,
            /// <summary>
            /// Error
            /// </summary>
            Error = 1
        }

        /// <summary>
        /// Writes a single line to a text file.
        /// </summary>
        /// <param name="LocalFilePath"></param>
        /// <param name="FileName"></param>
        /// <param name="fileText"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool WriteAddText(string LocalFilePath, string FileName, string fileText)
        {
            string filePath = LocalFilePath + FileName;
            SetWriteProperty(filePath);
            bool status = false;
            try
            {
                try
                {
                    Directory.CreateDirectory(LocalFilePath);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message.ToString());
                }
                using (StreamWriter newFile = new StreamWriter(LocalFilePath + FileName, true))
                {
                    newFile.WriteLine(fileText);
                    newFile.Close();
                }
                status = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }

        /// <summary>
        /// Removes the read only attribute .
        /// Arguement must contain full path.
        /// Returns true if property set is successful.
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool SetWriteProperty(string FileName)
        {
            try
            {
                //Verify that the file exists
                if (System.IO.File.Exists(FileName))
                {
                    //*** Set read only to false
                    System.IO.File.SetAttributes(FileName, FileAttributes.Normal);
                    //*** Return property set successful
                    return true;
                }
                else
                {
                    //*** Return unsuccessful property set
                    return false;
                }
            }
            catch (Exception ex)
            {
                //*** Return unsuccessful property set based on exception
                Debug.WriteLine(ex.Message.ToString());
                return false;
            }
        }
    }
}
