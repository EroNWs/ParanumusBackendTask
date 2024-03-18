using BookStore.Business.Interfaces;
using BookStore.Dal.Contexts;
using BookStore.Dtos.Orders;
using BookStore.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace BookStore.WebApi.UnitTest;

public class PurchaseControllerTests
{
    private readonly Mock<IPurchaseService> _mockPurchaseService;
    private readonly Mock<IInMemoryDataStoreService> _mockInMemoryDataStoreService;
    private readonly PurchaseController _controller;

    public PurchaseControllerTests()
    {
        _mockPurchaseService = new Mock<IPurchaseService>();
        _mockInMemoryDataStoreService = new Mock<IInMemoryDataStoreService>();

        _controller = new PurchaseController(_mockPurchaseService.Object, _mockInMemoryDataStoreService.Object);

    }

    [Fact]
    public async Task MakePurchase_ReturnsOk_WithValidRequest()
    {

        var customerId = new Guid("16378271-BB3C-4F39-914D-08DC46B9FD6B");
        var bookId1 = new Guid("FDDA8399-ED3E-4C66-62DF-08DC46B9FD2E");
        var bookId2 = new Guid("1D451DEB-D112-4B13-62E0-08DC46B9FD2E");
        var orderRequest = new OrderRequestDto
        {
            CustomerId = customerId,
            Books = new List<OrderDto>
                {
                     new OrderDto { BookId = bookId1, Count = 2 },
        new OrderDto { BookId = bookId2, Count = 1 }
                },
            TotalPrice = 100
        };
        var orderResponse = new OrderResponseDto
        {
            OriginalPrice = 100,
            DiscountAmount = 10,
            FinalPrice = 90
        };

        _mockPurchaseService.Setup(service => service.ProcessPurchaseAsync(It.IsAny<OrderRequestDto>()))
                             .ReturnsAsync(orderResponse);


        var result = await _controller.MakePurchase(orderRequest);

   
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedOrderResponse = Assert.IsType<OrderResponseDto>(okResult.Value);
        Assert.Equal(orderResponse.FinalPrice, returnedOrderResponse.FinalPrice);
        _mockInMemoryDataStoreService.Verify(service => service.Add(It.IsAny<string>(), It.IsAny<OrderRequestDto>()), Times.Once);
    }

    [Fact]
    public async Task MakePurchase_ReturnsBadRequest_WhenModelStateIsInvalid()
    {

        _controller.ModelState.AddModelError("error", "some error");

 
        var result = await _controller.MakePurchase(new OrderRequestDto());


        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task MakePurchase_Returns500StatusCode_OnException()
    {

        var customerId = new Guid("16378271-BB3C-4F39-914D-08DC46B9FD6B");
        var bookId1 = new Guid("FDDA8399-ED3E-4C66-62DF-08DC46B9FD2E");
        var bookId2 = new Guid("1D451DEB-D112-4B13-62E0-08DC46B9FD2E");

        var orderRequest = new OrderRequestDto
        {
            CustomerId = customerId,
            Books = new List<OrderDto>
    {
     new OrderDto { BookId = bookId1, Count = 2 },
        new OrderDto { BookId = bookId2, Count = 1 }
    },
            TotalPrice = 100
        };

        _mockPurchaseService.Setup(service => service.ProcessPurchaseAsync(It.IsAny<OrderRequestDto>()))
                            .ThrowsAsync(new Exception("Internal server error"));


        var result = await _controller.MakePurchase(orderRequest);


        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
        Assert.Equal("Internal server error", statusCodeResult.Value);
    }
}
