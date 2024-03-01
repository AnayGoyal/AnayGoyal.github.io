using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ActivateAccount : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string activation_code = Request.QueryString["activation_code"].ToString();
        string email = Request.QueryString["email"].ToString();

        con.Open();
        string checkActivation = "select user_id from [userinfo] where email='" + email + "' and activation_code='" + activation_code + "' and activation_code !=0 and is_active !=1";
        SqlCommand checkCMD = new SqlCommand(checkActivation, con);
        SqlDataReader read = checkCMD.ExecuteReader();
        if(read.Read())
        {
            con.Close();
            con.Open();
            string uptadeAcc = "update [userinfo] set is_active=1, activation_code=0 where email='" + email + "'";
            SqlCommand cmdUpdate = new SqlCommand(uptadeAcc, con);
            cmdUpdate.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your account is acctivated successfully. Please login to your account')", true);
            //errorMSG.Text = "Your account is acctivated successfully. Please login to your account";
            //errorMSG.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Link is expired')", true);
            //errorMSG.Text = "Link is expired";
            //errorMSG.ForeColor = System.Drawing.Color.Red;
            con.Close();
        }
    }
}