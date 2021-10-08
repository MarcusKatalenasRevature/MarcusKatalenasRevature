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
   public class OrderRepo : IModelMapper<Order, ViewModelOrder>, IOrderRepo
    {
        private readonly Project_1StoreAppDBContext _context;

        public OrderRepo(Project_1StoreAppDBContext context)
        {
            _context = context;
        }
        public ViewModelOrder EFToView(Order ef)
        {
            ViewModelOrder o1 = new ViewModelOrder();
            return o1;
        }

        public async Task<ViewModelOrder> InsertOrderAsync(ViewModelOrder vop)
        {
            Order o = ViewToEF(vop);
            int response = await _context.Database.ExecuteSqlRawAsync("Insert into Store.Orders(CustomerId, StoreID, OrderDate, finalPrice) values ({0}, {1}, GETDATE(), 0.00)", vop.CustomerId, vop.StoreId);

            if (response != 1) return null;

            ViewModelOrder vmo1 = EFToView(o);

            return vmo1;
        }

        public async Task<List<ViewModelOrder>> OrderListAsync()
        {
            List<Order> orders = await _context.Orders.FromSqlRaw<Order>("Select * FROM Store.Orders").ToListAsync();
            List<ViewModelOrder> vmo = new List<ViewModelOrder>();
            foreach (Order o in orders)
            {
                vmo.Add(EFToView(o));
            }
            return vmo;
        }

        public async Task<List<Order>> OrderListByCustomerIDAsync(ViewModelOrder vop)
        {
            List<Order> orders = await _context.Orders.FromSqlRaw<Order>("Select * FROM Store.Orders where CustomerId = {0}", vop.CustomerId).ToListAsync();
            List<ViewModelOrder> vmo = new List<ViewModelOrder>();
            foreach (Order o in orders)
            {
                vmo.Add(EFToView(o));
            }
            return orders;
        }

        public async Task<List<Order>> OrderListByStoreIDAsync(ViewModelOrder vop)
        {
            List<Order> orders = await _context.Orders.FromSqlRaw<Order>("Select * FROM Store.Orders where StoreID = {0}", vop.StoreId).ToListAsync();
            List<ViewModelOrder> vmo = new List<ViewModelOrder>();
            foreach (Order o in orders)
            {
                vmo.Add(EFToView(o));
            }
            return orders;
        }

        public Order ViewToEF(ViewModelOrder view)
        {
            Order o1 = (Order)_context.Orders.FromSqlRaw<Order>("Select * from Store.Orders where OrderID = {0}", view.OrderId).FirstOrDefault();
            return o1;
        }
    }
}

        
    

