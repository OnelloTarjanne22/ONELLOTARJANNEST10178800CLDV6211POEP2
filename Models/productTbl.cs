using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ONELLOTARJANNEST10178800CLDV6211POEPART1.Models
{
    public class productTbl
    {
        public static string con_string = "Server=tcp:cldv6211-server.database.windows.net,1433;Initial Catalog=Clouddev6211;Persist Security Info=False;User ID=Travo;Password=Ocean2525;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(con_string);

        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Availability { get; set; }

        public int insert_product(productTbl p)
        {
            try
            {
                string sql = "INSERT INTO productTbl (Product_Name, Price, Category, Availability) VALUES (@Name, @Price, @Category, @Availability)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<productTbl> GetAllProducts()
        {
            List<productTbl> products = new List<productTbl>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM productTbl";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    productTbl product = new productTbl
                    {
                        ProductID = Convert.ToInt32(rdr["ProductID"]),
                        Name = rdr["Product_Name"].ToString(),
                        Price = rdr["Price"].ToString(),
                        Category = rdr["Category"].ToString(),
                        Availability = rdr["Availability"].ToString()
                    };

                    products.Add(product);
                }
            }

            return products;
        }
    }
}
