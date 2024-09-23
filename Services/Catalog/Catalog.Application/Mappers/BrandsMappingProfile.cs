using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Core.Entities;

namespace Catalog.Application.Mappers
{
    public class BrandsMappingProfile : Profile
    {
        public BrandsMappingProfile()
        {
            CreateMap<Brand, BrandResponse>().ReverseMap(); 
        }
    }
}
