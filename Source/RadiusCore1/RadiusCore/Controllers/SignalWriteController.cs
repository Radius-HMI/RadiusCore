using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RadiusCore.Models;
using RadiusCore.SqlAccess;
using System.Text;
using System.Net.Http.Headers;

namespace RadiusCore.Controllers
{
    /// <summary>
    /// Handle Signal Writes
    /// </summary>
    public class SignalWriteController : ApiController
    {
        SQL_Access sqlObject = new SQL_Access();
        private string sqlStatus = string.Empty;
        /// <summary>
        /// Writes a value to the signal
        /// </summary>
        /// <param name="writeValue"></param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromUri]SignalWriteModel writeValue)
        {
            string comments = "NULL";
            if (!string.IsNullOrWhiteSpace(writeValue.Comments))
            {
                comments = "'" + writeValue.Comments.Replace("'","''") + "'";
            }
            string source = "NULL";
            if (!string.IsNullOrWhiteSpace(writeValue.Source))
            {
                source = "'" + writeValue.Source + "'";
            }
            string query = "EXEC rSetOPC_SigWrite @UserID = '" + writeValue.UserName + "'" + 
                            ",@SignalID = '" + writeValue.SignalID + "'" +
                            ",@Value = '" + writeValue.Value + "'" +
                            ",@Comment = " + comments + 
                            ",@Source = " + source;
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
