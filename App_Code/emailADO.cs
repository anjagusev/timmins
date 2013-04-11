using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;


public class emailADO
{
	private static readonly string _connstring;
    static emailADO()
	    {
            _connstring = WebConfigurationManager.ConnectionStrings["timminsConnectionString"].ConnectionString;
	
	    }
	public List<string> getemails()
	{
        // Ado query is used to get list of email which are valid 
		List<string> allemails = new List<string>();
		SqlConnection conn = new SqlConnection(_connstring);
        SqlCommand cmd = new SqlCommand("SELECT email FROM tbl_subscribers WHERE valid ='yes'", conn);
		using (conn)
		{
			conn.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			while(dr.Read())
			{
			allemails.Add(dr["email"].ToString());
          //  allemails.Add(dr["subscribe_id"].ToString());
			}

		}
		return allemails;
	}

    public List<string> getIDOFemails()
    {

        List<string> allemailID = new List<string>();
        SqlConnection conn = new SqlConnection(_connstring);
        SqlCommand cmd = new SqlCommand("SELECT subscribe_id, FROM tbl_subscribe WHERE valid ='yes'", conn);
        using (conn)
        {
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                allemailID.Add(dr["subscribe_id"].ToString());
            }

        }
        return allemailID;
    }
}