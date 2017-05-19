using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Gallery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserName = Request.QueryString["UserName"];

        string id;
        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString))
        {
            var sql = "select Id from Uzytkownicy where Login = @Login";
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@Login", UserName);
                con.Open();
                id = cmd.ExecuteScalar().ToString();
                con.Close();
            }
        }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "select Id from Images where UserId=@userid order by Id DESC";
        comm.Parameters.AddWithValue("@userid", id);

        SqlDataAdapter da = new SqlDataAdapter(comm);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}