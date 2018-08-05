using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RadiusCore.Models;
using RadiusCore.SqlAccess;
using System.Data;
using System.Text;
using System.Net.Http.Headers;

namespace RadiusCore.Controllers
{
    /// <summary>
    /// Signal Properties
    /// </summary>
    public class SignalPropertyController : ApiController
    {
        SQL_Access sqlObject = new SQL_Access();
        private string sqlStatus = string.Empty;
        /// <summary>
        /// Returns a Signal Property set if signalID is set or a specific property if signalPropertyID is set. 
        /// An empty Signal Property will be returned if neither are set.
        /// </summary>
        /// <returns></returns>
        public SignalPropertiesModels Get(string signalID = null, string signalPropertyID = null)
        {
            SignalPropertiesModels returnObjs = new SignalPropertiesModels();
            string query = string.Empty;
            if (!string.IsNullOrWhiteSpace(signalPropertyID))
            {
                query = "EXEC rGetSignalProperty @SignalPropertyID = '" + signalPropertyID + "'";
            }
            else if (!string.IsNullOrWhiteSpace(signalID))
            {
                query = "EXEC rGetSignalProperties @SignalID = '" + signalID + "'";
            }
            else
            {
                return returnObjs;
            }
            using (DataTable tblData = sqlObject.QuerySQL(query, ref sqlStatus))
            {
                if (tblData != null)
                {
                    foreach (DataRow item in tblData.Rows)
                    {
                        SignalPropertyModels newObj = new SignalPropertyModels();
                        newObj.DisplayName = item["DisplayName"].ToString();
                        newObj.PropertyName = item["PropertyName"].ToString();
                        newObj.PropertyValue = item["PropertyValue"].ToString();
                        newObj.SignalPropertyID = item["SignalPropertyID"].ToString();
                    }
                }
            }
            return returnObjs;
        }
        /// <summary>
        /// Update Signal Property. Along with the required variables you must also supply the SignalPropertyID.
        /// </summary>
        /// <param name="objSignalProperty"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromUri]SignalPropertyModels objSignalProperty)
        {
            string query = "UPDATE cfgTblSignalProperties SET " +
                                "SignalID = '" + objSignalProperty.SignalID + "'" +
                                ",Name = '" + objSignalProperty.PropertyName + "'" +
                                ",DisplayName = '" + objSignalProperty.DisplayName + "'" +
                                ",Value = '" + objSignalProperty.PropertyValue + "' " +
                                "WHERE ID = '" + objSignalProperty.SignalPropertyID + "'";
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
        /// Add new Signal Property
        /// </summary>
        /// <param name="objSignalProperty"></param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromUri]SignalPropertyModels objSignalProperty)
        {
            string value = "NULL";
            if (!string.IsNullOrWhiteSpace(objSignalProperty.PropertyValue))
            {
                value = "'" + objSignalProperty.PropertyValue + "'";
            }
            string query = "INSERT INTO cfgTblSignalProperties (" +
                                "SignalID" +
                                ",Name" +
                                ",DisplayName" +
                                ",Value" +
                            ") VALUES (" +
                                "'" + objSignalProperty.SignalID + "'" +
                                "," + objSignalProperty.PropertyName + "''" +
                                ",'" + objSignalProperty.DisplayName + "'" +
                                "," + value +
                            ")";
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
        /// Deletes a Signal Property based on ID
        /// </summary>
        /// <param name="signalPropertyID"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(string signalPropertyID)
        {
            string query = "DELETE FROM cfgTblSignalProperties WHERE ID = '" + signalPropertyID + "'";
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
