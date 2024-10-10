using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.Repository.Configurations;
using Talabat.Core.Models;

namespace Talabat.Repository.Connections
{
	public class TalabatDBContext:DbContext
	{
        public TalabatDBContext(DbContextOptions<TalabatDBContext> options):base(options){ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.ApplyConfiguration(new ProductConfigure());
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			//base.OnModelCreating(modelBuilder);
		}
		public DbSet<Product> products { get; set; }
		public DbSet<ProductBrand> productBrands { get; set; }
		public DbSet<ProductType> productTypes { get; set; }
	}
}
