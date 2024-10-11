using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.Errors;
using Talabat.API.ModelDTO;
using Talabat.Core.Interfaces;
using Talabat.Core.Models;
using Talabat.Core.Specification;

namespace Talabat.API.Controllers
{
	[Route("Talabat/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IGenaricRepository<Product> _genaricRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ProductController(IGenaricRepository<Product> genaricRepository ,IMapper mapper,IConfiguration configuration)
        {
			_genaricRepository = genaricRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
		{
			var spec=new ProductSpecification();
			var product = await _genaricRepository.GetAllWithSpecAsync(spec);
			if (product == null)
			{
				return NotFound(new APIResponse(404));
			}
			return Ok(_mapper.Map< IEnumerable<Product>, IEnumerable<ProductDTO>>(product));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var spec = new ProductSpecification(id);
			var product = await _genaricRepository.GetByIdWithSpecAsync(spec);

            if (product == null)
            {
                return NotFound(new APIResponse(404));
            }
            return Ok(new ProductDTO()
			{
				Id=product.Id,
				Name=product.Name,
				PictureUrl = $"{_configuration["BaseURL"]}/{product.PictureUrl}",
				Price=product.Price,
				ProductBrand=product.ProductBrand.Name,
				ProductType=product.ProductType.Name,
				Description=product.Description,
			});
		}
    }
}
