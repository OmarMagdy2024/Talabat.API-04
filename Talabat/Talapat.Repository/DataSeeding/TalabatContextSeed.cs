using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Models;
using Talabat.Repository.Connections;

namespace Talabat.Repository.DataSeeding
{
	public static class TalabatContextSeed
	{
		public async static Task SeedAsync(TalabatDBContext talabatDBContext)
		{
			//var Brandsdata = File.ReadAllText("../Talabat.Repository/DataSeeding/brands.json");
			var Brandsdata = File.ReadAllText("..\\Talapat.Repository\\DataSeeding\\brands.json");
			var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(Brandsdata);
			if (Brands.Count() > 0)
			{
				//Brands = Brands.Select(b=> new ProductBrand()
				//{ Name=b.Name}).ToList();
				if (talabatDBContext.productBrands.Count() == 0)
				{
					foreach (var item in Brands)
					{
						talabatDBContext.Set<ProductBrand>().Add(item);
					}
					await talabatDBContext.SaveChangesAsync();
				}
            }
			var typedata = File.ReadAllText("..\\Talapat.Repository\\DataSeeding\\categories.json");
			var type = JsonSerializer.Deserialize<List<ProductType>>(typedata);
			if (type.Count() > 0)
			{
				if (talabatDBContext.productTypes.Count() == 0)
				{
					foreach (var item in type)
					{
						talabatDBContext.Set<ProductType>().Add(item);
					}
					await talabatDBContext.SaveChangesAsync();
				}
			}
			var Productsdata = File.ReadAllText("..\\Talapat.Repository\\DataSeeding\\products.json");
			var Product = JsonSerializer.Deserialize<List<Product>>(Productsdata);
			if (Product.Count() > 0)
			{
				if (talabatDBContext.products.Count() == 0)
				{
					foreach (var item in Product)
					{
						talabatDBContext.Set<Product>().Add(item);
					}
					await talabatDBContext.SaveChangesAsync();
				}
			}
		}
	}
}
