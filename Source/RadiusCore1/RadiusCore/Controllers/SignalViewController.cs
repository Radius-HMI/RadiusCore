using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using RadiusCore.Models;
using RadiusCore.SqlAccess;
using System.Web.Http;
using System.Data;

namespace RadiusCore.Controllers
{
    /// <summary>
    /// Signal Views
    /// </summary>
    public class SignalViewController : ApiController
    {
        SQL_Access sqlObject = new SQL_Access();
        private string sqlStatus = string.Empty;
        /// <summary>
        /// Returns the Views for the ID and/or group type.
        /// TODO: Implement Username
        /// </summary>
        /// <param name="deviceID"></param>
        /// <param name="groupType"></param>
        /// <returns></returns>
        public SignalViewModels Get([FromUri]string deviceID, [FromUri]string groupType = null)
        {
            SignalViewModels returnObjs = new SignalViewModels();
            //returnObjs.UserName = RequestContext.Principal.Identity.Name;
            string filter = string.Empty;
            if (!string.IsNullOrWhiteSpace(groupType))
            {
                filter = ", @TypeIDByValue = '" + groupType + "'";
            }
            string query = "EXEC rGetSignalViewByDevice @DeviceID = '" + deviceID + "'" + filter;
            using (DataTable tblData = sqlObject.QuerySQL(query, ref sqlStatus))
            {
                if (tblData != null && tblData.Rows.Count > 0)
                {
                    foreach (DataRow item in tblData.Rows)
                    {
                        SignalViewModel newObj = new SignalViewModel();
                        newObj.SignalID = item["SignalID"].ToString();
                        newObj.InputSource = item["InputSource"].ToString();
                        newObj.OutputSource = item["OutputSource"].ToString();
                        newObj.TagName = item["TagName"].ToString();
                        newObj.DisplayName = item["DisplayName"].ToString();
                        newObj.ViewDisplayName = item["ViewDisplayName"].ToString();
                        newObj.TimeStamp = item["TimeStamp"].ToString();
                        newObj.RawValue = item["RawValue"].ToString();
                        newObj.Source = item["Source"].ToString();
                        newObj.Enabled = item["Enabled"].ToString();
                        newObj.ItemDataType = item["ItemDataType"].ToString();
                        newObj.CommChannel = item["CommChannel"].ToString();
                        newObj.EnableScaling = item["EnableScaling"].ToString();
                        newObj.EU_Min = item["EU_Min"].ToString();
                        newObj.EU_Max = item["EU_Max"].ToString();
                        newObj.RawMin = item["RawMin"].ToString();
                        newObj.RawMax = item["RawMax"].ToString();
                        newObj.MinValue = item["MinValue"].ToString();
                        newObj.MaxValue = item["MaxValue"].ToString();
                        newObj.Precision = item["Precision"].ToString();
                        newObj.Quality = item["Quality"].ToString();
                        newObj.Units = item["Units"].ToString();
                        newObj.WriteSecurityLevel = item["WriteSecurityLevel"].ToString();
                        newObj.EnumLookupValue = item["EnumLookupValue"].ToString();
                        if (!string.IsNullOrWhiteSpace(newObj.EnumLookupValue))
                        {
                            query = "SELECT Value, Text FROM cfgTblIdentifiers WHERE ID_Type = '" + newObj.EnumLookupValue + "'";
                            DataTable tblEnums = sqlObject.QuerySQL(query, ref sqlStatus);
                            if (tblEnums != null && tblEnums.Rows.Count > 0)
                            {
                                foreach (DataRow dRow in tblEnums.Rows)
                                {
                                    newObj.EnumValues.Add(new EnumVal(dRow["Value"].ToString().ToLower(), dRow["Text"].ToString()));
                                }
                            }
                        }
                        returnObjs.SignalViews.Add(newObj);
                    }
                }
            }
            return returnObjs;
        }
    }
}
