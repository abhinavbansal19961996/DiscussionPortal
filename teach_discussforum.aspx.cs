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

    protected void Button1_Click(object sender, EventArgs e)
    {
        string titleId = DropDownList1.Text;
        int ctitleId = Convert.ToInt32(titleId);
        string question = TextBox1.Text;
        string posteName = TextBox2.Text;
        DateTime dateTime = DateTime.Now;
        PostForum.insertForum(ctitleId, question, posteName, dateTime);
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Int64 ForumId = Convert.ToInt64(GridView1.SelectedRow.Cells[1].Text);
        Int64 ForumId = (Int64)GridView1.SelectedValue;
        
        Session["forumId"] = ForumId;
        Response.Redirect("teach_thread.aspx");
    }
}