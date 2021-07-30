using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AccountingNote.DBSource
{
    public class UserInfoManager
    {
        public static string GetConnectionString()
        {
            string val = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            return val;
        }
        public static DataRow GetUserInfoByAccount(string account)
        {
            string cs = GetConnectionString();
            string dbcs = @"SELECT ID, Name, PWD, Account, Email
                                FROM UserInfo
                                WHERE [Account] = @account;
                           ";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(dbcs, connection))
                {
                    command.Parameters.AddWithValue("@account", account);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        reader.Close();

                        if (dt.Rows.Count == 0) 
                            return null;

                        DataRow dr = dt.Rows[0];
                        return dr;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return null;
                    }
                }
            }
        }
    }
    
}
