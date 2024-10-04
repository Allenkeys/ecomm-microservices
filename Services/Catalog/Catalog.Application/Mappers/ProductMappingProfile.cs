using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.DTOs;
using Catalog.Core.Entities;

namespace Catalog.Application.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductResponse>();
            
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
