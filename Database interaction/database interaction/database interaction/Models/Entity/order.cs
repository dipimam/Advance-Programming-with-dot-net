using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace database_interaction.Models.Entity
{
    public class order
    {
        public int id { get; set; }
        public string name { get; set; }
        
        public int price { get; set; }
        
        public string time { get; set; }
        
        public int p_id { get; set; }
    }
}