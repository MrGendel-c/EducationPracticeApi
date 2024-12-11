using EducationPractice.dtos;
using EducationPractice.models;

namespace EducationPractice.mappers;

public static class ProductMapper
{
    public static ProductResponse ToProductResponse(this Product product) => new ProductResponse
    {
        Id = product.Id,
        Name = product.Name,
        Description = product.Description,
        Price = product.Price,
        Maker = product.Maker,
        Supplier = product.Supplier
    };
     public static Product ToProductCreate(this ProductCreate productCreate) => new Product
     {
        Name = productCreate.Name,
        Description = productCreate.Description,
        Price = productCreate.Price,
        Maker = productCreate.Maker,
        Supplier = productCreate.Supplier,
     };
}

