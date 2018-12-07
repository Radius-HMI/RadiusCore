using RadiusCore.SqlAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace RadiusCore.Controllers
{
    /// <summary>
    /// Logs associated with internal processes
    /// </summary>
    //[Authorize]
    public class LogsController : ApiController
    {
        private string sqlStatus = string.Empty;

        /// <summary>
        /// Returns the Source and Type list if all parameters are blank or the logs according to source and/or type. 
        /// Excluded values indicates all.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="typeID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="useTop"></param>
        /// <returns></returns>
        public object Get([FromUri]string source = "", 
                            [FromUri]string typeID = "", 
                            [FromUri]string startDate = "", 
                            [FromUri]string endDate = "", 
                            [FromUri]string useTop = "")
        {
            string query = string.Empty;
            SQL_Access returnTable;
            //Check if all are blank
            if (string.IsNullOrWhiteSpace(source)
                && string.IsNullOrWhiteSpace(typeID)
                && string.IsNullOrWhiteSpace(startDate)
                && string.IsNullOrWhiteSpace(endDate)
                && string.IsNullOrWhiteSpace(useTop))
            {
                List<DataTable> tblData = new List<DataTable>();
                query = "SELECT Source FROM dataTblLogs GROUP BY Source ORDER BY Source";
                returnTable = new SQL_Access();
                tblData.Add(returnTable.QuerySQL(query, ref sqlStatus));
                query = "SELECT Type FROM dataTblLogs GROUP BY Type ORDER BY Type";
                tblData.Add(returnTable.QuerySQL(query, ref sqlStatus));
                return tblData;
            }
            string filter = string.Empty;
            // Check source filter
            if (!string.IsNullOrWhiteSpace(source))
            {
                filter = " WHERE Source = '" + source + "'";
            }
            // Check typeID filter
            if (!string.IsNullOrWhiteSpace(typeID))
            {
                if (string.IsNullOrWhiteSpace(filter))
                {
                    filter = " WHERE Type = '" + typeID + "'";
                }
                else
                {
                    filter += " AND Type = '" + typeID + "'";
                }
            }
            // Check startDate filter
            if (!string.IsNullOrWhiteSpace(startDate))
            {
                if (string.IsNullOrWhiteSpace(filter))
                {
                    filter = " WHERE TimeStamp >= '" + startDate + "'";
                }
                else
                {
                    filter += " AND TimeStamp >= '" + startDate + "'";
                }
            }
            // Check endDate filter
            if (!string.IsNullOrWhiteSpace(endDate))
            {
                if (string.IsNullOrWhiteSpace(filter))
                {
                    filter = " WHERE TimeStamp <= '" + endDate + "'";
                }
                else
                {
                    filter += " AND TimeStamp <= '" + endDate + "'";
                }
            }
            if (int.TryParse(useTop, out int topResult) && topResult > 0)
            {
                query = "SELECT TOP " + topResult.ToString() + " Source,Type,Message FROM dataTblLogs" + filter + " ORDER BY TimeStamp DESC";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(filter))
                {
                    query = "SELECT 'Error in Request' AS 'Error'";
                }
                else
                {
                    query = "SELECT Source,Type,Message FROM dataTblLogs" + filter + " ORDER BY TimeStamp DESC";
                }
            }
            returnTable = new SQL_Access();
            return returnTable.QuerySQL(query, ref sqlStatus);
        }

        /// <summary>
        /// Inserts a new Log. Excluding the timestamp will use the insert date.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="typeID"></param>
        /// <param name="message"></param>
        /// <param name="timeStamp"></param>
        public HttpResponseMessage Put([FromUri]string source, [FromUri]string typeID, [FromUri]string message, [FromUri]string timeStamp = "")
        {
            string query;
            if (string.IsNullOrWhiteSpace(timeStamp))
            {
                query = "INSERT INTO dataTblLogs (Source,Type,Message) VALUES ('" + source + "','" + typeID + "','" + message + "')";
            }
            else
            {
                query = "INSERT INTO dataTblLogs (Source,Type,Message,TimeStamp) VALUES ('" + source + "','" + typeID + "','" + message + "','" + timeStamp + "')";
            }
            SQL_Access sqlObject = new SQL_Access();
            sqlObject.QuerySQL(query, ref sqlStatus);
            HttpResponseMessage response;
            if (sqlStatus == "Success")
            {
                response = Request.CreateResponse(HttpStatusCode.OK, sqlStatus);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, sqlStatus);
            }
            response.Content = new StringContent(sqlStatus, Encoding.Unicode);
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };
            return response;
        }
    }
}
