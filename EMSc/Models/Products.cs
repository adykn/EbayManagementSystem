using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using EMSc.Models;

namespace EMSc.Models
{
    public class Products
    {
        public enum Duration { Day_1, Day_2, Day_3, Day_4, Day_5, Day_6, Day_7, Day_8 }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long itemid { get; set; }
        public String sku { get; set; }
        public String Currency { get; set; }
        public String Country { get; set; }
        public String Title { get; set; }
        public string Description { get; set; }
        public Int32 Quantity { get; set; }
        public string Location { get; set; }
        public String ListingDuration { get; set; }
        public long CategoryID { get; set; }
        public long CategoryID2 { get; set; }
        public double StartPrice { get; set; }
        public double ReservePrice { get; set; }
        public double BuyItNowPrice { get; set; }
        public string ListingType { get; set; }
        //public string BestOfferDetails { get; set; }
        public string PayPalEmailAddress { get; set; }
        public string ApplicationData { get; set; }
        public long ConditionID { get; set; }
        public DateTime TimeStamp { get; set; }
        public virtual ShippingModel shipping { get; set; }
        public virtual PolicyModel policy { get; set; }
        //SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //SqlCommand cmd = new SqlCommand();

        ////Creating function to insert details
        //public string Insert(Products obj)
        //{
        //    string sql = null;
        //    string f = null;
        //    string v = null;
        //    string temp = null;
        //    foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
        //    {
        //        f += propertyInfo.Name + ",";
        //        temp = propertyInfo.PropertyType.Name.ToLower();
        //        if (temp == "double" || temp == "long" || temp == "int" || temp == "int16" || temp == "int32" || temp == "int64" || temp == "decimal" || temp == "single")
        //        {
        //            v += propertyInfo.GetValue(obj, null)+",";
        //        }else {
        //            v +="'"+ propertyInfo.GetValue(obj, null)+"',";
        //        }
        //    }
        //    if (f.EndsWith(","))
        //        f = f.Substring(0, f.Length - 1);
        //    if (v.EndsWith(","))
        //        v = v.Substring(0, v.Length - 1);

        //    sql = "Insert into Products (" + f + ") values (" + v + ")";
        //    cmd.CommandText = sql;
        //        //"Insert into [Table] values('" + obj.Name + "','" + obj.EmailID + "'," + Convert.ToInt64(obj.Mobilenumber) + ",'" + obj.Address + "')";
        //    cmd.Connection = con;

        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        return "Success";

        //}


        //public DataSet ds = new DataSet();
        //public DataTable dt = new DataTable();
        //public void FillDS(string TableName, string condition,string columns) {
        //    string sql = "select " + columns + " from " + TableName + " Where " + condition;
        //    SqlConnection Con = new SqlConnection("Data Source=JAFFAR-PC\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        //    SqlDataAdapter da = new SqlDataAdapter(sql, Con);
        //    da.Fill(ds, TableName);
        //    Con.Close();
        //    Con.Dispose();
        //    da.Dispose();
        //    }
        //public void FillDT(string TableName, string condition, string columns)
        //{
        //    string sql = "select " + columns + " from " + TableName + " Where " + condition;
        //    SqlConnection Con = new SqlConnection("Data Source=JAFFAR-PC\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        //    SqlDataAdapter da = new SqlDataAdapter(sql, Con);
        //    if (ds.Tables.Contains(TableName)) { ds.Tables.Remove(TableName); }
        //    da.Fill(ds, TableName);
        //    Con.Close();
        //    Con.Dispose();
        //    da.Dispose();
        //    dt = ds.Tables[TableName];
        //}



    }


}
