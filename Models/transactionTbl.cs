using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ONELLOTARJANNEST10178800CLDV6211POEPART1.Models
{
    public class transactionTbl
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }

        private static string con_string = productTbl.con_string;

        public static int InsertTransaction(int userID, int productID, string productName, string price)
        {
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "INSERT INTO transactionTbl (UserID, ProductID, Product_Name, Price) VALUES (@UserID, @ProductID, @ProductName, @Price)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    cmd.Parameters.AddWithValue("@Price", price);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    return rowsAffected;
                }
            }
        }
        public static List<transactionTbl> GetTransactionsByUserId(int userID)
        {
            List<transactionTbl> transactions = new List<transactionTbl>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM transactionTbl WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        transactionTbl transaction = new transactionTbl
                        {
                            TransactionID = Convert.ToInt32(reader["TransactionID"]),
                            UserID = Convert.ToInt32(reader["UserID"]),
                            ProductID = Convert.ToInt32(reader["ProductID"]),
                            ProductName = reader["Product_Name"].ToString(),
                            Price = reader["Price"].ToString()
                        };
                        transactions.Add(transaction);
                    }
                    con.Close();
                }
            }
            return transactions;
        }


    }
}

