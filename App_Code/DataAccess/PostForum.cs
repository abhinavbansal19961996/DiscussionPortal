using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for PostForum
/// </summary>
public class ConnectionManager
{
    public static SqlConnection GetDatabaseConnection()
    {
        string connectString = "server=priyanshsoni\\sqlexpress17;database=MinHasti;integrated security=true";

        SqlConnection connection = new SqlConnection(connectString);
        connection.Open();
        return connection;
    }
}
public class PostForum
{

    public static int insertForum(int titleId,string question,string posterName,DateTime datetim)
    { 
        int rowsAffected = 0;
        using (SqlConnection con = ConnectionManager.GetDatabaseConnection())
        {
            SqlCommand command = new SqlCommand("insertForum", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@titleId", SqlDbType.Int).Value = titleId;
            command.Parameters.Add("@question", SqlDbType.VarChar).Value = question;
            command.Parameters.Add("@posterName", SqlDbType.VarChar).Value = posterName;
            command.Parameters.Add("@datetim", SqlDbType.DateTime).Value = datetim;
            rowsAffected = command.ExecuteNonQuery();
            
        }
        return rowsAffected;
            

        
    }
}