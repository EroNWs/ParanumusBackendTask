using AutoMapper;
using ProductLogging.Dtos;
using ProductLogging.Models;

namespace ProductLogging.Application.MappingConfig;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();

        CreateMap<ProductDto, Product>().ReverseMap();
    }
}
