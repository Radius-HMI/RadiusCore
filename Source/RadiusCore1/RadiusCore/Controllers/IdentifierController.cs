using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RadiusCore.SqlAccess;
using System.Data;
using System.Text;
using System.Net.Http.Headers;

namespace RadiusCore.Controllers
{
    /// <summary>
    /// Identifiers are used to reference items that are enumerated or cross-referenced.
    /// </summary>
    public class IdentifierController : ApiController
    {
        private string sqlStatus = string.Empty;
        SQL_Access returnTable = new SQL_Access();
        /// <summary>
        /// Returns the types of identifiers
        /// </summary>
        /// <returns></returns>
        public DataTable Get()
        {
            string query = "SELECT ID_Type AS Type FROM cfgTblIdentifiers GROUP BY ID_Type ORDER BY ID_Type";
            return returnTable.QuerySQL(query, ref sqlStatus);
        }

        /// <summary>
        /// Gets the Values and Text representation for the Type specified.
        /// </summary>
        /// <param name="typeID">Type Specified</param>
        /// <returns></returns>
        public DataTable Get(string typeID)
        {
            string query = "SELECT ID,Value,Text FROM cfgTblIdentifiers WHERE ID_Type = '" + typeID + "' ORDER BY Value";
            SQL_Access returnTable = new SQL_Access();
            return returnTable.QuerySQL(query, ref sqlStatus);
        }

        /// <summary>
        /// Updates an existing Identifier.
        /// </summary>
        /// <param name="typeID">Type Specified</param>
        /// <param name="oldValue">Old value to change</param>
        /// <param name="value">Value to change to</param>
        /// <param name="text">Text representation of the Value</param>
        public HttpResponseMessage Post([FromUri]string typeID, [FromUri]string oldValue, [FromUri]string value, [FromUri]string text)
        {
            string query = "UPDATE cfgTblIdentifiers SET Text = '" + text + "', Value = '" + value +
                "' WHERE ID_Type = '" + typeID + "' AND Value = '" + oldValue + "'";
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

        /// <summary>
        /// Inserts a new value.
        /// </summary>
        /// <param name="typeID">Type Specified</param>
        /// <param name="value">Value to add</param>
        /// <param name="text">Text representation of the Value</param>
        public HttpResponseMessage Put([FromUri]string typeID, [FromUri]string value, [FromUri]string text)
        {
            string query = "INSERT INTO cfgTblIdentifiers (ID_Type,Value,Text) VALUES ('" + typeID + 
                "','" + value + "','" + text + "')";
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

        /// <summary>
        /// Deletes a Value and Text representation.
        /// </summary>
        /// <param name="typeID">Type Specified</param>
        /// <param name="value">Value to delete</param>
        public HttpResponseMessage Delete([FromUri]string typeID, [FromUri]string value)
        {
            string query = "DELETE FROM cfgTblIdentifiers WHERE ID_Type = '" + typeID +
                "' AND Value = '" + value + "'";
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
