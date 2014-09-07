using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for UserDetailsDB
/// </summary>
public class UserDetailsDB
{
    private string ConnectionString;
    private SqlConnection DefaultConnection;

	public UserDetailsDB()
	{
        ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        DefaultConnection = new SqlConnection(ConnectionString);
	}

    public DataTable GetUsers()
    {
        SqlCommand GetUsersCommand = new SqlCommand("UserDetails", DefaultConnection);
        GetUsersCommand.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter GetUsersDA = new SqlDataAdapter(GetUsersCommand);
        DataSet GetUsersDS = new DataSet();

        try
        {
            GetUsersDA.Fill(GetUsersDS, "UserData");
            return GetUsersDS.Tables["UserData"];
        }
        catch (Exception)
        {
            throw;
        }
    }
}