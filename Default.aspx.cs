using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee_data
{
    public partial class _Default : Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string Username = TextBox1.Text;
            string Password = TextBox2.Text;
            string sQuery = "Select * from Usertable where Username =@Username and Password=@Password";

            SqlConnection sqlcon = new SqlConnection(con);
            SqlCommand sqlcom = new SqlCommand(sQuery,sqlcon);
            sqlcom.Parameters.AddWithValue("@Username",Username);
            sqlcom.Parameters.AddWithValue("@Password", Password);
            SqlDataAdapter ConnData = new SqlDataAdapter(sqlcom);
            sqlcon.Open();
            ConnData.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["Username"] = Username;
                Session["Role"] = dt.Rows[0]["Role"].ToString();
                if (dt.Rows[0]["Role"].ToString() == "Maker")
                {
                    Response.Redirect("Customermaker.aspx");
                }
                else if (dt.Rows[0]["Role"].ToString() == "Checker")
                {
                    Response.Redirect("Customerchecker.aspx");
                }                              
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}