using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class MainWebSite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

        if (Request.QueryString["UserName"] != null)
            LinkButton1.Text = Request.QueryString["UserName"];

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "select Id from Images order by Id DESC";

        SqlDataAdapter da = new SqlDataAdapter(comm);
        DataTable dt = new DataTable();
        da.Fill(dt);

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