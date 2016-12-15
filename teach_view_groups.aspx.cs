using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class _Default : System.Web.UI.Page
{
    String cs;
    protected void Page_Load(object sender, EventArgs e)
    {
        cs = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        if (!Page.IsPostBack)
        {
            Grid_Bind();
        }
    }
    protected void Grid_Bind()
    {
        SqlDataAdapter adp = new SqlDataAdapter("select * from groups", cs);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }



    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {


        //String group_Id = GridView1.SelectedRow.Cells[0].Text;
        Int64 GroupId = (Int64)GridView1.SelectedValue;
        //int groupId = Convert.ToInt32(group_Id);
        Session["groupId"] = GroupId;
        Response.Redirect("stuff.aspx");
    }
}