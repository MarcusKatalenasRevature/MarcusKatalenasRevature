using ModelsLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
  public interface IProductRepo
    {
       
        Task<List<ViewModelProduct>> ProductListAsync(ViewModelProduct vmp);

        Task<List<ViewModelProduct>> ProductListByStoreIDAsync(ViewModelProduct vmp);
    }
}
