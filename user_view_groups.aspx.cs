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
        SqlDataAdapter adp = new SqlDataAdapter("select grp_id,grp_name from groups where grp_id in (select grp_id from grp_memb where stu_id="+ Session["cod"].ToString() + ")", cs);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }



    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VIEW")
        {
            LinkButton lnkview = (LinkButton)e.CommandSource;
            String grpid = lnkview.CommandArgument;
            //Label1.Text = grpid;
            Session["grp_id"] = grpid;
            //Label3.Text = grpid.ToString();
            //Response.Write(Session["grp_id"]);
            Response.Redirect("user_stuff.aspx");
        }
    }
}