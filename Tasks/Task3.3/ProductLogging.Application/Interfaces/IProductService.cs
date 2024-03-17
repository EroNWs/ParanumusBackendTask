using ProductLogging.Dtos;

namespace ProductLogging.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto> GetByIdAsync(int id);
    Task AddAsync(ProductCreateDto productDto);
    Task UpdateAsync(ProductDto productDto);
    Task DeleteAsync(int id);
}
