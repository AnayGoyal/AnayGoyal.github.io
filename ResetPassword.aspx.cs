using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;

public partial class ResetPassword : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string forgot_otp = Request.QueryString["forgot_otp"].ToString();
        string email = Request.QueryString["email"].ToString();
        con.Open();
        string checkActivation = "select user_id from [userinfo] where email='" + email + "' and forgot_otp='" + forgot_otp + "'";
        SqlCommand checkCMD = new SqlCommand(checkActivation, con);
        SqlDataReader read = checkCMD.ExecuteReader();
        if (read.Read())
        {
            PlaceHolder1.Visible = true;
            PlaceHolder2.Visible = false;
            con.Close();
        }
        else
        {
            PlaceHolder1.Visible = false;
            PlaceHolder2.Visible = true;
            con.Close();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string email = Request.QueryString["email"].ToString();

        if(pass.Text.ToString() == conf_pass.Text.ToString())
        {
            con.Open();
            string uptadeAcc = "update [userinfo] set forgot_otp=0,password='"+pass.Text.ToString()+"' where email='" + email + "'";
            SqlCommand cmdUpdate = new SqlCommand(uptadeAcc, con);
            cmdUpdate.ExecuteNonQuery();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password Reset Succussfully. Please login to check.')", true);
            //errorMSG.Text = "Password Reset Succussfully. Please login to check.";
            //errorMSG.ForeColor = System.Drawing.Color.Green;
            con.Close();
            login.Visible = true;
            login.ForeColor = System.Drawing.Color.White;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password and Confirm Password did't Matched.')", true);
            //errorMSG.Text = "Password and Confirm Password did't Matched.";
            //errorMSG.ForeColor = System.Drawing.Color.Red;
        }
    }
}