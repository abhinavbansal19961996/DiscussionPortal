using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="VIEW")
        { LinkButton lnkview = (LinkButton)e.CommandSource;
            string grpid = lnkview.CommandArgument;
            //Label1.Text = grpid;
            Session["grp_id"] = grpid;
            Response.Redirect("stuff.aspx");
        }
    }
}