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
        public void Update(Product p)
        {
            string query = String.Format("UPDATE product SET name='{0}', price={1}, quantity={2}, description='{3}' WHERE id={4}", p.name, p.price, p.quantity, p.description, p.id);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Delete(int id)
        {
            string query = String.Format("DELETE FROM product WHERE id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public Product Get(int id)
        {

            string query = String.Format("select * from product where id={0}",id);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Product p = null;
            while (reader.Read())
            {
                 p = new Product()
                {
                    id = reader.GetInt32(reader.GetOrdinal("id")),
                    name = reader.GetString(reader.GetOrdinal("name")),
                    price = reader.GetInt32(reader.GetOrdinal("price")),
                    quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                    description = reader.GetString(reader.GetOrdinal("description")),
                };
                
            }
            conn.Close();
            return p;
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
                    id = reader.GetInt32(reader.GetOrdinal("id")),
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