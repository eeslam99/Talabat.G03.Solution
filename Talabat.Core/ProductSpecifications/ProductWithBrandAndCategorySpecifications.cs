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
        // This constructor will be used for creating an object, that will be used to get all product 
        public ProductWithBrandAndCategorySpecifications(string sort) : base()
        {
            AddIncludes();

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        //OrderBy = P => P.Price;
                        AddOrderBy(P => P.Price);
                        break;
                    case "priceDesc":
                        //OrderByDesc = P => P.Price;
                        AddOrderByDesc(P => P.Price);
                        break;
                    default:
                        AddOrderBy(P => P.Name);
                        break;
                }
            }
            else
            {
                AddOrderBy(P => P.Name);
            }

        }

        // This Constructor will be used for creating An object, that will be used to get a specific product with id.
        public ProductWithBrandAndCategorySpecifications(int id) : base(P => P.Id == id)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }
    }
}
