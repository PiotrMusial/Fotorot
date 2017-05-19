using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

public partial class AddPicture : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

        if (Request.QueryString["UserName"] != null)
            LinkButton1.Text = Request.QueryString["UserName"];
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (FileUpload1.PostedFile.FileName != "")
        {
            byte[] image;
            Stream s = FileUpload1.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(s);
            image = br.ReadBytes((Int32)s.Length);

            string id;
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString)) {
                var sql = "select Id from Uzytkownicy where Login = @Login";
                using (var cmd = new SqlCommand(sql, con)) {
                    cmd.Parameters.AddWithValue("@Login", LinkButton1.Text.ToString());
                    con.Open();
                    id = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString);
            SqlCommand addPicture = new SqlCommand();
            addPicture.Connection = conn;
            addPicture.CommandText = "insert into Images (Image, UserId) values (@image, @userid)";
            addPicture.Parameters.AddWithValue("@image", image);
            addPicture.Parameters.AddWithValue("@userid", id);

            conn.Open();

            int row = addPicture.ExecuteNonQuery();
            conn.Close();

            if (row > 0)
            {
                Label1.Text = "Zdjęcie dodane pomyślnie";
                Response.Redirect("MainWebSite.aspx?UserName=" + LinkButton1.Text);
            }
        }
        else Label1.Text = "Dodaj zdjęcie";
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Gallery.aspx");
    }
}