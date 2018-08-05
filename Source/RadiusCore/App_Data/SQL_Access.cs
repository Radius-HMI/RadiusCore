using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace RadiusCore.SqlAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class SQL_Access
    {
        /// <summary>
        /// 
        /// </summary>
        public string ConnectionString { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public SQL_Access()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        /// <summary>
        /// Run a query against the database. 
        /// This can support select, update, delete, and other queries.
        /// However, only a select will return a data table.
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <param name="sqlStatus">Writes "Success" to variable or exception message</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DataTable QuerySQL(string SQLCommand, ref string sqlStatus)
        {
            sqlStatus = "Success";
            Debug.WriteLine(ConnectionString);
            Debug.WriteLine(SQLCommand);
            DataTable tblData = new DataTable();
            //*** Make sure there are values in the arguements
            if (string.IsNullOrWhiteSpace(ConnectionString) | string.IsNullOrWhiteSpace(SQLCommand))
            {
                Debug.WriteLine("******************** No ConnectionString");
                sqlStatus = "Blank values in arguements";
                return null;
            }
            try
            {
                //*** Build connection
                using (System.Data.SqlClient.SqlConnection objConn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    //*** Build command based on the SQLCommand arguement and execute query
                    using (System.Data.SqlClient.SqlCommand objCmd = new System.Data.SqlClient.SqlCommand(SQLCommand, objConn))
                    {
                        objConn.Open();
                        if (SQLCommand.ToUpper().StartsWith("UPDATE") | SQLCommand.ToUpper().StartsWith("INSERT"))
                        {
                            objCmd.ExecuteNonQuery();
                            tblData = null;
                        }
                        else
                        {
                            using (IDataReader DR = objCmd.ExecuteReader())
                            {
                                tblData.Load(DR);
                                DR.Close();
                            }
                        }
                    }
                    objConn.Close();
                }
                sqlStatus = "Success";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                sqlStatus = ex.Message;
                tblData = null;
            }
            return tblData;
        }
    }
}
