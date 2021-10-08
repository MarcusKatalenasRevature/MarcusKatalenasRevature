using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.ViewModels
{
   public class ViewModelStore
    {
        public ViewModelStore(string storeName, string storeLocation, int storeId)
        {
            StoreName = storeName;
            StoreLocation = storeLocation;
            StoreId = storeId;
        }

        public int StoreId { get; set; } = -1;
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
      
    }
}
