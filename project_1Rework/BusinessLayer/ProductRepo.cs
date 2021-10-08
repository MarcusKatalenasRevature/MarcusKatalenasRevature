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
    public class ProductRepo : IModelMapper<Product, ViewModelProduct>, IProductRepo
    {
        private readonly Project_1StoreAppDBContext _context;

        public ProductRepo(Project_1StoreAppDBContext context)
        {
            _context = context;
        }
        public ViewModelProduct EFToView(Product ef)
        {
            ViewModelProduct p1 = new ViewModelProduct(ef.ProductId, ef.ProductDescrip, ef.ProductName, ef.Price, ef.StoreId);
            return p1;
        }
        
        //Param should not be needed here
        public async Task<List<ViewModelProduct>> ProductListAsync(ViewModelProduct vmpP)
        {
            List<Product> products = await _context.Products.FromSqlRaw<Product>("Select * FROM Store.Product").ToListAsync();
            List<ViewModelProduct> vmp = new List<ViewModelProduct>();
            foreach (Product p in products)
            {
                vmp.Add(EFToView(p));
            }
            return vmp;
        }


        public async Task<List<ViewModelProduct>> ProductListByStoreIDAsync(ViewModelProduct vmpP)
        {
            List<Product> products = await _context.Products.FromSqlRaw<Product>("Select * from Store.Product where storeId = {0}", vmpP.StoreId).ToListAsync();
            List<ViewModelProduct> vmp = new List<ViewModelProduct>();
            foreach (Product p in products)
            {
                vmp.Add(EFToView(p));
            }
            return vmp;

            // Product p1 = (Product)await _context.Products.FromSqlRaw<Product>("Select * from Store.Product where storeId = {0}", vmp.StoreId).ToListAsync();
            // return p1;
        }

        public Product ViewToEF(ViewModelProduct view)
        {
            Product p1 = (Product)_context.Products.FromSqlRaw<Product>("Select * from Store.Product ").FirstOrDefault();
            return p1;
        }
    }
}
