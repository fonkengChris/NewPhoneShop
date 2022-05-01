using NewPhoneShop2.Models;
using NewPhoneShop2.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace NewPhoneShop2.Data.Services
{
    public interface IProductsService : IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task AddNewProductAsync(NewProductVM product);
        Task UpdateProductAsync(NewProductVM product);
    }
}
