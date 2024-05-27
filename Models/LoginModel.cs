using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ONELLOTARJANNEST10178800CLDV6211POEPART1.Models
{
    public class LoginModel 
    {
        //public static string con_string = "Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=test;Data Source=labVMH8OX\\SQLEXPRESS";
        public static string con_string = "Server=tcp:cldv6211-server.database.windows.net,1433;Initial Catalog=Clouddev6211;Persist Security Info=False;User ID=Travo;Password=Ocean2525;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";


        public int SelectUser(string email, string name)
        {
            int userId = -1;
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM usersTbl WHERE userEmail = @Email AND userName = @Name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Name", name);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    // For now, rethrow the exception
                    throw;
                }
            }
            return userId;
        }
    }
}
