using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using URISUserMicroService.Models;
using URISUtil.Dataccess;
namespace URISUserMicroService.DataAccess
{
    public static class UserTypeDB
    {
        private static string AllColumnSelect
        {
            get
            {
                return @"
                    [User].[Id],
	                [User].[Name],
	                [User].[Active]
                ";
            }
        }

        public static UserTypeDB ReadRow(SqlDataReader reader)
        {
            UserType userType = new UserType();
            user.Id = (int)reader["Id"];
        }
            
            public static List<UserType> GettUserTypes()
        {
            try
            {
                List<UserType> retVal = new List<UserType>();
                using (SqlConnection connection = new SqlConnection(DBFunctions.ConnectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = String.Format(@"
                        SELECT
                            {0}
                        FROM
                            [User].[UserType;]
                    ", AllColumnSelect);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add(ReadRow(reader));
                        }
                    }
                
                }return retVal;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

    }
}