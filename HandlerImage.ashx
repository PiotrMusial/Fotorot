<%@ WebHandler Language="C#" Class="HandlerImage" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

public class HandlerImage : IHttpHandler {

    public void ProcessRequest (HttpContext context) {

        int id = Convert.ToInt32(context.Request.QueryString["id"].ToString());
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UzytkownicyConnectionString"].ConnectionString);
        conn.Open();

        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "select * from Images where id=@id";
        comm.Parameters.AddWithValue("@id", id);

        SqlDataAdapter da = new SqlDataAdapter(comm);
        DataTable dt = new DataTable();
        da.Fill(dt);

        byte[] image = (byte[])dt.Rows[0]["Image"];

        context.Response.ContentType = "image/jpeg";
        context.Response.ContentType = "image/jpg";
        context.Response.ContentType = "image/png";

        context.Response.BinaryWrite(image);
        context.Response.Flush();

        conn.Close();
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}