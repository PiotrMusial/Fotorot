<%@ WebHandler Language="C#" Class="HandlerImage" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public class HandlerImage : IHttpHandler {

    public void ProcessRequest (HttpContext context) {

        int id = Convert.ToInt32(context.Request.QueryString["id"].ToString());
        SqlDataAdapter da;
        DataTable dt;

        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString))
        {
            var selectAll = "select * from Images where id=@id";
            using (var cmd = new SqlCommand(selectAll, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                con.Close();
            }
        }

        byte[] image = (byte[])dt.Rows[0]["Image"];

        context.Response.ContentType = "image/jpeg";
        context.Response.ContentType = "image/jpg";
        context.Response.ContentType = "image/png";

        context.Response.BinaryWrite(image);
        context.Response.Flush();
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}