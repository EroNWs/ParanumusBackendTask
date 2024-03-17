using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductPerformance.Application.Interfaces;
using ProductPerformance.Dtos;
using ProductPerformance.Models.Exceptions;

namespace ProductPerformance.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{

    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: api/Products
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product is null)
        {
            throw new ProductNotFoundException(id);
        }

        return product;
    }

    // POST: api/Products
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ProductDto>> PostProduct(ProductCreateDto productDto)
    {

        await _productService.AddAsync(productDto);

        return Ok(new { message = "Product created successfully" });
    }

    // PUT: api/Products/5
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> PutProduct(int id, ProductDto productDto)
    {
        if (id != productDto.Id)
        {
            throw new ProductNotFoundException(id);
        }

        await _productService.UpdateAsync(productDto);

        return NoContent();
    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteProduct(int id)
    {

        var product = await _productService.GetByIdAsync(id);
        if (product == null)
        {
            throw new ProductNotFoundException(id);
        }

        await _productService.DeleteAsync(id);

        return NoContent();
    }



}
