using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;

namespace Talabat.Core.Specification
{
    public class ProductSpecification:Specification<Product>
    {
        public ProductSpecification()
        {
            Includes.Add(p=>p.ProductBrand);
            Includes.Add(p=>p.ProductType);
        }
        public ProductSpecification(int id):base(p => p.Id == id)
        {
            //Critria =p=>p.Id==id;
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
        }
    }
}
