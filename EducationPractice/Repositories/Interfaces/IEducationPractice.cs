using EducationPractice.dtos;
using EducationPractice.models;

namespace EducationPractice.Repositories.Interfaces
{
    public interface IEducationPractice
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(string id);
        Task<Product?> CreateAsync(ProductCreate productCreate);
        Task<Product?> UpdateAsync(string id, ProductUpdate updateProduct);
    }
}
