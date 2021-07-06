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
    public partial class Customerchecker : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Convert.ToString(Session["Username"]) != "")
            //{
            //    Response.Redirect("Customerchecker.aspx", false);
            //}
            //else
            //{
            //    Response.Redirect("default.aspx");
            //}

            if (Convert.ToString(Session["Username"]) == "" || Convert.ToString(Session["Role"]) == "")
            {
                Response.Redirect("default.aspx");
            }
            Getdata();
            //else
            //{
            //    Response.Redirect("Customerchecker.aspx");
            //}
        }

        //protected void Customerchecker1(object sender, EventArgs e)
        //{
        //    if (Convert.ToString(Session["Username"]) != "")
        //    {
        //        Response.Redirect("Customerchecker.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("Default.aspx");
        //    }
        //}

       public void Getdata()
        {
            
            DataTable dt = new DataTable();
            String sQuery = "Select * from Customer_data";
            SqlConnection Sqlcon = new SqlConnection(con);
            SqlCommand Sqlcom = new SqlCommand(sQuery, Sqlcon);
            SqlDataAdapter Adap = new SqlDataAdapter(Sqlcom);
            Adap.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                {
                    string Status = DropDownList1.SelectedItem.Value;
                    string ApproveorReject = TextArea1.Value;
                    var lblID = gvrow.FindControl("Label1") as Label;
                    var lblName = gvrow.FindControl("Label2") as Label;
                    var lblCity = gvrow.FindControl("Label3") as Label;
                    SqlConnection Sqlcon = new SqlConnection(con);
                    SqlCommand cmd = new SqlCommand("insert into Customer_data (Status,ApproveorReject) values (@Status,@ApproveorReject)", Sqlcon);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@ApproveorReject", ApproveorReject);
                    
                    Sqlcon.Open();
                    int i = cmd.ExecuteNonQuery();
                    Sqlcon.Close();
                    Getdata();
                }
            }
        }
    }
}