using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class MainWebSite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

        LinkButton1.Text = Request.QueryString["UserName"];

        SqlDataAdapter da;
        DataTable dt;

        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString))
        {
            var selectImages = "select Id from Images order by Id DESC";
            using (var cmd = new SqlCommand(selectImages, con))
            {
                con.Open();
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                con.Close();
            }
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AddPicture.aspx?UserName=" + LinkButton1.Text);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Gallery.aspx?UserName=" + LinkButton1.Text);
    }

    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        Session["UserName"] = null;
        Response.Redirect("StartLoginPage.aspx");
    }
}