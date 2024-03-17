using AutoMapper;
using ProductPerformance.Application.Interfaces;
using ProductPerformance.Dtos;
using ProductPerformance.Infrastracture.Interface;
using ProductPerformance.Models;

namespace ProductPerformance.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(ProductCreateDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepository.AddAsync(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task UpdateAsync(ProductDto productDto)
    {
        var product = await _productRepository.GetByIdAsync(productDto.Id);
        _mapper.Map(productDto, product);
        await _productRepository.UpdateAsync(product);
    }


    public async Task DeleteAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }
}