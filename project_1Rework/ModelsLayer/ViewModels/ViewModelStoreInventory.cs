using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.ViewModels
{
  public class ViewModelStoreInventory
    {
        public ViewModelStoreInventory(int storeId, int productId, byte productRemaining)
        {
            StoreId = storeId;
            ProductId = productId;
            ProductRemaining = productRemaining;
        }

        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public byte ProductRemaining { get; set; }

    }
}
