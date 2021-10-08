using StoreAppApiDbContext.Models;
using System;
using ModelsLayer.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
	
	
	public interface IModelMapper<T, U> where T: class where U: class
	{
		public T ViewToEF(U view);

		public U EFToView(T ef);
	}

	
	


	

}
