using EducationPractice.Data;
using EducationPractice.models;
using EducationPractice.dtos;
using Microsoft.EntityFrameworkCore;
using EducationPractice.mappers;
using EducationPractice.Repositories.Interfaces;

namespace EducationPractice.Repositories
{
    public class ProductRepositoryRealization : IEducationPractice
    {
        private readonly ApplicationDbContext _context;
        public ProductRepositoryRealization(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync() => await _context.Products.ToListAsync();

        public async Task<Product?> GetByIdAsync(string id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            return product == null ? null : product;
        }

        public async Task<Product?> CreateAsync(ProductCreate productCreate)
        {
            Product product = productCreate.ToProductCreate();
            try
            {
                await _context.AddAsync(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Product?> UpdateAsync(string id, ProductUpdate productUpdate)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);

            if (product == null)
            {
                return null;
            }

            product.Name = productUpdate.Name;
            product.Description = productUpdate.Description;
            product.Price = productUpdate.Price;
            product.Maker = productUpdate.Maker;
            product.Supplier = productUpdate.Supplier;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return product;
        }

    }

}

