using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Default3 : System.Web.UI.Page
{
    String cs;
    protected void Page_Load(object sender, EventArgs e)
    {
        cs = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        if (!Page.IsPostBack)
        {
            Grid_Bind();
        }
    }
    protected void Grid_Bind()
    {
        SqlDataAdapter adp = new SqlDataAdapter("select * from stu_login", cs);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
       

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        Int32 tid = Convert.ToInt32(Session["cod"]);

        //sid = Convert.ToInt32(((Label)(row.Cells[0].FindControl("Label1"))).Text);
        SqlConnection con = new SqlConnection();
        con.ConnectionString = cs;
        con.Open();
        SqlCommand cmd = new SqlCommand("pro_insert_groups", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@p_grp_name", SqlDbType.VarChar,50).Value = TextBox1.Text;
        cmd.Parameters.Add("@p_teach_id", SqlDbType.Int).Value = tid;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        SqlCommand cmd2 = new SqlCommand("pro_sels_groups", con);
        cmd2.CommandType = CommandType.StoredProcedure;
        cmd2.Parameters.Add("@p_grp_name", SqlDbType.VarChar).Value = TextBox1.Text;
        cmd2.Parameters.Add("@p_teach_id", SqlDbType.Int).Value = tid;

        Int32 grp_id = 0;
        SqlDataReader dr = cmd2.ExecuteReader();
        if (dr.HasRows) // as only 1 object to be found
        {
            dr.Read();
            grp_id = Convert.ToInt32(dr[0]);
            

        }
        dr.Close();
        cmd2.Dispose();


        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chkRow = (CheckBox)(row.Cells[4].FindControl("CheckBox1"));
            if (chkRow.Checked == true)
            {
                SqlCommand cmd3 = new SqlCommand("pro_insert_grp_memb", con);
                cmd3.CommandType = CommandType.StoredProcedure;

                cmd3.Parameters.Add("@p_grp_id", SqlDbType.Int).Value = grp_id;
                cmd3.Parameters.Add("@p_stu_id", SqlDbType.Int).Value = Convert.ToInt32(((Label)(row.Cells[0].FindControl("Label1"))).Text);
                cmd3.Parameters.Add("@p_stu_name", SqlDbType.VarChar).Value = (((Label)(row.Cells[1].FindControl("Label2"))).Text);
                cmd3.ExecuteNonQuery();

                cmd3.Dispose();
            }

        }
        Response.Redirect("teach_profile.aspx");

    }


    protected void Button2_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chkselect = (CheckBox)(row.Cells[4].FindControl("CheckBox1"));
            chkselect.Checked = true;
        }
    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chkselect = (CheckBox)(row.Cells[4].FindControl("CheckBox1"));
            chkselect.Checked = false;
        }
    }
}