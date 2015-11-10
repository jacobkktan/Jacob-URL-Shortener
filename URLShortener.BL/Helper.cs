using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using URLShortener.DAL;
using URLShortener.ENTITY;
using System.Web;

namespace URLShortener.BL
{
    public class Helper
    {
        private RepoHelper repo;

        public Helper(string dbPath = "")
        {
            if(string.IsNullOrEmpty(dbPath))
                dbPath = Path.Combine(HttpContext.Current.Server.MapPath("~"), "DB", "shortener.db");
            repo = new RepoHelper(dbPath);
            
        }

        public string InsertRecord(string url)
        {
            var code = ShortGeneratorHelper.GenerateCode();
            var sql = string.Format("insert into shortdata (shortcode,fullurl) values ('{0}','{1}')", code , url);
            try
            {
                repo.Execute(sql);
                return code;
            } catch(Exception ex)
            {
                //if message says unique constrain, try again
                if (ex.Message.Contains("UNIQUE constraint failed"))
                    return InsertRecord(url);
                return string.Empty;
            }
        }

        public string GetUrl(string shortcode)
        {
            var sql = string.Format("select fullurl from shortdata where shortcode='{0}'",shortcode);
            try
            {
                var ds = repo.Read(sql);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) return ds.Tables[0].Rows[0][0].ToString();
                else return string.Empty;
            } catch(Exception ex)

            {
                //log ex;
                return string.Empty;
            }
        }

        public bool DeleteUrl(string shortcode)
        {
            var sql = string.Format("delete from shortdata where shortcode='{0}'", shortcode);
            try
            {
                var ds = repo.Execute(sql);
                return true;
            }
            catch (Exception ex)

            {
                //log ex;
                return false;
            }
        }



    }
}
