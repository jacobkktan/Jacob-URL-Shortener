using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace URLShortener.DAL
{
    public class RepoHelper
    {
        /// <summary>
        /// DB Connection object
        /// </summary>
        private SQLiteConnection dbConn;

        /// <summary>
        /// DB Connection string
        /// </summary>
        private string dbConnString;

        /// <summary>
        /// Instiantiate the helper class with connection string
        /// if connstring is empty, get value from configuration
        /// </summary>
        public RepoHelper(string dbpath = "")
        {
            //Data Source=MyDatabase.sqlite;Version=3;
            dbConnString = string.Format("Data Source = {0}; Version = 3",
                dbpath);//

            //check if dbfile exists, if not create

            dbConn = new SQLiteConnection(dbConnString);
            dbConn.Open();
        }

        /// <summary>
        /// Executes a sql command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool Execute(string sql)
        {
            try
            {
                var command = new SQLiteCommand(sql,dbConn);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Read from sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet Read(string sql)
        {
            try
            {
                DataSet ds = new DataSet();
                var command = new SQLiteCommand(sql, dbConn);
                var adaptor = new SQLiteDataAdapter(command);
                adaptor.Fill(ds);
                return ds; 
            }
            catch (Exception ex)
            {
                //not live environment, 
                //else do logging
                throw ex;
            }
        }
    }
}
