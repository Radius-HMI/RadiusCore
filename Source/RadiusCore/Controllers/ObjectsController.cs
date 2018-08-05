using RadiusCore.SqlAccess;
using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RadiusCore.Models;
using System.Text;
using System.Net.Http.Headers;

namespace RadiusCore.Controllers
{
    /// <summary>
    /// Objects are anything that is configurable for presentation. 
    /// They generally have a parent child relationship with other Objects. 
    /// Objects should represent real world items. An example is a well. 
    /// The well may have meter, device, tank, compressor, and many other Objects as children. 
    /// The well Object has properties (ObjectProperties) only associated with that well such as the well name, 
    /// pipeline company, status, and other properties specific to a well. The meter Object 
    /// will have properties only associated with the meter such as the meter ID and device meter ID. 
    /// It’s important to note that an Object can be anything including houses, cars, or any other potential IoT Objects. 
    /// </summary>
    public class ObjectsController : ApiController
    {
        SQL_Access sqlObject = new SQL_Access();
        private string sqlStatus = string.Empty;
        /// <summary>
        /// Returns a list of available Objects
        /// </summary>
        /// <returns></returns>
        public ObjectModels Get([FromUri] string objectTypeID = null)
        {
            string query = "EXEC rGetObjects";
            if (objectTypeID != null)
            {
                query = "EXEC rGetObjects @ObjectTypeID='" + objectTypeID + "'";
            }
            ObjectModels returnObjs = new ObjectModels();
            using (DataTable tblData = sqlObject.QuerySQL(query, ref sqlStatus))
            {
                if (tblData != null)
                {
                    foreach (DataRow item in tblData.Rows)
                    {
                        ObjectModel newObj = new ObjectModel();
                        newObj.DisplayName = item["DisplayName"].ToString();
                        newObj.ObjectID = item["ObjectID"].ToString();
                        newObj.ObjectTypeID = item["ObjectTypeID"].ToString();
                        newObj.ObjectTypeText = item["ObjectTypeText"].ToString();
                        newObj.ObjectTypeValue = item["ObjectTypeValue"].ToString();
                        returnObjs.RadiusObjects.Add(newObj);
                    }
                }
            }
            return returnObjs;
        }

        /// <summary>
        /// Update an Object. Along with the required variables you must also supply the ObjectID.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromUri] ObjectModel obj)
        {
            string query = "UPDATE dataTblObjects SET DisplayName = '" + obj.DisplayName + "', ObjectType = '" + obj.ObjectTypeID + "' WHERE ID = '" + obj.ObjectID + "'";
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
        /// Add new Object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromUri] ObjectModel obj)
        {
            string objectID = Guid.NewGuid().ToString();
            string query = "INSERT INTO dataTblObjects (ID,DisplayName,ObjectType) VALUES ('" + objectID + "','" + obj.DisplayName + "','" + obj.ObjectTypeID + "')";
            sqlObject.QuerySQL(query, ref sqlStatus);
            CreateObjectFromRecipe(obj.ObjectTypeID, objectID);
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

        private void CreateObjectFromRecipe(string objectType, string objectID)
        {
            string query = "SELECT Property" +
                            ",Value" +
                            ",DataType" +
                            ",DisplayName" +
                            ",WriteSecurityLevel" +
                            " FROM cfgTblObjectRecipe" +
                            " WHERE Type = '" + objectType + "'";
            using (DataTable tblData = sqlObject.QuerySQL(query, ref sqlStatus))
            {
                if (tblData != null && tblData.Rows.Count > 0)
                {
                    foreach (DataRow row in tblData.Rows)
                    {
                        query = "INSERT INTO cfgTblObjectProperties (ObjectID,Property,Value,DisplayName,DataType,WriteSecurityLevel) VALUES (" +
                                "'" + objectID + "'" +
                                ",'" + row["Property"].ToString() + "'" +
                                ",'" + row["Value"].ToString() + "'" +
                                ",'" + row["DisplayName"].ToString() + "'" +
                                ",'" + row["DataType"].ToString() + "'" +
                                "," + row["WriteSecurityLevel"].ToString() +
                                ")";
                        sqlObject.QuerySQL(query, ref sqlStatus);
                    }
                }
            }
        }

        /// <summary>
        /// Deletes an Object based on ID
        /// </summary>
        /// <param name="objectID"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(string objectID)
        {
            string query = "DELETE FROM cfgTblObjectProperties WHERE ObjectID = '" + objectID + "'";
            sqlObject.QuerySQL(query, ref sqlStatus);
            query = "DELETE FROM dataTblObjects WHERE ID = '" + objectID + "'";
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
