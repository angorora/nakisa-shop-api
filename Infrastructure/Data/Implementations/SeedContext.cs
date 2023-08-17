using System;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data.Implementations
{
	public static class SeedContext
	{
		public static async Task SeedData(StoreContext context)
		{
	
            if (!context.ProductBrands.Any())
            {
                var jsonProductBrands = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<ProductBrand[]>(jsonProductBrands);
                context.ProductBrands.AddRange(brands);
            }

            if (!context.ProductTypes.Any())
            {
                var jsonProductTypes = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<ProductType[]>(jsonProductTypes);
                context.ProductTypes.AddRange(types);
            }

            if (!context.Products.Any())
            {
                var jsonProducts = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<Product[]>(jsonProducts);
                context.Products.AddRange(products);
            }

            if (context.ChangeTracker.HasChanges())
			{
                await context.SaveChangesAsync();
			}
        }

	}
}

