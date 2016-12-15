using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Main_Class
/// </summary>
namespace MainClass
{   // ABSTRACT CONNECTION CLASS
    public abstract class clscon
    {
        protected SqlConnection con = new SqlConnection();
        // This is the constructor  of class clscon:-
        public clscon()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }
    }
    // CODE FOR STUDENT REGISTER TABLE
    public interface stu_intlog
    {
        Int32 stu_id
        {
            get;
            set;
        }
    
        String stu_pass
        {
            get;
            set;
        }
        String stu_name
        {
            get;
            set;
        }
        String stu_email
        {
            get;
            set;
        }
        String stu_pic
        {
            get;
            set;
        }

        String stu_bio
        {
            get;
            set;
        }
    }

    public class stu_clslogprp : stu_intlog
    {
        private Int32 prvstu_id;
        private String prvstu_pass,prvstu_bio,prvstu_name,prvstu_email,prvstu_pic;
        public int stu_id
        {
            get
            {
                return prvstu_id;
                //throw new NotImplementedException();
            }

            set
            {
                prvstu_id = value;
                //throw new NotImplementedException();
            }
        }

        public string stu_pass
        {
            get
            {
                return prvstu_pass;
                //throw new NotImplementedException();
            }

            set
            {
                prvstu_pass = value;
                //throw new NotImplementedException();
            }
        }
        public string stu_name
        {
            get
            {
                return prvstu_name;
            }
            set
            {
                prvstu_name = value;
            }
        }
        public string stu_email
        {
            get
            {
                return prvstu_email;
            }
            set
            {
                prvstu_email = value;
            }
        }
        public string stu_pic
        {
            get
            {
                return prvstu_pic;
            }
            set
            {
                prvstu_pic = value; 
            }
        }
        public string stu_bio
        {
            get
            {
                return prvstu_bio;
           
            }
            set
            {
                prvstu_bio = value;
            }
        }
    }

    public class stu_clslog : clscon
    {
        public Int32 stu_logincheck(stu_clslogprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("stu_logincheck", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@sid", SqlDbType.VarChar, 50).Value = p.stu_id;
            cmd.Parameters.Add("@stu_pwd", SqlDbType.VarChar, 50).Value = p.stu_pass;
            cmd.Parameters.Add("@rcod", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            Int32 a = Convert.ToInt32(cmd.Parameters["@rcod"].Value);
            cmd.Dispose();
            con.Close();
            return a;
        }
     /*   public void Save_Rec(stu_clslogprp obj)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("reginsuser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@rcod", SqlDbType.Int).Value = obj.regcod;
            cmd.Parameters.Add("@remail", SqlDbType.VarChar, 50).Value = obj.regemail;
            cmd.Parameters.Add("@rpwd", SqlDbType.VarChar, 50).Value = obj.regpwd;
            cmd.Parameters.Add("@rdate", SqlDbType.DateTime).Value = obj.regdate;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        */
        public void Update_Rec(stu_clslogprp obj)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("pro_update_stu_login");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@rcod", SqlDbType.Int).Value = obj.regcod;
            cmd.Parameters.Add("@p_stu_id", SqlDbType.Int).Value = Convert.ToInt32(obj.stu_id);
            cmd.Parameters.Add("@p_stu_pass", SqlDbType.VarChar, 50).Value = obj.stu_pass;
            //cmd.Parameters.Add("@rdate", SqlDbType.DateTime).Value = obj.regdate;
            cmd.Parameters.Add("@p_stu_name", SqlDbType.VarChar, 50).Value = obj.stu_name;
            cmd.Parameters.Add("@p_stu_email", SqlDbType.VarChar, 50).Value = obj.stu_email;
            cmd.Parameters.Add("@p_stu_pic", SqlDbType.VarChar, 50).Value = obj.stu_pic;
            cmd.Parameters.Add("@p_stu_bio", SqlDbType.VarChar, 200).Value = obj.stu_bio;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }

        /*public void Delete_Rec(stu_clslogprp obj)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("regdeluser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@rcod", SqlDbType.Int).Value = obj.regcod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        */
   /*     public List<stu_clslogprp> Display_Rec()
        {  // this is not display stored procedure. please make new display stored procedure.
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("pro_sel_stu_login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            List<stu_clslogprp> obj = new List<stu_clslogprp>();
            while (dr.Read())
            {
                stu_clslogprp k = new stu_clslogprp();
                //k.regcod = Convert.ToInt32(dr["regcod"]);
                k.stu_id = Convert.ToInt32(dr["stu_id"]);
                k.stu_pass = dr["regpwd"].ToString();
                //k.regdate = Convert.ToDateTime(dr["regdate"]);
                obj.Add(k);

            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
        */
        public List<stu_clslogprp> Find_Rec(Int32 sid)
        {// Sel here is find
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("pro_sel_stu_login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@p_stu_id", SqlDbType.Int).Value = sid;
            SqlDataReader dr = cmd.ExecuteReader();
            List<stu_clslogprp> obj = new List<stu_clslogprp>();
            if (dr.HasRows) // as only 1 object to be found
            {
                dr.Read();
                stu_clslogprp k = new stu_clslogprp();
                k.stu_id= Convert.ToInt32(dr[0]);
                //k.regemail = Convert.ToString(dr[1]);
                k.stu_pass= dr[1].ToString();
                k.stu_bio = dr["stu_bio"].ToString();
                k.stu_name = dr["stu_name"].ToString();
                k.stu_pic = dr["stu_pic"].ToString();
                k.stu_email = dr["stu_email"].ToString();
                //k.regdate = Convert.ToDateTime(dr[3]);
                obj.Add(k);
            }

            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }

    }


    // CODE FOR TEACHER REGISTER TABLE
    public interface teach_intlog
    {
        Int32 teach_Id
        {
            get;
            set;
        }

        String teach_pass
        {
            get;
            set;
        }

        String teach_name
        {
            get;
            set;
        }
        String teach_email
        {
            get;
            set;
        }
        String teach_pic
        {
            get;
            set;
        }
        String teach_bio
        {
            get;
            set;
        }
    }

    public class teach_clslogprp : teach_intlog
    {
        private Int32 prvteach_id;
        private String prvteach_pass,prvteach_name, prvteach_email, prvteach_pic, prvteach_bio;
        public int teach_Id
        {
            get
            {
                return prvteach_id;
                //throw new NotImplementedException();
            }

            set
            {
                prvteach_id = value;
                //throw new NotImplementedException();
            }
        }

        public string teach_pass
        {
            get
            {
                return prvteach_pass;
                //throw new NotImplementedException();
            }

            set
            {
                prvteach_pass = value;
                //throw new NotImplementedException();
            }
        }
        public string teach_name
        {
            get
            {
                return prvteach_name;
            }
            set
            {
                prvteach_name = value;
            }
        }
        public string teach_email
        {
            get
            {
                return prvteach_email;
            }
            set
            {
                prvteach_email = value;
            }
        }
        public string teach_pic
        {
            get
            {
                return prvteach_pic;
            }
            set
            {
                prvteach_pic = value;
            }
        }
        public string teach_bio
        {
            get
            {
                return prvteach_bio;
            }
            set
            {
                prvteach_bio = value;
            }
        }
    }

    public class teach_clslog : clscon
    {
        public Int32 teach_logincheck(teach_clslogprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("teach_logincheck", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tid", SqlDbType.VarChar, 50).Value = p.teach_Id;
            cmd.Parameters.Add("@teach_pwd", SqlDbType.VarChar, 50).Value = p.teach_pass;
            cmd.Parameters.Add("@rcod", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            Int32 a = Convert.ToInt32(cmd.Parameters["@rcod"].Value);
            cmd.Dispose();
            con.Close();
            return a;
        }
        /*   public void Save_Rec(stu_clslogprp obj)
           {
               if (con.State == ConnectionState.Closed)
               {
                   con.Open();
               }
               SqlCommand cmd = new SqlCommand("reginsuser", con);
               cmd.CommandType = CommandType.StoredProcedure;
               //cmd.Parameters.Add("@rcod", SqlDbType.Int).Value = obj.regcod;
               cmd.Parameters.Add("@remail", SqlDbType.VarChar, 50).Value = obj.regemail;
               cmd.Parameters.Add("@rpwd", SqlDbType.VarChar, 50).Value = obj.regpwd;
               cmd.Parameters.Add("@rdate", SqlDbType.DateTime).Value = obj.regdate;
               cmd.ExecuteNonQuery();
               cmd.Dispose();
               con.Close();
           }
           */
        public void Update_Rec(teach_clslogprp obj)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("pro_update_teach_login");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@rcod", SqlDbType.Int).Value = obj.regcod;
            cmd.Parameters.Add("@p_teach_id", SqlDbType.Int).Value = Convert.ToInt32(obj.teach_Id);
            cmd.Parameters.Add("@p_teach_pass", SqlDbType.VarChar, 50).Value = obj.teach_pass;
            cmd.Parameters.Add("@p_teach_name", SqlDbType.VarChar, 50).Value = obj.teach_name;
            cmd.Parameters.Add("@p_teach_email", SqlDbType.VarChar, 50).Value = obj.teach_email;
            cmd.Parameters.Add("@p_teach_pic", SqlDbType.VarChar, 50).Value = obj.teach_pic;
            cmd.Parameters.Add("@p_teach_bio", SqlDbType.VarChar, 200).Value = obj.teach_bio;
            //cmd.Parameters.Add("@rdate", SqlDbType.DateTime).Value = obj.regdate;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }

        /*public void Delete_Rec(stu_clslogprp obj)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("regdeluser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@rcod", SqlDbType.Int).Value = obj.regcod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        */
        /*     public List<stu_clslogprp> Display_Rec()
             {  // this is not display stored procedure. please make new display stored procedure.
                 if (con.State == ConnectionState.Closed)
                 {
                     con.Open();
                 }
                 SqlCommand cmd = new SqlCommand("pro_sel_stu_login", con);
                 cmd.CommandType = CommandType.StoredProcedure;
                 SqlDataReader dr = cmd.ExecuteReader();
                 List<stu_clslogprp> obj = new List<stu_clslogprp>();
                 while (dr.Read())
                 {
                     stu_clslogprp k = new stu_clslogprp();
                     //k.regcod = Convert.ToInt32(dr["regcod"]);
                     k.stu_id = Convert.ToInt32(dr["stu_id"]);
                     k.stu_pass = dr["regpwd"].ToString();
                     //k.regdate = Convert.ToDateTime(dr["regdate"]);
                     obj.Add(k);

                 }
                 dr.Close();
                 cmd.Dispose();
                 con.Close();
                 return obj;
             }
             */
        public List<teach_clslogprp> Find_Rec(Int32 tid)
        {// Sel here is find
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("pro_sel_teach_login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@p_teach_id", SqlDbType.Int).Value = tid;
            SqlDataReader dr = cmd.ExecuteReader();
            List<teach_clslogprp> obj = new List<teach_clslogprp>();
            if (dr.HasRows) // as only 1 object to be found
            {
                dr.Read();
                teach_clslogprp k = new teach_clslogprp();
                k.teach_Id = Convert.ToInt32(dr[0]);
                //k.regemail = Convert.ToString(dr[1]);
                k.teach_pass = dr[1].ToString();
                k.teach_name = dr[2].ToString();
                k.teach_email = dr[3].ToString();
                k.teach_pic = dr[4].ToString();
                k.teach_bio = dr[5].ToString();
                //k.regdate = Convert.ToDateTime(dr[3]);
                obj.Add(k);
            }

            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }

    }








    /*  
    // CODE FOR FAVOURITE TABLE
    public interface intfav
    {
        Int32 favcod
        {
            get;
            set;
        }
        Int32 favprfcod
        {
            get;
            set;
        }
        Int32 favfavprfcod
        {
            get;
            set;
        }
    }

    public class clsfavprp : intfav
    {
        private Int32 prvfavcod, prvfavprfcod, prvfavfavprfcod;
        public int favcod
        {
            get
            {
                return prvfavcod;
            }

            set
            {
                prvfavcod = value;
            }
        }

        public int favfavprfcod
        {
            get
            {
                return prvfavfavprfcod;
            }

            set
            {
                prvfavfavprfcod = value;
            }
        }

        public int favprfcod
        {
            get
            {
                return prvfavprfcod;
            }

            set
            {
                prvfavprfcod = value;
            }
        }
    }

    public class clsfav : clscon
    {
        public DataSet addfavprf(Int32 regcod)
        {
            SqlDataAdapter adp = new SqlDataAdapter("favprf", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@regcod", SqlDbType.Int).Value = regcod;
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;

        }
        public void Save_Rec(clsfavprp obj)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("favinsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@fcod", SqlDbType.Int).Value = obj.favcod;
            cmd.Parameters.Add("@fpcod", SqlDbType.Int).Value = obj.favprfcod;
            cmd.Parameters.Add("@ffpcod", SqlDbType.Int).Value = obj.favfavprfcod;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void Update_Rec(clsfavprp obj)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("favupdate");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fcod", SqlDbType.Int).Value = obj.favcod;
            cmd.Parameters.Add("@fpcod", SqlDbType.Int).Value = obj.favprfcod;
            cmd.Parameters.Add("@ffpcod", SqlDbType.Int).Value = obj.favfavprfcod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }

        public void Delete_Rec(clsfavprp obj)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("favdelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fcod", SqlDbType.Int).Value = obj.favcod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public List<clsfavprp> Display_Rec()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("favdisplay", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsfavprp> obj = new List<clsfavprp>();
            while (dr.Read())
            {
                clsfavprp k = new clsfavprp();
                k.favcod = Convert.ToInt32(dr["favcod"]);
                k.favprfcod = Convert.ToInt32(dr["favprfcod"]);
                k.favfavprfcod = Convert.ToInt32(dr["favfavprfcod"]);
                obj.Add(k);

            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }

        public List<clsfavprp> Find_Rec(Int32 fcode)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("favfind", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fcod", SqlDbType.Int).Value = fcode;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsfavprp> obj = new List<clsfavprp>();
            if (dr.HasRows) // as only 1 object to be found
            {
                dr.Read();
                clsfavprp k = new clsfavprp();
                k.favcod = Convert.ToInt32(dr[0]);
                k.favprfcod = Convert.ToInt32(dr[1]);
                k.favfavprfcod = Convert.ToInt32(dr[2]);
                obj.Add(k);
            }

            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
    }

    // CODE FOR PROFILE LINK TABLE

    public interface intprflink
    {
        Int32 prflinkcod
        {
            get;
            set;
        }
        Int32 prflinkprfcod
        {
            get;
            set;
        }

        String prflinksite
        {
            get;
            set;
        }
        String prflinkurl
        {

            get;
            set;
        }

    }

    public class clsprflinkprp : intprflink
    {
        private Int32 prvprflinkcod, prvprflinkprfcod;
        String prvprflinksite, prvprflinkurl;
        public int prflinkcod
        {
            get
            {
                return prvprflinkcod;
            }

            set
            {
                prvprflinkcod = value;
            }
        }

        public int prflinkprfcod
        {
            get
            {
                return prvprflinkprfcod;
            }

            set
            {
                prvprflinkprfcod = value;
            }
        }

        public string prflinksite
        {
            get
            {
                return prvprflinksite;
            }

            set
            {
                prvprflinksite = value;
            }
        }

        public string prflinkurl
        {
            get
            {
                return prvprflinkurl;
            }

            set
            {
                prvprflinkurl = value;
            }
        }
    }

    public class clsprflink : clscon
    {
        public void Save_Rec(clsprflinkprp obj)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("linkprofinsert");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@plcod", SqlDbType.Int).Value = obj.prflinkcod;
            cmd.Parameters.Add("@plprofcod", SqlDbType.Int).Value = obj.prflinkprfcod;
            cmd.Parameters.Add("@plsite", SqlDbType.VarChar, 100).Value = obj.prflinksite;
            cmd.Parameters.Add("@plurl", SqlDbType.VarChar, 100).Value = obj.prflinkurl;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void Update_Rec(clsprflinkprp obj)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("linkprofupdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@plcod", SqlDbType.Int).Value = obj.prflinkcod;
            cmd.Parameters.Add("@plprofcod", SqlDbType.Int).Value = obj.prflinkprfcod;
            cmd.Parameters.Add("@plsite", SqlDbType.VarChar, 100).Value = obj.prflinksite;
            cmd.Parameters.Add("@plurl", SqlDbType.VarChar, 100).Value = obj.prflinkurl;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }

        public void Delete_Rec(clsprflinkprp obj)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("linkprofdelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@plcod", SqlDbType.Int).Value = obj.prflinkcod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public List<clsprflinkprp> Display_Rec(Int32 prfcod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("linkprofdisplay", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prfcod", SqlDbType.Int).Value = prfcod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsprflinkprp> obj = new List<clsprflinkprp>();
            while (dr.Read())
            {
                clsprflinkprp k = new clsprflinkprp();
                k.prflinkcod = Convert.ToInt32(dr["prflinkcod"]);
                k.prflinkprfcod = Convert.ToInt32(dr["prflinkprfcod"]);
                k.prflinksite = (dr["prflinksite"]).ToString();
                k.prflinkurl = (dr["prflinkurl"]).ToString();
                obj.Add(k);

            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }

        public List<clsprflinkprp> Find_Rec(Int32 plcode)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("linkproffind");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@plcod", SqlDbType.Int).Value = plcode;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsprflinkprp> obj = new List<clsprflinkprp>();
            if (dr.HasRows)
            {
                dr.Read();
                clsprflinkprp k = new clsprflinkprp();
                k.prflinkcod = Convert.ToInt32(dr[0]);
                k.prflinkprfcod = Convert.ToInt32(dr[1]);
                k.prflinksite = dr[2].ToString();
                k.prflinkurl = dr[3].ToString();
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }

    }

    // CODE FOR PROFILE TABLE
    public interface intprf
    {
        Int32 prfcod
        {
            get;
            set;
        }
        Int32 prfregcod
        {
            get;
            set;
        }
        String prffirstname
        {
            get;
            set;
        }
        String prflastname
        {
            get;
            set;
        }
        String prfheadline
        {
            get;
            set;
        }
        String prfbio
        {
            get;
            set;
        }
        String prfpic
        {
            get;
            set;
        }
        String prfbackpic
        {
            get;
            set;
        }
        Char prfprvstatus
        {
            get;
            set;
        }

    }

    public class clsprfprp : intprf
    {
        private Int32 prvprfcod, prvprfregcod;
        String prvprffirstname, prvprflastname, prvprfheadline, prvprfbio, prvprfpic, prvprfbackpic;
        Char prvprfprvstatus;
        public string prfbackpic
        {
            get
            {
                return prvprfbackpic;
            }

            set
            {
                prvprfbackpic = value;
                //throw new NotImplementedException();
            }
        }

        public string prfbio
        {
            get
            {
                return prvprfbio;
                //throw new NotImplementedException();
            }

            set
            {
                prvprfbio = value;
            }
        }

        public int prfcod
        {
            get
            {
                return prvprfcod;
            }

            set
            {
                prvprfcod = value;
            }
        }

        public string prffirstname
        {
            get
            {
                return prvprffirstname;
            }

            set
            {
                prvprffirstname = value;
                // throw new NotImplementedException();
            }
        }

        public string prfheadline
        {
            get
            {
                return prvprfheadline;
                //throw new NotImplementedException();
            }

            set
            {
                prvprfheadline = value;
            }
        }

        public string prflastname
        {
            get
            {
                return prvprflastname;
            }

            set
            {
                prvprflastname = value;
                // throw new NotImplementedException();
            }
        }

        public string prfpic
        {
            get
            {
                return prvprfpic;
            }

            set
            {
                prvprfpic = value;
            }
        }

        public char prfprvstatus
        {
            get
            {
                return prvprfprvstatus;//throw new NotImplementedException();
            }

            set
            {
                prvprfprvstatus = value;// throw new NotImplementedException();
            }
        }

        public int prfregcod
        {
            get
            {
                return prvprfregcod;
            }

            set
            {
                prvprfregcod = value;
            }
        }
    }

    public class clsprf : clscon
    {
        public Int32 Save_Rec(clsprfprp obj)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("profinsert");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            // cmd.Parameters.Add("@plcod", SqlDbType.Int).Value = obj.;
            cmd.Parameters.Add("@prcod", SqlDbType.Int).Value = obj.prfregcod;
            cmd.Parameters.Add("@pfname", SqlDbType.VarChar, 100).Value = obj.prffirstname;
            cmd.Parameters.Add("@plname", SqlDbType.VarChar, 100).Value = obj.prflastname;
            cmd.Parameters.Add("@pheadline", SqlDbType.VarChar, 100).Value = obj.prfheadline;
            cmd.Parameters.Add("@pbio", SqlDbType.VarChar, 1000).Value = obj.prfbio;
            cmd.Parameters.Add("@ppic", SqlDbType.VarChar, 50).Value = obj.prfpic;
            cmd.Parameters.Add("@pbackpic", SqlDbType.VarChar, 50).Value = obj.prfbackpic;
            cmd.Parameters.Add("@pstatus", SqlDbType.Char).Value = obj.prfprvstatus;
            cmd.ExecuteNonQuery();
            Int32 a = Convert.ToInt32(cmd.Parameters["@ret"].Value);
            cmd.Dispose();
            con.Close();
            return a;

        }

        public void Update_Rec(clsprfprp obj)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("profupdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pcod", SqlDbType.Int).Value = obj.prfcod;
            cmd.Parameters.Add("@prcod", SqlDbType.Int).Value = obj.prfregcod;
            cmd.Parameters.Add("@pfname", SqlDbType.VarChar, 100).Value = obj.prffirstname;
            cmd.Parameters.Add("@plname", SqlDbType.VarChar, 100).Value = obj.prflastname;
            cmd.Parameters.Add("@pheadline", SqlDbType.VarChar, 100).Value = obj.prfheadline;
            cmd.Parameters.Add("@pbio", SqlDbType.VarChar, 1000).Value = obj.prfbio;
            cmd.Parameters.Add("@ppic", SqlDbType.VarChar, 50).Value = obj.prfpic;
            cmd.Parameters.Add("@pbackpic", SqlDbType.VarChar, 50).Value = obj.prfbackpic;
            cmd.Parameters.Add("@pstatus", SqlDbType.Char).Value = obj.prfprvstatus;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }

        public void Delete_Rec(clsprfprp obj)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("profdelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pcod", SqlDbType.Int).Value = obj.prfcod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public List<clsprfprp> Display_Rec()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("profdisplay", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsprfprp> obj = new List<clsprfprp>();
            while (dr.Read())
            {
                clsprfprp k = new clsprfprp();
                k.prfcod = Convert.ToInt32(dr[0]);
                k.prfregcod = Convert.ToInt32(dr[1]);
                k.prffirstname = (dr[2]).ToString();
                k.prflastname = (dr[3]).ToString();
                k.prfheadline = dr[4].ToString();
                k.prfbio = dr[5].ToString();
                k.prfpic = dr[6].ToString();
                k.prfbackpic = dr[7].ToString();
                k.prfprvstatus = Convert.ToChar(dr[8]);
                obj.Add(k);

            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }

        public List<clsprfprp> Find_Rec(Int32 pcode)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("proffind");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pcod", SqlDbType.Int).Value = pcode;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsprfprp> obj = new List<clsprfprp>();
            if (dr.HasRows)
            {
                dr.Read();
                clsprfprp k = new clsprfprp();
                k.prfcod = Convert.ToInt32(dr[0]);
                k.prfregcod = Convert.ToInt32(dr[1]);
                k.prffirstname = (dr[2]).ToString();
                k.prflastname = (dr[3]).ToString();
                k.prfheadline = dr[4].ToString();
                k.prfbio = dr[5].ToString();
                k.prfpic = dr[6].ToString();
                k.prfbackpic = dr[7].ToString();
                k.prfprvstatus = Convert.ToChar(dr[8]);
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }

        public List<clsprfprp> Search_Rec(String srcstr, Int32 cod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("srcprf", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@srcstr", SqlDbType.VarChar, 100).Value = srcstr;
            cmd.Parameters.Add("@cod", SqlDbType.Int).Value = cod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsprfprp> obj = new List<clsprfprp>();
            while (dr.Read())
            {
                clsprfprp k = new clsprfprp();
                k.prfcod = Convert.ToInt32(dr[0]);
                k.prfregcod = Convert.ToInt32(dr[1]);
                k.prffirstname = (dr[2]).ToString();
                k.prflastname = (dr[3]).ToString();
                // k.prfheadline = dr[4].ToString();
                k.prfbio = dr[5].ToString();
                k.prfpic = dr[4].ToString();
                //k.prfbackpic = dr[7].ToString();
                //k.prfprvstatus = Convert.ToChar(dr[8]);
                obj.Add(k);

            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;

        }

    }
*/
}