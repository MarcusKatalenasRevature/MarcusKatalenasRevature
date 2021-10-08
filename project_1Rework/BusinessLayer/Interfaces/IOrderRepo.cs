using ModelsLayer.ViewModels;
using StoreAppApiDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IOrderRepo
    {
        
        Task<List<ViewModelOrder>> OrderListAsync();

        Task<ViewModelOrder> InsertOrderAsync(ViewModelOrder vop);
        Task<List<Order>> OrderListByStoreIDAsync(ViewModelOrder vop);
        Task<List<Order>> OrderListByCustomerIDAsync(ViewModelOrder vop);


    }
}
