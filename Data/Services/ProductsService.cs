using Microsoft.EntityFrameworkCore;
using NewPhoneShop2.Models;
using NewPhoneShop2.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPhoneShop2.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context): base(context) 
        {
            _context = context;
        }

        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Category = data.Category,
                BrandName = data.BrandName,
                Properties = data.Properties,
                ProfilePictureURL = data.ProfilePictureURL,
                Price = data.Price
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbProduct != null)
            {
                dbProduct.Name = data.Name;
                dbProduct.Category = data.Category;
                dbProduct.BrandName = data.BrandName;
                dbProduct.Properties = data.Properties;
                dbProduct.ProfilePictureURL = data.ProfilePictureURL;
                dbProduct.Price = data.Price;

                await _context.SaveChangesAsync();
            }
            
          
               

        }
    }
}
