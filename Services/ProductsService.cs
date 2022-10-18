using System;
using System.Threading.Tasks;
using Interview.Api.Entities;
using Interview.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Interview.Api.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductAsync();
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);

    }
    public class ProductServices : IProductService
    {
        private DataDbContext dbContext;
        public ProductServices(DataDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Product>> GetProductAsync()
        {
            return await dbContext.Product.ToListAsync();
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            try
            {
                dbContext.Product.Add(product);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }
        public async Task<Product> UpdateProductAsync(Product product)
        {
            try
            {
                var productExist = dbContext.Product.FirstOrDefault(p => p.Id == product.Id);
                if (productExist != null)
                {
                    dbContext.Update(product);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }
        public async Task DeleteProductAsync(Product product)
        {
            try
            {
                dbContext.Product.Remove(product);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

