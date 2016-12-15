﻿using System;
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
/// Summary description for PostThread
/// </summary>

public class PostThread
{
    public static int insertThread(int cforumId, string comment, string posterName, DateTime datetim)
    {
        int rowsAffected = 0;
        using (SqlConnection con = ConnectionManager.GetDatabaseConnection())
        {
            SqlCommand command = new SqlCommand("insertThread", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@forumId", SqlDbType.Int).Value = cforumId;
            command.Parameters.Add("@answer", SqlDbType.VarChar).Value = comment;
            command.Parameters.Add("@posterName", SqlDbType.VarChar).Value = posterName;
            command.Parameters.Add("@datetim", SqlDbType.DateTime).Value = datetim;
            rowsAffected = command.ExecuteNonQuery();

        }
        return rowsAffected;



    }
}