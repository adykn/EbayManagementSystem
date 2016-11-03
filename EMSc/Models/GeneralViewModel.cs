using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using AdyknDll.MeNaNu;

namespace EMSc.Models
{   
     
    public class GeneralViewModel
    {
        
        public SqlConnection Con()
        {
            SqlConnection conn = new SqlConnection("Data Source=JAFFAR-PC\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");

            return conn;
        }         
        public DataSet GetData4Ds(string sql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, Con());
            da.Fill(ds);
            Con().Close();
            Con().Dispose();
            da.Dispose();
            return ds;
        }
        public DataSet GetData4Ds(string TableName, string condition, string columns)
        {
            string sql = "select " + columns + " from " + TableName + " Where " + condition;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, Con());
            da.Fill(ds);
            Con().Close();
            Con().Dispose();
            da.Dispose();
            return ds;
        }
        public DataTable GetData4Dt(string TableName, string condition, string columns)
        {
            string sql = "select " + columns + " from " + TableName;//+ " Where " + condition;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, Con());
            da.Fill(ds);
            Con().Close();
            Con().Dispose();
            da.Dispose();
            return ds.Tables[TableName];
        }
    }
}