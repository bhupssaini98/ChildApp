using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace API.Shared
{
    public static class Common
    {

        public static string GetFileName(string FileName)
        {
            String extension = FileName.Substring(FileName.LastIndexOf(".") + 1);
            string file = Regex.Replace(FileName, @"\s+", "");
            file = file.Substring(0, file.LastIndexOf("."));
            return file + "_" + DateTime.Now.ToString("yyyyMMdd_hhmmss")+"."+ extension;
        }

    }
}