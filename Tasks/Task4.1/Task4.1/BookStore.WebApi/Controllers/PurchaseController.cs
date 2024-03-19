using BookStore.Business.Constants;
using BookStore.Business.Contracts;
using BookStore.Business.Interfaces;
using BookStore.Dtos.Orders;
using BookStore.Shared.BaseController;
using BookStore.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PurchaseController : CustomBaseController
{
    private readonly IPurchaseService _purchaseService;
    private readonly IInMemoryDataStoreService _storeService;
    private readonly ILoggerService _loggerService;

    public PurchaseController(IPurchaseService purchaseService, IInMemoryDataStoreService storeService, ILoggerService loggerService)
    {
        _purchaseService = purchaseService;
        _storeService = storeService;
        _loggerService = loggerService;
    }

    [HttpPost("make-purchase")]
    public async Task<IActionResult> MakePurchase([FromBody] OrderRequestDto orderRequest)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList();
            _loggerService.LogWarning($"Validation failed: {string.Join(", ", errors)}");
            return CreateActionResultInstance(Response<NoContent>.Fail(ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList(), 400));
        }

        var requestId = Guid.NewGuid();
        _storeService.Add(requestId, orderRequest);

        try
        {
            var orderResponse = await _purchaseService.ProcessPurchaseAsync(orderRequest);
            _loggerService.LogInfo("Purchase processed successfully.");
            return CreateActionResultInstance(Response<OrderResponseDto>.Success(orderResponse, 200));
        }
        catch (Exception ex)
        {
            _loggerService.LogError($"An error occurred while processing purchase: {ex.Message}");
            return CreateActionResultInstance(Response<NoContent>.Fail(Messages.InternalServerError, 500));
        }
    }
}
