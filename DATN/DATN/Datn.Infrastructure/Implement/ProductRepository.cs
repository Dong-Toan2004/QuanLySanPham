using Datn.Application.DataTransferObj;
using Datn.Application.Interface;
using Datn.Domain.Database.Entities;
using Datn.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datn.Infrastructure.Implement
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContexts contexts;

        public ProductRepository(AppDbContexts contexts)
        {
            this.contexts = contexts;
        }

        public async Task<Product> Create(Product product)
        {
            await contexts.AddAsync(product);
            await contexts.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Detete(Guid id)
        {
            var product = await contexts.Products.FindAsync(id);
            contexts.Products.Remove(product);
            await contexts.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var product = await contexts.Products.Include(x => x.Category).Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image,
                Price = x.Price,
                Quantity = x.Quantity,
                CategoryName = x.Category.Name
            }).ToListAsync();
            return product;
        }

        public async Task<Product> GetById(Guid id)
        {
            var product = await contexts.Products.FindAsync(id);
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            contexts.Products.Update(product);
            await contexts.SaveChangesAsync();
            return product;
        }
    }
}
