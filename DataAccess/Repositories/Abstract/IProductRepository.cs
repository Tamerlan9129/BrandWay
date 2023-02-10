using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAllWithBrandAsync();
        Task<Product> GetProductDetailsAsync(int id);
        Task<List<Product>> GetProductsBestSellingAsync();
        Task<List<Product>> GetProductsExploreSellingAsync();

        Task<IQueryable<Product>> PaginateProductAsync(IQueryable<Product> products, int page, int take);
        Task<int> GetPageCountAsync(IQueryable<Product> products, int take);
        Task<IQueryable<Product>> FilterByName(string? name);
        Task<IQueryable<Product>> FilterByGender(IQueryable<Product> products, string? gender);
        Task<IQueryable<Product>> FilterByColor(IQueryable<Product> products, int colorId);
        Task<IQueryable<Product>> FilterByBrand(IQueryable<Product> products, int brandId);
        Task<Product> GetUpdateModelAsync(int id);
        Task<List<Product>> ProductsLoadMoreAsync(int skipRow);
        Task<bool> CheckIsLastAsync(int skiprow);
        Task<IQueryable<Product>> FilterByPrice(IQueryable<Product> products, double? minPrice, double? maxPrice);





    }
}
