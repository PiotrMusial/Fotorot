using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;

public partial class Registration : System.Web.UI.Page
{
    int temp = 0;
    Random rnd = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString);
        connn.Open();

        string checkUser = "select count(*) from Uzytkownicy where Login=@login";
        SqlCommand comm = new SqlCommand(checkUser, connn);
        comm.Parameters.AddWithValue("@login", TextBoxUN.Text);
        int temp = Convert.ToInt32(comm.ExecuteScalar().ToString());
        if (temp != 0)
        {
            Label1.Text = "Login jest zajęty";
        }
        connn.Close();

        try
        {
            if (temp == 0)
            {
                Guid newGuid = Guid.NewGuid();
                string id = newGuid.ToString();

                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                var pbkdf2 = new Rfc2898DeriveBytes(TextBoxPass.Text, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                string savedPasswordHash = Convert.ToBase64String(hashBytes);

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString);
                conn.Open();

                string insertQuery = "insert into Uzytkownicy (Id, Login, Password) values (@id, @Uname, @password)";
                SqlCommand com = new SqlCommand(insertQuery, conn);

                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@Uname", TextBoxUN.Text);
                com.Parameters.AddWithValue("@password", savedPasswordHash);

                com.ExecuteNonQuery();
                Response.Redirect("StartLoginPage.aspx");
                conn.Close();
            }
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.ToString());
        }
    }
}