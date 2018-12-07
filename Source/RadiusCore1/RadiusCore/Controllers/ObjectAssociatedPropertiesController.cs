using RadiusCore.Models;
using RadiusCore.SqlAccess;
using System;
using System.Data;
using System.Web.Http;

namespace RadiusCore.Controllers
{
    /// <summary>
    /// Get properties the are associated with a specific object as a parent
    /// </summary>
    public class ObjectAssociatedPropertiesController : ApiController
    {
        SQL_Access sqlObject = new SQL_Access();
        private string sqlStatus = string.Empty;
        /// <summary>
        /// Get properties the are associated with a specific object as a parent.
        /// objectTypeID is optional.
        /// </summary>
        /// <param name="objectID"></param>
        /// <param name="objectTypeID"></param>
        /// <returns></returns>
        public Object Get([FromUri]string objectID = null, [FromUri]string objectTypeID = null)
        {
            ObjectAssociatedPropertiesModels returnObj = new ObjectAssociatedPropertiesModels();
            string propertyFilter = string.Empty;
            if (!string.IsNullOrWhiteSpace(objectTypeID))
            {
                propertyFilter = ",@ObjectTypeID ='" + objectTypeID + "'";
            }
            string query = "EXEC rGetObjectAssociatedProperties @ObjectID ='" + objectID + "'" + propertyFilter;
            using (DataTable tblData = sqlObject.QuerySQL(query, ref sqlStatus))
            {
                if (tblData != null)
                {
                    foreach (DataRow item in tblData.Rows)
                    {
                        ObjectAssociatedPropertyModel newObj = new ObjectAssociatedPropertyModel();
                        newObj.DisplayName = item["DisplayName"].ToString();
                        newObj.ObjectID = item["ObjectID"].ToString();
                        newObj.ObjectTypeID = item["ObjectTypeID"].ToString();
                        newObj.ObjectTypeText = item["ObjectTypeText"].ToString();
                        newObj.ObjectTypeValue = item["ObjectTypeValue"].ToString();
                        returnObj.RadiusObjectAssociatedProperties.Add(newObj);
                    }
                }
            }
            return returnObj;
        }
    }
}
