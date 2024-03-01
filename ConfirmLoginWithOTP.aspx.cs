using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class ConfirmLoginWithOTP : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        string selectUser = "select user_id,name,email,login_otp_created from [userinfo] where email='" + email.Text.ToString() + "' and login_otp='" + pass.Text.ToString() + "' and is_active=1";
        SqlCommand selCmd = new SqlCommand(selectUser, con);
        SqlDataReader read = selCmd.ExecuteReader();
        if (read.Read())
        {
            var start = DateTime.Now;
            var oldTime = DateTime.Parse(read.GetValue(3).ToString().Trim());
            if (start.Subtract(oldTime) >= TimeSpan.FromMinutes(3))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login OTP is Expired.')", true);
                //errorMSG.Text = "Login OTP is Expired.";
                //errorMSG.ForeColor = System.Drawing.Color.Red;
                con.Close();
            }
            else
            {
                Session["user_id"] = read.GetValue(0).ToString();
                Session["name"] = read.GetValue(1).ToString();
                Session["email"] = read.GetValue(2).ToString();
                con.Close();
                Response.Redirect("Home.aspx");
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login OTP is not Correct.')", true);
            //errorMSG.Text = "Login OTP is not Correct.";
            //errorMSG.ForeColor = System.Drawing.Color.Red;
            con.Close();
        }
    }
}