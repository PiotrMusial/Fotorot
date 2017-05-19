using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

public partial class StartLoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString);
        conn.Open();

        string checkUser = "select count(*) from Uzytkownicy where Login=@Login";
        SqlCommand com = new SqlCommand(checkUser, conn);
        com.Parameters.AddWithValue("@Login", TextBoxUserName.Text);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        conn.Close();
        if (temp > 0)
        {
            conn.Open();
            string checkPassword = "select Password from Uzytkownicy where Login=@Login";
            SqlCommand passCom = new SqlCommand(checkPassword, conn);
            passCom.Parameters.AddWithValue("@Login", TextBoxUserName.Text);
            string password = passCom.ExecuteScalar().ToString().Replace(" ", "");

            byte[] hashBytes = Convert.FromBase64String(password);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(TextBoxPassword.Text.ToString(), salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    Label1.Text = "Nieprawidłowe hasło";

            Session["userName"] = TextBoxUserName.Text;
            Response.Redirect("MainWebSite.aspx?UserName=" + TextBoxUserName.Text);
        }
        else
        {
            Label2.Text = "Nieprawidłowy login";
        }
    }
}