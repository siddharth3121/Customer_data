using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee_data
{
    public partial class Customermaker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Username"]) == "" || Convert.ToString(Session["Role"]) == "")
            {
                Response.Redirect("default.aspx");
            }
            //else if (Convert.ToString(Session["Role"]) == "Maker")
            //{
            //    Response.Redirect("Customermaker.aspx");
            //}
            //else if (Convert.ToString(Session["Role"]) == "")
            //{
            //    Response.Redirect("Customermaker.aspx");
            //}
            //else
            //{
            //    Response.Redirect("default.aspx");
            //}


            //if (Convert.ToString(Session["Username"]) != "")
            //{
            //    Response.Redirect("Customermaker.aspx", false);
            //}else
            //{
            //    Response.Redirect("default.aspx");
            //}

        }

        //protected void Customermaker1(object sender, EventArgs e)
        //{
        //    if (Convert.ToString(Session["Username"]) != "")
        //    {                
        //        Response.Redirect("Customermaker.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("Default.aspx");
        //    }
        //}

        protected void Upload(object sender, EventArgs e)
        {
            //Upload and save the file
            string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(csvPath);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[13] { new DataColumn("CustomerId", typeof(int)),
            new DataColumn("CustomerName", typeof(string)),
            new DataColumn("Address_1", typeof(string)),
            new DataColumn("Address_2", typeof(string)),
            new DataColumn("Address_3", typeof(string)),
            new DataColumn("City", typeof(string)),
            new DataColumn("State", typeof(string)),
            new DataColumn("PIN", typeof(string)),
            new DataColumn("BankName", typeof(string)),
            new DataColumn("AccountNumber", typeof(string)),
            new DataColumn("PAN No", typeof(string)),
            new DataColumn("Bill No", typeof(string)),
            new DataColumn("Amount",typeof(string)) });


            string csvData = File.ReadAllText(csvPath);
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;
                    foreach (string cell in row.Split('|'))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }

           DataTable dt2 = RemoveDuplicateRows(dt,"CustomerId");

            string consString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name
                    sqlBulkCopy.DestinationTableName = "dbo.Customer_data";
                    con.Open();
                    sqlBulkCopy.WriteToServer(dt2);
                    con.Close();
                }
            }
        }

        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            //Datatable which contains unique records will be return as output.
            return dTable;
        }
    }
}