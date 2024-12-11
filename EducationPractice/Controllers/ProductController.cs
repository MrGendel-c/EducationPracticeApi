using Microsoft.AspNetCore.Mvc;
using EducationPractice.models;
using EducationPractice.dtos;
using Microsoft.AspNetCore.Authorization;
using EducationPractice.mappers;
using Microsoft.AspNetCore.HttpLogging;
using EducationPractice.Repositories.Interfaces;

namespace EducationPractice.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IEducationPractice _EducationPrac;
       
        public ProductController(IEducationPractice educationPrac)
        {
            _EducationPrac = educationPrac;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Product> products = await _EducationPrac.GetAllAsync();
            IEnumerable<ProductResponse> productDtos = products.Select(c => c.ToProductResponse());
            return Ok(productDtos);
        }
        //[HttpGet("{productId}")]
        //public async Task<IActionResult> GetById([FromRoute] string productId)
        //{
        //    Product? product = await _EducationPrac.GetByIdAsync(productId);
        //    return product == null ? NotFound() : Ok(product.ToProductResponse);            
        //}
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreate productCreate)
        {
            Product? product = await _EducationPrac.CreateAsync(productCreate);
            return product == null ? NotFound() : Ok(product?.ToProductResponse());
        }
        [HttpPut]
        [Route("{productId}")]
        public async Task<IActionResult> Update([FromRoute] string productId, [FromBody] ProductUpdate productUpdate)
        {
            Product? product = await _EducationPrac.UpdateAsync(productId, productUpdate);
            return product == null ? NotFound() : Ok(product?.ToProductResponse());
        }

    }
}
