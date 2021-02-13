using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace LibraryManagmentAPI.Utilities
{
    public static class Utilities
    {
        public static class Procedures
        {
            public const string ManageUser = "[dbo].[SP_ManageUser]";
            public const string ManageBook = "[dbo].[SP_ManageBook]";
        }
        
        public static class ResponseStatus
        {
            public const string Success = "S";
            public const string Failed = "F";
        } 
        
        public static class ResponseMessages
        {
            public const string Success = "Success";
            public const string Failed = "Failed";
            public const string ServerError = "Somehing went wrong";
            public const string InvalidIdentity = "Id should not be null";
        }
        public static DataSet ExecuteDataset(string CommandText, SqlParameter[] SqlParameters, CommandType Type = CommandType.StoredProcedure)
        {
            try
            {
                string ConnectionString = string.Empty;
                ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString; 

                DataSet ds = new DataSet();

                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(CommandText, con))
                    {
                        /*try
                        {*/
                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        da.SelectCommand.CommandType = Type;
                        da.SelectCommand.CommandTimeout = 0;

                        if (SqlParameters != null)
                        {
                            da.SelectCommand.Parameters.AddRange(SqlParameters);
                        }
                        da.Fill(ds);
                        /*}
                        catch
                        {
                            // ToDo: Error Handling
                            throw;
                        }
                        finally
                        {
                            da.SelectCommand.Parameters.Clear();
                            if (con.State == ConnectionState.Open)
                                con.Close();
                            da.Dispose();
                            con.Dispose();

                        }*/
                    }
                }

                return ds;
            }
            catch (Exception ex)
            {
                StackTrace CallStack = new StackTrace(ex, true);
                ex.Data["ErrDescription"] = ex.Data["ErrDescription"] != null ? ex.Data["ErrDescription"] : string.Format("Error captured in {0} on Line No {1} of Method {2}", CallStack.GetFrame(0).GetFileName(), CallStack.GetFrame(0).GetFileLineNumber(), CallStack.GetFrame(0).GetMethod().ToString());
                throw ex;
            }
        }

    }
}