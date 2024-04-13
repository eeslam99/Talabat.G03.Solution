using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Repositories;
using Talabat.Core.Entities;

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
        public async Task<IActionResult> GetProducts() 
        {
            var Products = await _productRepo.GetAllAsync();
            return Ok(Products);
        }
        

        //Get Product By Id
    }
}
