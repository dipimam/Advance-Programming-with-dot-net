using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using database_interaction.Models.Entity;

namespace database_interaction.Models.Table
{
    public class Products
    {
        SqlConnection conn;
        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Add(Product p)
        {
            string query = String.Format("Insert into product values ('{0}','{1}','{2}','{3}')", p.name, p.price, p.quantity,p.description);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public Product Get(int id)
        {
            return null;
        }
        public List<Product> GetAll()
        {
            string query = "select * from product";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product s = new Product()
                {
                   // id = reader.GetInt32(reader.GetOrdinal("id")),
                    name = reader.GetString(reader.GetOrdinal("name")),
                    price = reader.GetInt32(reader.GetOrdinal("price")),
                    quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                    description = reader.GetString(reader.GetOrdinal("description")),
                };
                products.Add(s);
            }
            conn.Close();
            return products;
        }
    }
}