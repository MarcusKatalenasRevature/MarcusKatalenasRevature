using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.ViewModels
{
   public class ViewModelProduct
    {
        public ViewModelProduct()
        {
        }

        public ViewModelProduct(int productId, string productDescrip, string productName, decimal price, int storeId)
        {
            ProductId = productId;
            ProductDescription = productDescrip;
            ProductName = productName;
            ProductPrice = price;
            StoreId = storeId;
        }

        public int ProductId { get; set; } = -1;
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int StoreId { get; set; }

    }
}
