using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.ViewModels;
using StoreAppApiDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{


    public class CustomerRepo : IModelMapper<Customer, ViewModelCustomer> , ICustomerRepo
    {
        private readonly Project_1StoreAppDBContext _context;

        public CustomerRepo(Project_1StoreAppDBContext context)
        {
            _context = context;
        }
        public ViewModelCustomer EFToView(Customer ef)
        {

            ViewModelCustomer c1 = new ViewModelCustomer(ef.Fname, ef.Lname);
            return c1;
        }

        public Customer ViewToEF(ViewModelCustomer view)
        {

            Customer c1 = (Customer)_context.Customers.FromSqlRaw<Customer>("Select * From Customer.Customer where FName = {0} AND LName = {1}", view.Fname, view.Lname).FirstOrDefault();
            return c1;
        }

        public async Task<Customer> LoginCustomerAsync(ViewModelCustomer vmc)
        {
            
            Customer c1 = await _context.Customers.FromSqlRaw<Customer>("Select * From Customer.Customer where FName = {0} AND LName = {1}", vmc.Fname, vmc.Lname).FirstOrDefaultAsync();
            if (c1 == null)
            {
                return null;
            }

            ViewModelCustomer vmc1 = EFToView(c1);

            return c1;
        }

        public async Task<Customer> RegisterCustomerAsync(ViewModelCustomer vmc)
        {
            Customer c = ViewToEF(vmc);
            int response = await _context.Database.ExecuteSqlRawAsync("INSERT into Customer.Customer(FName, LName) values ({0}, {1})", c.Fname, c.Lname);

            if (response != 1) return null;

            return await LoginCustomerAsync(vmc);

        }

        public async Task<List<ViewModelCustomer>> CustomerListAsync()
        {
            List<Customer> customers = await _context.Customers.FromSqlRaw<Customer>("Select * FROM Customers").ToListAsync();
            List<ViewModelCustomer> vmc = new List<ViewModelCustomer>();
            foreach (Customer c in customers)
            {
                vmc.Add(EFToView(c));
            }
            return vmc;
        }
    }
}
