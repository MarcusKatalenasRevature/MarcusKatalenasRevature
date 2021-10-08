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
    public class OrderProductRepo : IModelMapper<OrderProduct, ViewModelOrderProduct>, IOrderProductRepo
    {
        private readonly Project_1StoreAppDBContext _context;

        public OrderProductRepo(Project_1StoreAppDBContext context)
        {
            _context = context;
        }
        public ViewModelOrderProduct EFToView(OrderProduct ef)
        {
            ViewModelOrderProduct op1 = new ViewModelOrderProduct(ef.OrderId, ef.ProductId);
            return op1;
        }

        public async Task<OrderProduct> InsertOrderProductAsync(ViewModelOrderProduct vmop)
        {
            OrderProduct op = ViewToEF(vmop);
            int response = await _context.Database.ExecuteSqlRawAsync("Insert into Store.OrderProduct(OrderID, ProductID) values ({0}, {1})", op.OrderId, op.ProductId);
            Console.WriteLine(response);
            if (response != 1) return null;

            ViewModelOrderProduct vmop1 = EFToView(op);

            return op;
        }

        public OrderProduct ViewToEF(ViewModelOrderProduct view)
        {
            OrderProduct op1 = (OrderProduct)_context.OrderProducts.FromSqlRaw<OrderProduct>("Select * from Store.OrderProduct where OrderProductID = {0}", view.OrderProductId).FirstOrDefault();
            return op1;
        }
    }
}
