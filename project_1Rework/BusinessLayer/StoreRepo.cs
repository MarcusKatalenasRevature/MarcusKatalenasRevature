using BusinessLayer.Interfaces;
using StoreAppApiDbContext.Models;
using ModelsLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    class StoreRepo : IModelMapper<Store, ViewModelStore>
    {
        private readonly Project_1StoreAppDBContext _context;

        public StoreRepo(Project_1StoreAppDBContext context)
        {
            _context = context;
        }
        public ViewModelStore EFToView(Store ef)
        {
            ViewModelStore s1 = new ViewModelStore(ef.StoreName, ef.StoreLocation, ef.StoreId);
            return s1;
        }

        public Store ViewToEF(ViewModelStore view)
        {
            Store s1 = (Store)_context.Stores.FromSqlRaw<Store>("Select * from Store.Store where storeName = {0} AND storeLocation = {1} ", view.StoreName, view.StoreLocation).FirstOrDefault();
            return s1;
        }
    }
}
