
using AutoMapper;
using Talabat.API.Helpers;
using Talabat.API.ModelDTO;
using Talabat.Core.Models;

namespace Talabat.API.Profiless
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<Product,ProductDTO>()
                .ForMember(s=>s.ProductBrand,d=>d.MapFrom(p=>p.ProductBrand.Name))
                .ForMember(s => s.ProductType, d => d.MapFrom(p => p.ProductType.Name))
                .ForMember(s=>s.PictureUrl,d=>d.MapFrom<PictureUrlSolver>());
                    
        }
    }
}
