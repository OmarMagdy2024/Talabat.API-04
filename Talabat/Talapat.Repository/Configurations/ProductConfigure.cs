using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;

namespace Talabat.Repository.Configurations
{
	public class ProductConfigure : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(p=> p.Name)
				   .IsRequired();

			builder.Property(builder=> builder.Description)
				   .IsRequired();

			builder.Property(p=>p.Price)
				   .IsRequired()
				   .HasColumnType("decimal(18,2)");

			builder.HasOne(p => p.ProductBrand)
				   .WithMany()
				   .HasForeignKey(p => p.BrandId);

			builder.HasOne(p => p.ProductType)
				   .WithMany()
				   .HasForeignKey(p => p.TypeId);
		}
	}
}
