using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class AddPicture : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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
            int row;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString))
            {
                var selectId = "select Id from Uzytkownicy where Login = @Login";
                using (var cmd = new SqlCommand(selectId, con))
                {
                    cmd.Parameters.AddWithValue("@Login", LinkButton1.Text.ToString());
                    con.Open();
                    id = cmd.ExecuteScalar().ToString();
                    con.Close();
                }

                var insertImage = "insert into Images (Image, UserId) values (@image, @userid)";
                using (var cmd = new SqlCommand(insertImage, con))
                {
                    cmd.Parameters.AddWithValue("@image", image);
                    cmd.Parameters.AddWithValue("@userid", id);
                    con.Open();
                    row = cmd.ExecuteNonQuery();
                    con.Close();
                } 
            }

            if (row > 0)
            {
                Label1.Text = "Zdjęcie dodane pomyślnie";
                Response.Redirect("MainWebSite.aspx?UserName=" + LinkButton1.Text);
            }
            else
                Label1.Text = "Nie dodano zdjęcia";
        }
        else Label1.Text = "Dodaj zdjęcie";
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Gallery.aspx");
    }
}