using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace API.Models
{
    public static class CommanDataReader
    {
        public static string GetConnectionString()
        {
            string strConnectionString;
            strConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            return strConnectionString;
        }
        public const string GetGender = "GetGender";
        public const string GetChilddetails = "GetChilddetails";
        public const string AddEditChildData = "AddUpdateChildData";
        public const string DeleteChildData = "DeleteChildData";
        public const string GetSingleChilddetails = "GetSingleChilddetails";
        

        public const string GetSearchFilter = "GetSearchFilter";
        public const string AddDocument = "AddDocument";
        
    }
}