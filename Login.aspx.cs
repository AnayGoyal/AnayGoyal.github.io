using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.Cookies["email"] != null && Request.Cookies["password"] != null)
            {
                email.Text = Request.Cookies["email"].Value;
                pass.Attributes["value"] = Request.Cookies["password"].Value;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //con.Open();
        //string checkUser = "select user_id,name,email,username,password,code,isactive from [userinfo] where email=@email and password=@pass";
        //SqlCommand checkCmd = new SqlCommand(checkUser, con);
        //checkCmd.Parameters.AddWithValue("@email", email.Text.ToString());
        //checkCmd.Parameters.AddWithValue("@pass", pass.Text.ToString());
        //SqlDataReader read = checkCmd.ExecuteReader();
        //if (read.Read())
        //{
        //    Session["user_id"] = read.GetValue(0).ToString();
        //    Session["name"] = read.GetValue(1).ToString();
        //    Session["email"] = read.GetValue(2).ToString();
        //    Session["username"] = read.GetValue(3).ToString();
        //    con.Close();
        //    Response.Redirect("Home.aspx");
        //}
        //else
        //{
        //    errorMSG.Text = "Invalid Username or password.";
        //    errorMSG.ForeColor = System.Drawing.Color.Red;
        //    con.Close();
        //}

        if (captchaCode.Text.ToLower() == Session["sessionCaptcha"].ToString())
        {
            con.Open();
            string selectUser = "select user_id,name,email from [userinfo] where email='" + email.Text.ToString() + "' and password='" + pass.Text.ToString() + "' and is_active=1";
            SqlCommand selCmd = new SqlCommand(selectUser, con);
            SqlDataReader read = selCmd.ExecuteReader();
            if (read.Read())
            {
                if (Chkme.Checked)
                {
                    Response.Cookies["email"].Value = email.Text;
                    Response.Cookies["password"].Value = pass.Text;
                    Response.Cookies["email"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["password"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    Response.Cookies["email"].Expires = DateTime.Now.AddMinutes(-1);
                    Response.Cookies["password"].Expires = DateTime.Now.AddMinutes(-1);
                }
                Session["user_id"] = read.GetValue(0).ToString();
                Session["name"] = read.GetValue(1).ToString();
                Session["email"] = read.GetValue(2).ToString();
                con.Close();
                Response.Redirect("Home.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your account is not activated or your email is not registered with us.')", true);
                con.Close();
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Captcha code is incorrect. Please enter correct Captcha Code.')", true);
            con.Close();
        }

    }
}