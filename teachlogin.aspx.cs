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

        MainClass.teach_clslog obj = new MainClass.teach_clslog();
        MainClass.teach_clslogprp objprp = new MainClass.teach_clslogprp();

        try
        {
            objprp.teach_Id = Convert.ToInt32(txteml.Text);
        }
        catch
        {
            Label1.Text = "";
        }
        objprp.teach_pass = txtpwd.Text;
        Int32 temp = obj.teach_logincheck(objprp);
        if (temp == -1)
        {
            Label1.Text = "Username or Password Wrong";
        }
        else
        {
            Session["cod"] = temp;
           // Label1.Text = "Login Successful";
             Response.Redirect("teach_profile.aspx");
        }
    }
}