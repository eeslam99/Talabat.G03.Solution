using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext dbContext)
        {
            if(!dbContext.ProductBrands.Any()) 
            {
                var BrandsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json");
                var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
                if (Brands?.Count > 0)
                {
                    foreach (var Brand in Brands)
                    {
                        await dbContext.Set<ProductBrand>().AddAsync(Brand);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }
            if (!dbContext.ProductCategories.Any())
            {
                var CategoriesData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/Category.json");
                var Categories = JsonSerializer.Deserialize<List<ProductCategory>>(CategoriesData);
                if (Categories?.Count > 0)
                {
                    foreach (var Category in Categories)
                    {
                        await dbContext.Set<ProductCategory>().AddAsync(Category);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }
            if (!dbContext.Products.Any())
            {
                var ProductsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                if (Products?.Count > 0)
                {
                    foreach (var Product in Products)
                    {
                        await dbContext.Set<Product>().AddAsync(Product);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
