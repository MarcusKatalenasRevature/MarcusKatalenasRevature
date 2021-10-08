using ModelsLayer.ViewModels;
using StoreAppApiDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
	
	public interface ICustomerRepo
	{
		Task<Customer> LoginCustomerAsync(ViewModelCustomer vmc);
		Task<Customer> RegisterCustomerAsync(ViewModelCustomer vmc);
		Task<List<ViewModelCustomer>> CustomerListAsync();

	}
	

	
	

}
  
