using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
    public interface IProductSizeRepository : IRepository<ProductSize>
    {
        Task<List<ProductSize>> GetProductSizesDetailsAsync(int productId);
    }
}
