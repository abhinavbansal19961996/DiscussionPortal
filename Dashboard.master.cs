﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cod"] == null)
            Response.Redirect("~/stulogin.aspx");
    }


    protected void lk1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/stulogin.aspx");
    }
}