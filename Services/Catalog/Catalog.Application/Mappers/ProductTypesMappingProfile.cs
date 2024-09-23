using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Core.Entities;

namespace Catalog.Application.Mappers
{
    public class ProductTypesMappingProfile : Profile
    {
        public ProductTypesMappingProfile()
        {
            CreateMap<ProductType, ProductTypeResponse>();
        }
    }
}
