using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Core.EmployeeSpecifications
{
     public class EmpoyeeWithDepartmentSpecification : BaseSpecifications<Employee>
    {
        // This constructor will be used for creating an object, that will be used to get all product 
        public EmpoyeeWithDepartmentSpecification() : base()
        {
            AddIncludes();
        }

        // This Constructor will be used for creating An object, that will be used to get a specific product with id.
        public EmpoyeeWithDepartmentSpecification(int id) : base(P => P.Id == id)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            Includes.Add(E => E.Department);
        }

    }
    
}
