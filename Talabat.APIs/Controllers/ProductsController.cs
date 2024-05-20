using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Repositories;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;
using Talabat.Core.ProductSpecifications;
using AutoMapper;
using Talabat.APIs.Dtos;
using Talabat.APIs.Errors;
using System.Security.Cryptography.X509Certificates;

namespace Talabat.APIs.Controllers
{
    public class ProductsController : APIBaseController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<ProductCategory> _categoriesRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> ProductRepo,IGenericRepository<ProductBrand>brandRepo, IGenericRepository<ProductCategory> categoriesRepo,  IMapper mapper )
        {   
            _productRepo = ProductRepo;
            _brandRepo = brandRepo;
            _categoriesRepo = categoriesRepo;
            _mapper = mapper;
        }

        //Get All Products
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(string sort) 
        { 
            var spec = new ProductWithBrandAndCategorySpecifications(sort);
            var Products = await _productRepo.GetAllWithSpecAsync(spec);
            return Ok(_mapper.Map<IEnumerable<Product>,IEnumerable<ProductToReturnDto>>(Products));
        }

        //Get Product By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {

            var spec = new ProductWithBrandAndCategorySpecifications(id);
            var product =await _productRepo.GetWithSpecAsync(spec);

            if (product == null)
                return NotFound(new ApiResponse(404));
            return Ok(_mapper.Map<Product, ProductToReturnDto>(product));//200
        }

        [HttpGet("brands")] //GET: /api/product/brands
        public async Task<ActionResult<IReadOnlyList<Product>>> GetBrands()
        {
            var brands = await _brandRepo.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("Categories")] //GET: /api/products/categories
        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetCategory()
        {
            var categories = await _categoriesRepo.GetAllAsync();
            return Ok(categories);
        }


    }
}  
 