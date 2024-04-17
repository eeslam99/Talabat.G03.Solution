using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.EmployeeSpecifications;
using Talabat.Core.ProductSpecifications;

namespace Talabat.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : APIBaseController
    {
        private readonly IGenericRepository<Employee> _EmployeeRepo;

        public EmployeeController(IGenericRepository<Employee> EmployeeRepo)
        {
            _EmployeeRepo = EmployeeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var spec = new EmpoyeeWithDepartmentSpecification();
            var Employees = await _EmployeeRepo.GetAllWithSpecAsync(spec);
            return Ok(Employees);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            var spec = new EmpoyeeWithDepartmentSpecification(id);
            var product = await _EmployeeRepo.GetWithSpecAsync(spec);

            if (product == null)
                return NotFound();//404
            return Ok(product);//200
        }
    }
}
