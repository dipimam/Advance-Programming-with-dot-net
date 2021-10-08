using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using database_interaction.Models.Entity;
using database_interaction.Models.Table;

namespace database_interaction.Models
{
    public class Database
    {
        public Products products { get; set; }
        public orders order { get; set; }

        public Database()
        {
            string connString = @"Server=LAPTOP-6F2DUTV4;Database=database_interaction_db;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            products = new Products(conn);
            order = new orders(conn);
            
        }
    }
}