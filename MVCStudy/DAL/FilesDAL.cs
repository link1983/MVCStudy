using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCStudy.Utilities;
using System.Data;

namespace MVCStudy.DAL
{
    public class FilesDAL
    {
        public List<Models.Files> Search(string keyword,string offset)
        {
            SqliteHelper sqlHelper = new SqliteHelper();
            DataSet ds = sqlHelper.QueryBySQL($"select fullname,modifiedtime,content from files where content like '%{keyword}%' or fullname like '%{keyword}%' {offset}");
            List<Models.Files> lFiles = new List<Models.Files>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Models.Files file = new Models.Files();
                file.FullName = dr[0].ToString();
                file.ModifiedTime = dr[1].ToString();
                file.Content = dr[2].ToString();
                lFiles.Add(file);
            }
            return lFiles;
        }
    }
}