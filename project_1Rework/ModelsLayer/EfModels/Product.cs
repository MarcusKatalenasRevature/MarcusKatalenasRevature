using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppApiDbContext.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
            StoreInventories = new HashSet<StoreInventory>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescrip { get; set; }
        public int StoreId { get; set; }
        public decimal Price { get; set; }
        public bool? Active { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
    }
}
