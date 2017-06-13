using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        int temp;

        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString))
        {
            var checkLogin = "select count(*) from Uzytkownicy where Login=@login";
            using (var cmd = new SqlCommand(checkLogin, con))
            {
                cmd.Parameters.AddWithValue("@login", TextBoxUN.Text);
                con.Open();
                temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                con.Close();
            }
        }

        if (temp != 0)
            Label1.Text = "Login jest zajęty";

        try
        {
            if (temp == 0)
            {
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                var pbkdf2 = new Rfc2898DeriveBytes(TextBoxPass.Text, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                string savedPasswordHash = Convert.ToBase64String(hashBytes);

                Guid newGuid = Guid.NewGuid();
                string id = newGuid.ToString();

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString))
                {
                    var sql = "insert into Uzytkownicy (Id, Login, Password) values (@id, @Uname, @password)";
                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@Uname", TextBoxUN.Text);
                        cmd.Parameters.AddWithValue("@password", savedPasswordHash);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                Response.Redirect("StartLoginPage.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.ToString());
        }
    }
}