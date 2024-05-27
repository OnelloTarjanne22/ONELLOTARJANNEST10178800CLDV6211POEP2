using System;
using System.Data;
using System.Data.SqlClient;

namespace ONELLOTARJANNEST10178800CLDV6211POEPART1.Models
{
    public class usersTbl
    {
        public static string con_string = "Server=tcp:cldv6211-server.database.windows.net,1433;Initial Catalog=Clouddev6211;Persist Security Info=False;User ID=Travo;Password=Ocean2525;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public static bool UserExists(string name, string email)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string sql = "SELECT COUNT(*) FROM UsersTbl WHERE userName = @Name AND userEmail = @Email";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);

                        con.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while checking if the user exists.", ex);
            }
        }

        public int insert_User(usersTbl m)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string sql = "INSERT INTO UsersTbl (userName, userEmail, userSurname) VALUES (@Name, @Email, @Surname)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", m.Name);
                        cmd.Parameters.AddWithValue("@Email", m.Email);
                        cmd.Parameters.AddWithValue("@Surname", m.Surname);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while inserting the user.", ex);
            }
        }
    }
}

