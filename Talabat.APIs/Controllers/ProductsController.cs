using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Repositories;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;
using Talabat.Core.ProductSpecifications;

namespace Talabat.APIs.Controllers
{
    public class ProductsController : APIBaseController
    {
        private readonly IGenericRepository<Product> _productRepo;

        public ProductsController(IGenericRepository<Product> ProductRepo)
        {
            _productRepo = ProductRepo;
        }

        //Get All Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() 
        {
            var spec = new ProductWithBrandAndCategorySpecifications();
            var Products = await _productRepo.GetAllWithSpecAsync(spec);
            return Ok(Products);
        }

        //Get Product By Id

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            var spec = new ProductWithBrandAndCategorySpecifications(id);
            var product =await _productRepo.GetWithSpecAsync(spec);

            if (product == null) 
                return NotFound();//404
            return Ok(product);//200
        }

    }
}
