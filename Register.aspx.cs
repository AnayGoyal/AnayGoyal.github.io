using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

public partial class Register : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_ddlCountry();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (captchaCode.Text.ToLower() == Session["sessionCaptcha"].ToString())
        {
            con.Open();
            SqlCommand checkEmail = new SqlCommand("select email from [userinfo] where email='" + email.Text.ToString() + "'", con);
            SqlDataReader read = checkEmail.ExecuteReader();
            if (read.HasRows)
            {
                //lblError.Text = "This email address already exists. Please try with different email address.";
                //lblError.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('This email address already exists. Please try with different email address.')", true);
                con.Close();
            }
            else
            {
                con.Close();

                Random random = new Random();
                int myRandom = random.Next(100000, 999999);
                string activation_code = myRandom.ToString();
                con.Open();
                string inertUser = "insert into [userinfo] (name,email,password,country,state,city,activation_code,is_active) values (@name,@email,@password,@country,@state,@city,@activation_code,@is_active)";
                SqlCommand insertCmd = new SqlCommand(inertUser, con);
                insertCmd.Parameters.AddWithValue("@name", name.Text.ToString());
                insertCmd.Parameters.AddWithValue("@email", email.Text.ToString());
                insertCmd.Parameters.AddWithValue("@password", pass.Text.ToString());
                insertCmd.Parameters.AddWithValue("@country", ddlcountry.Text.ToString());
                insertCmd.Parameters.AddWithValue("@state", ddlstate.Text.ToString());
                insertCmd.Parameters.AddWithValue("@city", ddlcity.Text.ToString());
                insertCmd.Parameters.AddWithValue("@activation_code", activation_code);
                insertCmd.Parameters.AddWithValue("@is_active", 0);
                insertCmd.ExecuteNonQuery();

                MailMessage mail = new MailMessage();
                mail.To.Add(email.Text.ToString());
                mail.From = new MailAddress("anay31dec@gmail.com");
                mail.Subject = "Thank you for registering with us.";

                string emailBody = "";
                emailBody += "<h1>Hello " + name.Text.ToString() + ",</h1>";
                emailBody += "Click Below Link for Activation of your Account.<br/>";
                emailBody += "<p><a href='" + "http://localhost:49376/ActivateAccount.aspx?activation_code=" + activation_code + "&email=" + email.Text.ToString() + "'>Click here to Activate</a></p>";
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

                //lblError.Text = "You are registered successfully. Please check your email inbox/spam folder for Activation.";
                //lblError.ForeColor = System.Drawing.Color.Green;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You are registered successfully. Please check your email inbox/spam folder for Activation.')", true);
                con.Close();
            }
        }
        else
        {
            //lblError.Text = "Captcha code is incorrect. Please enter correct Captcha Code.";
            //lblError.ForeColor = System.Drawing.Color.Red;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Captcha code is incorrect. Please enter correct Captcha Code.')", true);
            con.Close();
        }
    }

    public void Bind_ddlCountry()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select Country,CountryId from Country where is_active=1", con);
        SqlDataReader dr = cmd.ExecuteReader();
        ddlcountry.DataSource = dr;
        ddlcountry.Items.Clear();
        ddlcountry.Items.Add("--Please Select country--");
        ddlcountry.DataTextField = "Country";
        ddlcountry.DataValueField = "CountryId";
        ddlcountry.DataBind();
        con.Close();
    }
    public void Bind_ddlState()
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("select State,StateID from countryState where is_active=1 and CountryId='" + ddlcountry.SelectedValue + "'", con);

        SqlDataReader dr = cmd.ExecuteReader();
        ddlstate.DataSource = dr;
        ddlstate.Items.Clear();
        ddlstate.Items.Add("--Please Select state--");
        ddlstate.DataTextField = "State";
        ddlstate.DataValueField = "StateID";
        ddlstate.DataBind();
        con.Close();
    }
    public void Bind_ddlCity()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from stateCity where is_active=1 and StateId ='" + ddlstate.SelectedValue + "'", con);

        SqlDataReader dr = cmd.ExecuteReader();
        ddlcity.DataSource = dr;
        ddlcity.Items.Clear();
        ddlcity.Items.Add("--Please Select city--");
        ddlcity.DataTextField = "City";
        ddlcity.DataValueField = "CityID";
        ddlcity.DataBind();
        con.Close();
    }
    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_ddlState();
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_ddlCity();
    }
}