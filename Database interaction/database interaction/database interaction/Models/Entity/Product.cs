using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace database_interaction.Models.Entity
{
    public class Product
    {
        /* public int Id { get; set; }
         [Required(ErrorMessage = "Please Provide name")]
         [MinLength(2, ErrorMessage = "Name must be > 2 character")]
         [MaxLength(10, ErrorMessage = "Name should not exceed 10 character")]*/
        public int id { get; set; }
        public string name { get; set; }
        [Required]
        public int price { get; set; }
        [Required(ErrorMessage = "Please Provide Price")]
        public int quantity { get; set; }
        [Required]
        public string description { get; set; }
    }
}