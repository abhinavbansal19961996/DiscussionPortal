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
        Label1.Text = String.Empty;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        MainClass.stu_clslog obj = new MainClass.stu_clslog();
        MainClass.stu_clslogprp objprp = new MainClass.stu_clslogprp();

        try
        {
            objprp.stu_id = Convert.ToInt32(txteml.Text);
        }
        catch
        {
            Label1.Text ="";
        }
        objprp.stu_pass = txtpwd.Text;
        Int32 temp = obj.stu_logincheck(objprp);
        if (temp == -1)
        {
            Label1.Text = "Username or Password Wrong";
        }
        else
        {
            Session["cod"] = temp;
            Label1.Text = "Login Successful";
            Response.Redirect("user_profile.aspx");
        }
    }
}