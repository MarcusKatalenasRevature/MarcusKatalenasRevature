using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.ViewModels;
using StoreAppApiDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class StoreInventoryRepo : IModelMapper<StoreInventory, ViewModelStoreInventory>
    {
        private readonly Project_1StoreAppDBContext _context;

        public StoreInventoryRepo(Project_1StoreAppDBContext context)
        {
            _context = context;
        }
        public ViewModelStoreInventory EFToView(StoreInventory ef)
        {
            ViewModelStoreInventory si1 = new ViewModelStoreInventory(ef.StoreId, ef.ProductId, ef.ProductRemaining);
            return si1;
        }

        public StoreInventory ViewToEF(ViewModelStoreInventory view)
        {
            StoreInventory si1 = (StoreInventory)_context.StoreInventories.FromSqlRaw<StoreInventory>("Select * from Store.StoreInventory where StoreID = {0}", view.StoreId).FirstOrDefault();
            return si1;
        }
    }
}
