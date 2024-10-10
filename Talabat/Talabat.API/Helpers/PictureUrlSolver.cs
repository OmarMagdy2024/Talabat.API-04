using AutoMapper;
using AutoMapper.Execution;
using AutoMapper.Internal;
using System.Linq.Expressions;
using System.Reflection;
using Talabat.API.ModelDTO;
using Talabat.Core.Models;

namespace Talabat.API.Helpers
{
    public class PictureUrlSolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _configuration;

        public PictureUrlSolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
           if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["BaseURL"]}/{source.PictureUrl}";
            }
           return string.Empty;
        }
    }
}
