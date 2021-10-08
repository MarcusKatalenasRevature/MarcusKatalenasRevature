using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.ViewModels
{
   public class ViewModelOrder
    {
        public ViewModelOrder()
        {
        }

        public ViewModelOrder(int orderId, int storeId, int customerId, DateTime orderDate, decimal finalPrice)
        {
            OrderId = orderId;
            StoreId = storeId;
            CustomerId = customerId;
            OrderDate = orderDate;
            FinalPrice = finalPrice;
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
