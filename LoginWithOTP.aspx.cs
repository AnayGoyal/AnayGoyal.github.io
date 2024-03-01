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

public partial class LoginWithOTP : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        string selectUser = "select user_id from [userinfo] where email='" + email.Text.ToString() + "' and is_active=1";
        SqlCommand selCmd = new SqlCommand(selectUser, con);
        SqlDataReader read = selCmd.ExecuteReader();
        if (read.Read())
        {
            con.Close();
            Random random = new Random();
            int myRandom = random.Next(100000, 999999);
            string login_otp = myRandom.ToString();

            con.Open();
            string uptadeAcc = "update [userinfo] set login_otp='" + login_otp + "', login_otp_created='"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"' where email='" + email.Text.ToString() + "'";
            SqlCommand cmdUpdate = new SqlCommand(uptadeAcc, con);

            cmdUpdate.ExecuteNonQuery();
            con.Close();

            MailMessage mail = new MailMessage();
            mail.To.Add(email.Text.ToString());
            mail.From = new MailAddress("anay31dec@gmail.com");
            mail.Subject = "Login OTP";

            string emailBody = "";
            emailBody += "<h1>Hello User,</h1>";
            emailBody += "<h3>This OTP is valid for 3 minutes only,</h3>";            
            emailBody += "<p>Login OTP: " + login_otp + "</p>";
            emailBody += "<p><a href='" + "http://localhost:49376/ConfirmLoginWithOTP.aspx" + "'>Click here to Login with OTP</a></p>";
            emailBody += "Thank you......";
            mail.Body = emailBody;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("anay31dec@gmail.com", "xvtqhkkxnytzwzxz");
            smtp.Send(mail);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login OTP sent successfully.')", true);
            //errorMSG.Text = "Login OTP sent successfully.";
            //errorMSG.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your email is not associated with us.')", true);
            //errorMSG.Text = "Your email is not associated with us.";
            //errorMSG.ForeColor = System.Drawing.Color.Red;
            con.Close();
        }
    }
}