using System;
using System.Collections.Generic;

namespace E_CinemaAdminApplication.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public ECinemaApplicationUser User { get; set; }
        public virtual ICollection<ProductInOrder> Products { get; set; }
    }
}
