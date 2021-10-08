using ModelsLayer.ViewModels;
using StoreAppApiDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
	public interface IOrderProductRepo
	{
		Task<OrderProduct> InsertOrderProductAsync(ViewModelOrderProduct vmop);
	
	}
}
