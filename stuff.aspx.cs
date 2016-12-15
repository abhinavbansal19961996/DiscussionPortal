using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
public partial class _Default : System.Web.UI.Page
{ SqlConnection con = new SqlConnection();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        //Label1.Text = Session["grp_id"].ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        
        SqlCommand cmd = new SqlCommand("pro_insert_docs");
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
     
        cmd.Parameters.Add("@p_grp_id", SqlDbType.Int).Value = Convert.ToInt32(Session["grp_id"]);
        cmd.Parameters.Add("@p_notes", SqlDbType.VarChar).Value = TextBox1.Text;
        
        String pic = FileUpload1.PostedFile.FileName;

        if (pic != "")
        {
            pic = pic.Substring(pic.LastIndexOf('.'));



            Int32 a = Convert.ToInt32(Session["grp_id"]);
            pic = "Group-" + a.ToString() + "-" + "File" + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + pic;
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/teach_posts") + "//"  + pic);
        }
        cmd.Parameters.Add("@p_file_name", SqlDbType.VarChar, 50).Value =pic;

        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
        Response.Redirect("teach_profile.aspx");
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         Response.Clear();  
    Response.ContentType = "application/octet-stream";  
    Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);  
    Response.TransmitFile(Server.MapPath("~/teach_posts/") + e.CommandArgument);  
    Response.End();   
    }
}