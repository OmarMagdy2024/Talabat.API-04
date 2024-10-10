using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Models
{
	public class ProductType:BaseModel
	{
		[Required(ErrorMessage = "Name Of Type Is Required")]
		public string Name { get; set; }
		//public ICollection<Product> products { get; set; } = new HashSet<Product>();
	}
}
