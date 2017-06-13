using System;
using System.Web.UI;
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
        int temp;

        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString))
        {
            var ifLoginExist = "select count(*) from Uzytkownicy where Login=@Login";
            using (var cmd = new SqlCommand(ifLoginExist, con))
            {
                cmd.Parameters.AddWithValue("@Login", TextBoxUserName.Text);
                con.Open();
                temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
        }

        if (temp > 0)
        {
            string password;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString))
            {
                var checkPassword = "select Password from Uzytkownicy where Login=@Login";
                using (var cmd = new SqlCommand(checkPassword, con))
                {
                    cmd.Parameters.AddWithValue("@Login", TextBoxUserName.Text);
                    con.Open();
                    password = cmd.ExecuteScalar().ToString().Replace(" ", "");
                    con.Close();
                }
            }

            byte[] hashBytes = Convert.FromBase64String(password);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(TextBoxPassword.Text.ToString(), salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    Label1.Text = "Nieprawidłowe hasło";
                }
                else
                {
                    Session["userName"] = TextBoxUserName.Text;
                    Response.Redirect("MainWebSite.aspx?UserName=" + TextBoxUserName.Text);
                }
            }
            
                    

            
        } else
            Label2.Text = "Nieprawidłowy login";
    }
}