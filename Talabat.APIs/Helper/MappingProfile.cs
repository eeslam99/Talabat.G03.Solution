using AutoMapper;
using Talabat.APIs.Dtos;
using Talabat.Core.Entities;

namespace Talabat.APIs.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d=>d.Brand , O=>O.MapFrom(s=>s.Brand.Name))
                .ForMember(d => d.Category, O => O.MapFrom(s => s.Category.Name))
                //.ForMember(p=>p.PictureUrl,o=>o.MapFrom(s=> $"{_configuration["ApiBaseUrl"]}{s.PictureUrl}"));
                .ForMember(p => p.PictureUrl, o => o.MapFrom<ProductPictureUrlRsolver>());
        }
    }
}
