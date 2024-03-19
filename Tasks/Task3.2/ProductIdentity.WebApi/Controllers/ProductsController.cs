using Microsoft.AspNetCore.Authorization;

namespace ProductIdentity.WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {

        _productRepository = productRepository;

    }


    // GET: api/Products
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {

        var products = await _productRepository.GetAllAsync();

        return Ok(products);

    }


    // GET: api/Products/5
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product is null)
        {

            return NotFound();

        }

        return product;

    }


    // POST: api/Products
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        await _productRepository.AddAsync(product);

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }


    // PUT: api/Products/5
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        if (id != product.Id)
        {

            return BadRequest();

        }

        await _productRepository.UpdateAsync(product);

        return NoContent();
    }


    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product is null)
        {

            return NotFound();

        }

        await _productRepository.DeleteAsync(id);

        return NoContent();
    }
}
