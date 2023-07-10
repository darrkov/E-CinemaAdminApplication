using System;

namespace E_CinemaAdminApplication.Models
{
    public class ProductInOrder
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
