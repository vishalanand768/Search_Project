using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Search_Project
{
    public partial class searchdata : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUser();
            }
        }

        public void BindUser()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Usp_Student", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 5);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            grd.DataSource = dt;
            grd.DataBind();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Usp_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 1);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@contact_no", txtcontact.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                BindUser();
            }
            else if (btnsave.Text=="Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Usp_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 2);
                cmd.Parameters.AddWithValue("@Id", ViewState["PP"]);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@contact_no", txtcontact.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                BindUser();
                btnsave.Text = "Save";
            }


        }
        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Usp_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 3);
                cmd.Parameters.AddWithValue("@Id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindUser();
            }
            else if (e.CommandName == "B")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Usp_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 4);
                cmd.Parameters.AddWithValue("@Id", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0][1].ToString();
                txtage.Text = dt.Rows[0][2].ToString();
                txtcity.Text = dt.Rows[0][3].ToString();
                txtcontact.Text = dt.Rows[0][4].ToString();
                btnsave.Text = "Update";
                ViewState["pp"] = e.CommandArgument;
            }
        }

    }
}
