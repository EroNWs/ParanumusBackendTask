using AutoMapper;
using ProductLogging.Application.Contracts;
using ProductLogging.Application.Interfaces;
using ProductLogging.Dtos;
using ProductLogging.Infrastracture.Interface;
using ProductLogging.Models;

namespace ProductLogging.Application.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly ILoggerService _loggerService;

    public ProductService(IProductRepository productRepository, IMapper mapper, ILoggerService loggerService)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _loggerService = loggerService;
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

        if (product is null)
        {
            string message = $"The Book with id :{productDto.Id} could not found";
            _loggerService.LogInfo(message);
            throw new Exception(message);

        }

        _mapper.Map(productDto, product);

        await _productRepository.UpdateAsync(product);

    }


    public async Task DeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if(product is null)
        {

            string message = $"The Book with id :{id} could not found";
            _loggerService.LogInfo(message);
            throw new Exception(message);

        }

        await _productRepository.DeleteAsync(id);

    }
}