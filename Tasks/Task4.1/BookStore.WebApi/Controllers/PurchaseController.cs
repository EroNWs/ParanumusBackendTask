using BookStore.Business.Interfaces;
using BookStore.Dtos.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PurchaseController : ControllerBase
{
    private readonly IPurchaseService _purchaseService;

    public PurchaseController(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    [HttpPost("make-purchase")]
    public async Task<IActionResult> MakePurchase([FromBody] OrderRequestDto orderRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var orderResponse = await _purchaseService.ProcessPurchaseAsync(orderRequest);
            return Ok(orderResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}
