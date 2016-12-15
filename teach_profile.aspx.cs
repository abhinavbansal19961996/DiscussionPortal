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
        if (Page.IsPostBack == false)
        {
            Int32 a = 0;

            a = Convert.ToInt32(Session["cod"]);

            MainClass.teach_clslog obj = new MainClass.teach_clslog();
            List<MainClass.teach_clslogprp> k = obj.Find_Rec(a);
            if (k.Count != 0)
            {
                lb1.Text = "Welcome Professor " + (k[0].teach_name).ToString();
                lb2.Text = (k[0].teach_Id).ToString();
                lbeml.Text = (k[0].teach_email).ToString();
                lb3.Text = (k[0].teach_bio).ToString();
                //lt1.Text = k[0].prfbio;
                //img1.ImageUrl = "~/prfpics/" + k[0].prfcod + k[0].prfbackpic;
                img2.ImageUrl = "~/teach_prfpics/" + k[0].teach_pic;// + k[0].prfcod + k[0].prfpic;

            }
        }
    }
}