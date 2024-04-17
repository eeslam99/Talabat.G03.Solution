using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Core.ProductSpecifications
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product>
    {   
        //This constructor will be used for creating an object, that will be used to get all product 
        public ProductWithBrandAndCategorySpecifications() :base()
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }
    }
}
