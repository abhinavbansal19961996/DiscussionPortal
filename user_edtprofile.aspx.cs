using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            MainClass.stu_clslog obj = new MainClass.stu_clslog();
            List<MainClass.stu_clslogprp> k = obj.Find_Rec(Convert.ToInt32(Session["cod"]));
            if (k.Count > 0)
            {
                txtname.Text = k[0].stu_name;
                txteml.Text = k[0].stu_email;
                txtbio.Text = k[0].stu_bio;
                txtpwd.Text = k[0].stu_pass;

                //Editor1.Content = k[0].prfbio;
                ViewState["pic"] = k[0].stu_pic;
                Button1.Text = "Update";
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Int32 a;
        MainClass.stu_clslog obj = new MainClass.stu_clslog();
        MainClass.stu_clslogprp objprp = new MainClass.stu_clslogprp();
        objprp.stu_name = txtname.Text;
        objprp.stu_pass = txtpwd.Text;
        objprp.stu_bio= txtbio.Text;
        objprp.stu_email = txteml.Text;
        //objprp.prfbio = Editor1.Content;
        objprp.stu_id= Convert.ToInt32(Session["cod"]);
        //objprp.prfprvstatus = Convert.ToChar(RadioButtonList1.SelectedValue);
        String pic = FileUpload1.PostedFile.FileName;
        if (pic != "")
        {
            pic = pic.Substring(pic.LastIndexOf('.'));

        }
        a = Convert.ToInt32(Session["cod"]);
        objprp.stu_pic =  a.ToString() + pic;
        //Response.Write(objprp.stu_pic);
        //Response.Write(a.ToString());
        objprp.stu_id = a;
       
            if (pic == "")
            {
                objprp.stu_pic = ViewState["pic"].ToString();
            }

       
        obj.Update_Rec(objprp);
        if (pic != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/prfpics") + "//" + a.ToString() + pic);
        }
        
       Response.Redirect("user_profile.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {   
        Response.Redirect("user_profile.aspx");
    }
}