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
    /// Signal History
    /// </summary>
    public class SignalHistoryController : ApiController
    {
        SQL_Access sqlObject = new SQL_Access();
        private string sqlStatus = string.Empty;
       
        /// <summary>
        /// Returns the requested history based on the parameters. 
        /// If nothing is passed, a list of available Tag Names is returned.
        /// </summary>
        /// <param name="historyRequest"></param>
        /// <returns></returns>
        public object Get([FromUri]SignalHistoryRequestModel historyRequest)
        {
            string query = string.Empty;
            if (historyRequest == null)
            {
                query = "SELECT TagName FROM dataTblSignalHistory GROUP BY TagName";
                return sqlObject.QuerySQL(query, ref sqlStatus);
            }
            SignalHistoryModel returnObjs = new SignalHistoryModel();
            string filter = string.Empty;
            //Select statement
            if (!string.IsNullOrWhiteSpace(historyRequest.SelectTop))
            {
                query = "SELECT TOP " + historyRequest.SelectTop + " ";
            }
            else
            {
                query = "SELECT ";
            }
            //Filters
            if (!string.IsNullOrWhiteSpace(historyRequest.StartDate))
            {
                filter = " WHERE TimeStamp >= '" + historyRequest.StartDate + "'";
            }
            if (!string.IsNullOrWhiteSpace(historyRequest.EndDate))
            {
                if (string.IsNullOrWhiteSpace(filter))
                {
                    filter = " WHERE TimeStamp <= '" + historyRequest.EndDate + "'";
                }
                else
                {
                    filter += " AND TimeStamp <= '" + historyRequest.EndDate + "'";
                }
            }
            if (!string.IsNullOrWhiteSpace(historyRequest.SignalID))
            {
                if (string.IsNullOrWhiteSpace(filter))
                {
                    filter = " WHERE SignalID = '" + historyRequest.SignalID + "'";
                }
                else
                {
                    filter += " AND SignalID = '" + historyRequest.SignalID + "'";
                }
            }
            if (!string.IsNullOrWhiteSpace(historyRequest.TagName))
            {
                if (string.IsNullOrWhiteSpace(filter))
                {
                    filter = " WHERE TagName = '" + historyRequest.TagName + "'";
                }
                else
                {
                    filter += " AND TagName = '" + historyRequest.TagName + "'";
                }
            }
            // If no filters applied return blank object
            if (string.IsNullOrWhiteSpace(filter))
            {
                query = "SELECT TagName FROM dataTblSignalHistory GROUP BY TagName";
                return sqlObject.QuerySQL(query, ref sqlStatus);
            }
            query += "InsertTime,TimeStamp,SignalID,TagName,TimeStamp,Value FROM dataTblSignalHistory" + filter;
            using (DataTable tblData = sqlObject.QuerySQL(query, ref sqlStatus))
            {
                if (tblData != null)
                {
                    foreach (DataRow item in tblData.Rows)
                    {
                        SignalHistoryPointModel newObj = new SignalHistoryPointModel();
                        newObj.InsertTimeStamp = item["InsertTime"].ToString();
                        newObj.SignalID = item["SignalID"].ToString();
                        newObj.SignalTimeStamp = item["TimeStamp"].ToString();
                        newObj.TagName = item["TagName"].ToString();
                        newObj.Value = item["Value"].ToString();
                        returnObjs.SignalHistory.Add(newObj);
                    }
                }
            }
            return returnObjs;
        }
    }
}
