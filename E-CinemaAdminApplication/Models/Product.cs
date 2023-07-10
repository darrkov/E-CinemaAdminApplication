using System;
using System.ComponentModel.DataAnnotations;

namespace E_CinemaAdminApplication.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        
        public string ProductImage { get; set; }
        
        public string ProductDescription { get; set; }
        
        public int ProductPrice { get; set; }
        
        public int Rating { get; set; }
       
    }
}
