using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.ViewModels
{
   public class ViewModelOrderProduct
    {
        public ViewModelOrderProduct(int orderId, int productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }

        public int OrderProductId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
