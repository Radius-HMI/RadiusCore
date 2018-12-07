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
    /// Radius Object Properties
    /// </summary>
    public class ObjectPropertiesController : ApiController
    {
        SQL_Access sqlObject = new SQL_Access();
        private string sqlStatus = string.Empty;

        /// <summary>
        /// Returns Returns a list of properties if all parameters are null, 
        /// Properties associated with an Object, 
        /// Properties associated with the Property Name.
        /// </summary>
        /// <param name="objectID"></param>
        /// <param name="objectPropertyID"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public Object Get([FromUri]string objectID = null, [FromUri]string objectPropertyID = null, [FromUri]string propertyName = null)
        {
            string query = "SELECT Property FROM cfgTblObjectProperties GROUP BY Property ORDER BY Property";
            if (string.IsNullOrWhiteSpace(objectID) && 
                string.IsNullOrWhiteSpace(objectPropertyID))
            {
                return sqlObject.QuerySQL(query, ref sqlStatus);
            }       

            ObjectPropertiesModels returnObj = new ObjectPropertiesModels();
            string propertyFilter = string.Empty;
            if (!string.IsNullOrWhiteSpace(objectPropertyID))
            {
                propertyFilter = ", @ObjectPropertyID='" + objectPropertyID + "'";
            }
            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                propertyFilter = ", @PropertyName='" + propertyName + "'";
            }
            query = "EXEC rGetObjectProperties @ObjectID = '" + objectID + "'" + propertyFilter;
            using (DataTable tblData = sqlObject.QuerySQL(query, ref sqlStatus))
            {
                if (tblData != null)
                {
                    foreach (DataRow item in tblData.Rows)
                    {
                        ObjectPropertyModel newObj = new ObjectPropertyModel();
                        newObj.DataTypeID = item["DataTypeID"].ToString();
                        newObj.DataTypeText = item["DataTypeText"].ToString();
                        newObj.DataTypeValue = item["DataTypeValue"].ToString();
                        newObj.Value = item["Value"].ToString();
                        newObj.DisplayName = item["DisplayName"].ToString();
                        newObj.PropertyID = item["PropertyID"].ToString();
                        newObj.ObjectID = objectID;
                        newObj.PropertyName = item["PropertyName"].ToString();
                        newObj.WriteSecurityLevel = item["WriteSecurityLevel"].ToString();
                        returnObj.RadiusObjectProperties.Add(newObj);
                    }
                }
            }
            return returnObj;
        }

        /// <summary>
        /// Update Property. Along with the required variables you must also supply the PropertyID.
        /// </summary>
        /// <param name="objProperty"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromUri] ObjectPropertyModel objProperty)
        {
            string Value = "NULL";
            if (!string.IsNullOrWhiteSpace(objProperty.Value))
            {
                Value = "'" + objProperty.Value + "'";
            }
            string query = "UPDATE cfgTblObjectProperties SET ";
            string newValues = "Value = " + Value;
            if (!string.IsNullOrWhiteSpace(objProperty.ObjectID))
            {
                newValues = ",ObjectID = '" + objProperty.ObjectID + "'";
            }
            if (!string.IsNullOrWhiteSpace(objProperty.PropertyName))
            {
                newValues += ",Property = '" + objProperty.PropertyName + "'";
            }
            if (!string.IsNullOrWhiteSpace(objProperty.DataTypeID))
            {
                newValues += ",DataType = '" + objProperty.DataTypeID + "'";
            }
            if (!string.IsNullOrWhiteSpace(objProperty.DisplayName))
            {
                newValues += ",DisplayName = '" + objProperty.DisplayName + "'";
            }
            if (!string.IsNullOrWhiteSpace(objProperty.WriteSecurityLevel))
            {
                newValues += ",WriteSecurityLevel = " + objProperty.WriteSecurityLevel;
            }
            query += newValues + " WHERE ID = '" + objProperty.PropertyID + "'";
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
        /// Add new Property.
        /// </summary>
        /// <param name="objProperty"></param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromUri] ObjectPropertyModel objProperty)
        {
            string query = "INSERT INTO cfgTblObjectProperties (" +
                            "ObjectID" +
                            ",Property" +
                            ",Value" +
                            ",DataType" +
                            ",DisplayName" +
                            ",WriteSecurityLevel) VALUES (" +
                            "'" + objProperty.ObjectID + "'" +
                            ",'" + objProperty.PropertyName + "'" +
                            ",'" + objProperty.Value + "'" +
                            ",'" + objProperty.DataTypeID + "'" +
                            ",'" + objProperty.DisplayName + "'" +
                            "," + objProperty.WriteSecurityLevel + ")";
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
        /// Deletes a Property based on ID
        /// </summary>
        /// <param name="propertyID"></param>
        public HttpResponseMessage Delete([FromUri] string propertyID)
        {
            string query = "DELETE FROM cfgTblObjectProperties WHERE ID = '" + propertyID + "'";
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
