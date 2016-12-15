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
             
            MainClass.stu_clslog obj = new MainClass.stu_clslog();
            List<MainClass.stu_clslogprp> k = obj.Find_Rec(a);
            if (k.Count != 0)
            {
                lb1.Text = "Welcome PECOBIAN " + (k[0].stu_name).ToString();
                lb2.Text = (k[0].stu_id).ToString();
                lbeml.Text = (k[0].stu_email).ToString();
                lb3.Text = (k[0].stu_bio).ToString();
                //lt1.Text = k[0].prfbio;
                //img1.ImageUrl = "~/prfpics/" + k[0].prfcod + k[0].prfbackpic;
               img2.ImageUrl = "~/prfpics/" + k[0].stu_pic;// + k[0].prfcod + k[0].prfpic;

            }
        }
    }
}