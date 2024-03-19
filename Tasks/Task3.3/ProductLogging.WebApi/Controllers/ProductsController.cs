using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductLogging.Application.Contracts;
using ProductLogging.Application.Interfaces;
using ProductLogging.Dtos;
using ProductLogging.Models.Exceptions;

namespace ProductLogging.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{

    private readonly IProductService _productService;
    private readonly ILoggerService _logger;

    public ProductsController(IProductService productService, ILoggerService logger)
    {
        _productService = productService;
        _logger = logger;
    }


    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: api/Products
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {

        _logger.LogInfo("Fetching all products.");
        var products = await _productService.GetAllAsync();

        _logger.LogInfo($"Fetched {products.Count()} products successfully.");
        return Ok(products);

    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        _logger.LogInfo($"Fetching product with id: {id}.");
        var product = await _productService.GetByIdAsync(id);

        if (product is null)
        {
            _logger.LogError($"Product with id: {id} not found.");
            throw new ProductNotFoundException(id);
        }

        _logger.LogInfo($"Fetched product with id: {id} successfully.");
        return product;


    }

    // POST: api/Products
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ProductDto>> PostProduct(ProductCreateDto productDto)
    {
        _logger.LogInfo("Creating a new product.");
        await _productService.AddAsync(productDto);

        _logger.LogInfo("Product created successfully.");
        return Ok(new { message = "Product created successfully" });
    }

    // PUT: api/Products/5
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> PutProduct(int id, ProductDto productDto)
    {
        if (id != productDto.Id)
        {
            _logger.LogError($"Product update failed. Product ID mismatch.");
            throw new ProductNotFoundException(id);
        }

        _logger.LogInfo($"Updating product with id: {id}.");
        await _productService.UpdateAsync(productDto);

        _logger.LogInfo($"Product with id: {id} updated successfully.");
        return NoContent();

    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        _logger.LogInfo($"Deleting product with id: {id}.");
        var product = await _productService.GetByIdAsync(id);

        if (product == null)
        {
            _logger.LogError($"Product with id: {id} not found for deletion.");
            throw new ProductNotFoundException(id);
        }

        await _productService.DeleteAsync(id);
        _logger.LogInfo($"Product with id: {id} deleted successfully.");

        return NoContent();
    }



}

