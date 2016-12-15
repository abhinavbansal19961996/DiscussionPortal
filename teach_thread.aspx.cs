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

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("teach_discussforum.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string t = Session["forumId"].ToString();

        String forumId = t.ToString();
        int cforumId = Convert.ToInt32(forumId);
       // int cforumId = Convert.ToInt32(Session["forumId"]);
        string comment = TextBox1.Text;
        string name = TextBox2.Text;
        DateTime date = DateTime.Now;
        PostThread.insertThread(cforumId, comment, name, date);
        GridView1.DataBind();
    
    }
}