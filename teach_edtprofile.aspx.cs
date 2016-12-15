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
            MainClass.teach_clslog obj = new MainClass.teach_clslog();
            List<MainClass.teach_clslogprp> k = obj.Find_Rec(Convert.ToInt32(Session["cod"]));
            if (k.Count > 0)
            {
                txtname.Text = k[0].teach_name;
                txteml.Text = k[0].teach_email;
                txtbio.Text = k[0].teach_bio;
                txtpwd.Text = k[0].teach_pass;

                //Editor1.Content = k[0].prfbio;
                ViewState["pic"] = k[0].teach_pic;
                Button1.Text = "Update";
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("teach_profile.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Int32 a;
        MainClass.teach_clslog obj = new MainClass.teach_clslog();
        MainClass.teach_clslogprp objprp = new MainClass.teach_clslogprp();
        objprp.teach_name = txtname.Text;
        objprp.teach_pass = txtpwd.Text;
        objprp.teach_bio = txtbio.Text;
        objprp.teach_email = txteml.Text;
        //objprp.prfbio = Editor1.Content;
        objprp.teach_Id = Convert.ToInt32(Session["cod"]);
        //objprp.prfprvstatus = Convert.ToChar(RadioButtonList1.SelectedValue);
        String pic = FileUpload1.PostedFile.FileName;
        if (pic != "")
        {
            pic = pic.Substring(pic.LastIndexOf('.'));

        }
        a = Convert.ToInt32(Session["cod"]);
        objprp.teach_pic ="T"+ a.ToString() + pic ;
        //Response.Write(objprp.stu_pic);
        //Response.Write(a.ToString());
        objprp.teach_Id = a;

        if (pic == "")
        {
            objprp.teach_pic = ViewState["pic"].ToString();
        }


        obj.Update_Rec(objprp);
        if (pic != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/teach_prfpics") + "//" +"T"+ a.ToString() + pic);
        }

        Response.Redirect("teach_profile.aspx");
    }
}