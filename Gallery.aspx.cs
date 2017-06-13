using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Gallery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserName = Request.QueryString["UserName"];
        string id;

        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString))
        {
            var selectId = "select Id from Uzytkownicy where Login = @Login";
            using (var cmd = new SqlCommand(selectId, con))
            {
                cmd.Parameters.AddWithValue("@Login", UserName);
                con.Open();
                id = cmd.ExecuteScalar().ToString();
                con.Close();
            }

            var selectUserId = "select Id from Images where UserId=@userid order by Id DESC";
            using(var cmd = new SqlCommand(selectUserId, con))
            {
                cmd.Parameters.AddWithValue("@userid", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}