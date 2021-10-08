using ModelsLayer.ViewModels;
using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppApiDbContext.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
