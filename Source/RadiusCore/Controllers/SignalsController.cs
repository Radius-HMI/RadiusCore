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
    /// Signals operate off the concept that all PV's (process variables) can be reduced down to one thing. 
    /// These are referred to as signals. A signal can represent any single IO or configuration point. 
    /// Signals also recognize that a set point is treated the same as an IO point.
    /// Signals should have properties associated to identify features specific to the signal such as an column name or OPC tag.
    /// </summary>
    public class SignalsController : ApiController
    {
        SQL_Access sqlObject = new SQL_Access();
        private string sqlStatus = string.Empty;
        /// <summary>
        /// Returns a list of available Signals
        /// </summary>
        /// <returns></returns>
        public SignalModels Get()
        {
            string query = "EXEC rGetSignals";
            SignalModels returnObjs = new SignalModels();
            using (DataTable tblData = sqlObject.QuerySQL(query, ref sqlStatus))
            {
                if (tblData != null)
                {
                    foreach (DataRow item in tblData.Rows)
                    {
                        SignalModel newObj = new SignalModel();
                        newObj.DataTypeID = item["DataTypeID"].ToString();
                        newObj.DeviceID = item["DeviceID"].ToString();
                        newObj.DataTypeText = item["DataTypeText"].ToString();
                        newObj.DataTypeValue = item["DataTypeValue"].ToString();
                        newObj.DisplayName = item["DisplayName"].ToString();
                        newObj.Enabled = item["Enabled"].ToString();
                        newObj.RawValue = item["RawValue"].ToString();
                        newObj.SignalID = item["SignalID"].ToString();
                        newObj.SourceID = item["SourceID"].ToString();
                        newObj.SourceText = item["SourceText"].ToString();
                        newObj.SourceValue = item["SourceValue"].ToString();
                        newObj.TagName = item["TagName"].ToString();
                        newObj.TimeStamp = item["TimeStamp"].ToString();
                        returnObjs.Signals.Add(newObj);
                    }
                }
            }
            return returnObjs;
        }

        /// <summary>
        /// Returns a Signal based on ID
        /// </summary>
        /// <param name="signalID"></param>
        /// <returns></returns>
        public SignalModel Get(string signalID)
        {
            string query = "EXEC rGetSignals @SignalID = '" + signalID + "'";
            SignalModel returnObjs = new SignalModel();
            using (DataTable tblData = sqlObject.QuerySQL(query, ref sqlStatus))
            {
                if (tblData != null && tblData.Rows.Count > 0)
                {
                    returnObjs.DataTypeID = tblData.Rows[0]["DataTypeID"].ToString();
                    returnObjs.DeviceID = tblData.Rows[0]["DeviceID"].ToString();
                    returnObjs.DataTypeText = tblData.Rows[0]["DataTypeText"].ToString();
                    returnObjs.DataTypeValue = tblData.Rows[0]["DataTypeValue"].ToString();
                    returnObjs.DisplayName = tblData.Rows[0]["DisplayName"].ToString();
                    returnObjs.Enabled = tblData.Rows[0]["Enabled"].ToString();
                    returnObjs.RawValue = tblData.Rows[0]["RawValue"].ToString();
                    returnObjs.SignalID = tblData.Rows[0]["SignalID"].ToString();
                    returnObjs.SourceID = tblData.Rows[0]["SourceID"].ToString();
                    returnObjs.SourceText = tblData.Rows[0]["SourceText"].ToString();
                    returnObjs.SourceValue = tblData.Rows[0]["SourceValue"].ToString();
                    returnObjs.TagName = tblData.Rows[0]["TagName"].ToString();
                    returnObjs.TimeStamp = tblData.Rows[0]["TimeStamp"].ToString();
                }
            }
            return returnObjs;
        }

        /// <summary>
        /// Update Signal. Along with the required variables you must also supply the SignalID. 
        /// The History gets updated on every data change.
        /// </summary>
        /// <param name="objSignal"></param>
        public HttpResponseMessage Post([FromUri]SignalModel objSignal)
        {
            HttpResponseMessage response;
            if (string.IsNullOrWhiteSpace(objSignal.SignalID))
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, sqlStatus);
                return response;
            }
            string query = "UPDATE dataTblSignals SET ";
            if (!string.IsNullOrWhiteSpace(objSignal.TagName))
            {
                query += "TagName = '" + objSignal.TagName + "'";
            }
            if (!string.IsNullOrWhiteSpace(objSignal.DisplayName))
            {
                if (query[query.Length - 1] != ' ')
                {
                    query += ",";
                }
                query += "DisplayName = '" + objSignal.DisplayName + "'";
            }
            if (!string.IsNullOrWhiteSpace(objSignal.RawValue))
            {
                if (query[query.Length - 1] != ' ')
                {
                    query += ",";
                }
                if (string.IsNullOrWhiteSpace(objSignal.TimeStamp))
                {
                    objSignal.TimeStamp = DateTime.Now.ToString();
                }
                query += "RawValue = '" + objSignal.RawValue + "',TimeStamp = '" + objSignal.TimeStamp + "'";
            }
            if (!string.IsNullOrWhiteSpace(objSignal.SourceID))
            {
                if (query[query.Length - 1] != ' ')
                {
                    query += ",";
                }
                query += "Source = '" + objSignal.SourceID + "'";
            }
            if (!string.IsNullOrWhiteSpace(objSignal.Enabled))
            {
                if (query[query.Length - 1] != ' ')
                {
                    query += ",";
                }
                query += "Enabled = '" + objSignal.Enabled + "'";
            }
            if (!string.IsNullOrWhiteSpace(objSignal.DataTypeID))
            {
                if (query[query.Length - 1] != ' ')
                {
                    query += ",";
                }
                query += "ItemDataType = '" + objSignal.DataTypeID + "'";
            }
            if (!string.IsNullOrWhiteSpace(objSignal.DeviceID))
            {
                if (query[query.Length - 1] != ' ')
                {
                    query += ",";
                }
                query += "DeviceID = '" + objSignal.DataTypeID + "'";
            }
            query += " WHERE ID = '" + objSignal.SignalID + "'";

            sqlObject.QuerySQL(query, ref sqlStatus);
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
        /// Adds a new Signal
        /// </summary>
        /// <param name="objSignal"></param>
        /// <param name="recipeName"></param>
        /// <param name="deviceID"></param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromUri]SignalModel objSignal = null, [FromUri]string recipeName = null, [FromUri]string deviceID = null)
        {
            HttpResponseMessage response;
            string query = string.Empty;
            if (objSignal == null && recipeName == null)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "No values");
            }
            else if (recipeName != null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, CreateSignalFromRecipe(recipeName,deviceID));
            }
            else
            {
                query = "INSERT INTO dataTblSignals (" +
                                "TagName" +
                                ",DeviceID" +
                                ",DisplayName" +
                                ",TimeStamp" +
                                ",RawValue" +
                                ",Source" +
                                ",Enabled" +
                                ",ItemDataType" +
                            ") VALUES (" +
                                "'" + objSignal.TagName + "'" +
                                ",'" + objSignal.DeviceID + "'" +
                                ",'" + objSignal.DisplayName + "'" +
                                ",'" + objSignal.TimeStamp + "'" +
                                ",'" + objSignal.RawValue + "'" +
                                ",'" + objSignal.SourceID + "'" +
                                ",'" + objSignal.Enabled + "'" +
                                ",'" + objSignal.DataTypeID + "'" +
                            ")";
                sqlObject.QuerySQL(query, ref sqlStatus);
                if (sqlStatus == "Success")
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, sqlStatus);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, sqlStatus);
                }
            }
            response.Content = new StringContent(sqlStatus, Encoding.Unicode);
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };
            return response;
        }

        private string CreateSignalFromRecipe(string recipeName, string deviceID)
        {
            if (string.IsNullOrWhiteSpace(deviceID))
            {
                deviceID = Guid.NewGuid().ToString();
            }
            string signalID = string.Empty;
            string query = "SELECT Name,TagName,DisplayName,Source,Enabled,DataType,InputSource," +
                            "OutputSource,CommChannel,Quality,Units,Precision,EnableScaling,RawMin," +
                            "RawMax,EU_Min,EU_Max,MinValue,MaxValue,WriteSecurityLevel,EnumLookupValue " +
                            "FROM cfgTblOPC_SignalRecipe WHERE Name = '" + recipeName + "'";
            DataTable tblData = sqlObject.QuerySQL(query, ref sqlStatus);
            foreach (DataRow row in tblData.Rows)
            {
                signalID = Guid.NewGuid().ToString();
                query = "INSERT INTO dataTblSignals (ID,DeviceID,TagName,DisplayName,Source,Enabled,ItemDataType) " +
                            "VALUES ('" + signalID + "'," +
                            "'" + deviceID + "'," +
                            "'" + row["TagName"].ToString() + "'," +
                            "'" + row["DisplayName"].ToString() + "'," +
                            "'" + row["Source"].ToString() + "'," +
                            "'" + row["Enabled"] + "'," +
                            "'" + row["DataType"].ToString() + "')";
                sqlObject.QuerySQL(query, ref sqlStatus);
                // InputSource
                query = "INSERT INTO cfgTblSignalProperties (SignalID,Name,DisplayName,Value) " +
                            "VALUES ('" + signalID + "'," +
                            "'InputSource'," +
                            "'Input Source'," +
                            "'" + row["InputSource"].ToString() + "')";
                sqlObject.QuerySQL(query, ref sqlStatus);
                // OutputSource
                query = "INSERT INTO cfgTblSignalProperties (SignalID,Name,DisplayName,Value) " +
                            "VALUES ('" + signalID + "'," +
                            "'OutputSource'," +
                            "'Output Source'," +
                            "'" + row["OutputSource"].ToString() + "')";
                // CommChannel
                query = "INSERT INTO cfgTblSignalProperties (SignalID,Name,DisplayName,Value) " +
                            "VALUES ('" + signalID + "'," +
                            "'CommChannel'," +
                            "'Comm Channel'," +
                            "'" + row["CommChannel"].ToString() + "')";
                sqlObject.QuerySQL(query, ref sqlStatus);
                // Quality
                query = "INSERT INTO cfgTblSignalProperties (SignalID,Name,DisplayName,Value) " +
                            "VALUES ('" + signalID + "'," +
                            "'Quality'," +
                            "'Quality'," +
                            "'" + row["Quality"].ToString() + "')";
                sqlObject.QuerySQL(query, ref sqlStatus);
                // Units
                query = "INSERT INTO cfgTblSignalProperties (SignalID,Name,DisplayName,Value) " +
                            "VALUES ('" + signalID + "'," +
                            "'Units'," +
                            "'Units'," +
                            "'" + row["Units"].ToString() + "')";
                sqlObject.QuerySQL(query, ref sqlStatus);
                // Precision
                query = "INSERT INTO cfgTblSignalProperties (SignalID,Name,DisplayName,Value) " +
                            "VALUES ('" + signalID + "'," +
                            "'Precision'," +
                            "'Precision'," +
                            "'" + row["Precision"].ToString() + "')";
                sqlObject.QuerySQL(query, ref sqlStatus);
                // EnableScaling
                query = "INSERT INTO cfgTblSignalProperties (SignalID,Name,DisplayName,Value) " +
                            "VALUES ('" + signalID + "'," +
                            "'EnableScaling'," +
                            "'Enable Scaling'," +
                            "'" + row["EnableScaling"].ToString() + "')";
                sqlObject.QuerySQL(query, ref sqlStatus);
                // RawMin
                query = "INSERT INTO cfgTblSignalProperties (SignalID,Name,DisplayName,Value) " +
                            "VALUES ('" + signalID + "'," +
                            "'RawMin'," +
                            "'Raw Min'," +
                            "'" + row["RawMin"].ToString() + "')";
                sqlObject.QuerySQL(query, ref sqlStatus);
                // RawMax
                query = "INSERT INTO cfgTblSignalProperties (SignalID,Name,DisplayName,Value) " +
                            "VALUES ('" + signalID + "'," +
                            "'RawMax'," +
                            "'Raw Max'," +
                            "'" + row["RawMax"].ToString() + "')";
                sqlObject.QuerySQL(query, ref sqlStatus);
                // EU_Min
                query = "INSERT INTO cfgTblSignalProperties (SignalID,Name,DisplayName,Value) " +
                            "VALUES ('" + signalID + "'," +
                            "'EU_Min'," +
                            "'EU Min'," +
                            "'" + row["EU_Min"].ToString() + "')";
                sqlObject.QuerySQL(query, ref sqlStatus);
                // EU_Max
                query = "INSERT INTO cfgTblSignalProperties (SignalID,Name,DisplayName,Value) " +
                            "VALUES ('" + signalID + "'," +
                            "'EU_Max'," +
                            "'EU Max'," +
                            "'" + row["EU_Max"].ToString() + "')";
                sqlObject.QuerySQL(query, ref sqlStatus);
                // MinValue
                query = "INSERT INTO cfgTblSignalProperties (SignalID,Name,DisplayName,Value) " +
                            "VALUES ('" + signalID + "'," +
                            "'MinValue'," +
                            "'Min Value'," +
                            "'" + row["MinValue"].ToString() + "')";
                sqlObject.QuerySQL(query, ref sqlStatus);
                // MaxValue
                query = "INSERT INTO cfgTblSignalProperties (SignalID,Name,DisplayName,Value) " +
                            "VALUES ('" + signalID + "'," +
                            "'MaxValue'," +
                            "'Max Value'," +
                            "'" + row["MaxValue"].ToString() + "')";
                sqlObject.QuerySQL(query, ref sqlStatus);
                // WriteSecurityLevel
                query = "INSERT INTO cfgTblSignalProperties (SignalID,Name,DisplayName,Value) " +
                            "VALUES ('" + signalID + "'," +
                            "'WriteSecurityLevel'," +
                            "'Write Security Level'," +
                            "'" + row["WriteSecurityLevel"].ToString() + "')";
                sqlObject.QuerySQL(query, ref sqlStatus);
                // EnumLookupValue
                string compareValue = row["EnumLookupValue"].ToString();
                if (string.IsNullOrWhiteSpace(compareValue))
                {
                    compareValue = "NULL";
                }
                else
                {
                    compareValue = "'" + compareValue + "'";
                }
                query = "INSERT INTO cfgTblSignalProperties (SignalID,Name,DisplayName,Value) " +
                            "VALUES ('" + signalID + "'," +
                            "'EnumLookupValue'," +
                            "'Enumuration Lookup Value'," +
                            compareValue + ")";
                sqlObject.QuerySQL(query, ref sqlStatus);
            }
            return deviceID;
        }

        /// <summary>
        /// Deletes a Signal based on ID
        /// </summary>
        /// <param name="signalID"></param>
        public HttpResponseMessage Delete(string signalID)
        {
            string query = "DELETE FROM cfgTblSignalProperties WHERE SignalID = '" + signalID + "'";
            sqlObject.QuerySQL(query, ref sqlStatus);
            query = "DELETE FROM dataTblSignals WHERE ID = '" + signalID + "'";
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
