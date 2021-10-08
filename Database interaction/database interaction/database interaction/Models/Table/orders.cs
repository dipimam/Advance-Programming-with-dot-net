using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using database_interaction.Models.Entity;


namespace database_interaction.Models.Table
{
    public class orders
    {
        SqlConnection conn;
        public orders(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Add(order o)
        {

            string query = String.Format("Insert into orders values ('{0}','{1}','{2}','{3}')", o.name, o.price, o.time, o.p_id);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}