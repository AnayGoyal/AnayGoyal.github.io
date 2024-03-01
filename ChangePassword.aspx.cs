using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ChangePassword : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["email"] == null)
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        String cmd = "select user_id from[userinfo] where password='" + pass.Text.ToString() + "' and email='" + Session["email"] + "'";
        SqlCommand change_password = new SqlCommand(cmd, con);
        SqlDataReader read = change_password.ExecuteReader();
        if (read.Read())
        {
            con.Close();
            if (pass2.Text.Trim() == pass3.Text.Trim())
            {
                con.Open();
                string strUPDI = "update [userinfo] set password='" + pass2.Text.ToString() + "' where email='" + Session["email"] + "'";
                SqlCommand cmdUpdate = new SqlCommand(strUPDI, con);
                cmdUpdate.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password is Changed Successfully.')", true);
                //errorMSG.Text = "Password is Changed Successfully.";
                //errorMSG.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('New Password and Confirm Password are not same.')", true);
                //errorMSG.Text = "New Password and Confirm Password are not same.";
                //errorMSG.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Incorrect Old Password')", true);
            //errorMSG.Text = "Incorrect Old Password";
            //errorMSG.ForeColor = System.Drawing.Color.Red;
        }
    }
}