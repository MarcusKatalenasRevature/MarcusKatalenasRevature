using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppApiDbContext.Models
{
    public partial class OrderProduct
    {
        public int OrderProductId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public bool? Active { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
