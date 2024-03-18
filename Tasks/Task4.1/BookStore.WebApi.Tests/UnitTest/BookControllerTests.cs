using BookStore.Business.Interfaces;
using BookStore.Dtos.Books;
using BookStore.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BookStore.WebApi.Tests.UnitTest;

public class BookControllerTests
{
    private readonly Mock<IBookService> _mockBookService;
    private readonly BooksController _controller;

    public BookControllerTests()
    {
        _mockBookService = new Mock<IBookService>();
        _controller = new BooksController(_mockBookService.Object);
    }

    [Fact]
    public async Task GetAllBooks_ReturnsOkObjectResult_WithListOfBooks()
    {
        // Arrange
        var mockBooks = new List<BookListDto>
            {
                new BookListDto { Id = Guid.NewGuid(), Title = "Test Book 1", Author = "Author 1", ListPrice = 10 },
                new BookListDto { Id = Guid.NewGuid(), Title = "Test Book 2", Author = "Author 2", ListPrice = 20 }
            };

        _mockBookService.Setup(service => service.GetAllBooksAsync())
            .ReturnsAsync(mockBooks);

        // Act
        var result = await _controller.GetAllBooks();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedBooks = Assert.IsType<List<BookListDto>>(okResult.Value);
        Assert.Equal(2, returnedBooks.Count);
    }

    [Fact]
    public async Task GetBook_ReturnsOkObjectResult_WithBook()
    {
        // Arrange
        var bookId = Guid.NewGuid();
        var mockBook = new BookDto { Id = bookId, Title = "Test Book", Author = "Author", Isbn = "ISBN", ListPrice = 100 };

        _mockBookService.Setup(service => service.GetBookByIdAsync(bookId))
            .ReturnsAsync(mockBook);

        // Act
        var result = await _controller.GetBook(bookId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedBook = Assert.IsType<BookDto>(okResult.Value);
        Assert.Equal(bookId, returnedBook.Id);
    }

    [Fact]
    public async Task AddBook_ReturnsCreatedAtActionResult_WithBookDto()
    {
        // Arrange
        var bookCreateDto = new BookCreateDto { Title = "New Book", Author = "New Author", Isbn = "ISBN123", ListPrice = 30 };
        var bookDto = new BookDto { Id = Guid.NewGuid(), Title = "New Book", Author = "New Author", Isbn = "ISBN123", ListPrice = 30 };

        _mockBookService.Setup(service => service.AddBookAsync(It.IsAny<BookCreateDto>()))
            .ReturnsAsync(bookDto);

        // Act
        var result = await _controller.AddBook(bookCreateDto);

        // Assert
        var createdAtAction = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal("GetBook", createdAtAction.ActionName);
        var returnedBook = Assert.IsType<BookDto>(createdAtAction.Value);
        Assert.Equal(bookDto.Title, returnedBook.Title);
        Assert.Equal(bookDto.Author, returnedBook.Author);
    }

    [Fact]
    public async Task UpdateBook_ReturnsOkObjectResult_WithUpdatedBookDto()
    {
        // Arrange
        var bookId = Guid.NewGuid();
        var bookUpdateDto = new BookUpdateDto { Title = "Book 22", Author = "Author 2", Isbn = "ISBN0002", ListPrice = 25 };
        var bookDto = new BookDto { Id = bookId, Title = bookUpdateDto.Title, Author = bookUpdateDto.Author, Isbn = bookUpdateDto.Isbn, ListPrice = bookUpdateDto.ListPrice };

        var mockBookService = new Mock<IBookService>();
        mockBookService.Setup(service => service.UpdateBookAsync(bookId, bookUpdateDto)).ReturnsAsync(bookDto);
        var controller = new BooksController(mockBookService.Object);

        // Act
        var result = await controller.UpdateBook(bookId, bookUpdateDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var updatedBook = Assert.IsType<BookDto>(okResult.Value);
        Assert.Equal(bookDto.Title, updatedBook.Title);
        Assert.Equal(bookDto.Author, updatedBook.Author);
        Assert.Equal(bookDto.Isbn, updatedBook.Isbn);
        Assert.Equal(bookDto.ListPrice, updatedBook.ListPrice);
    }

    [Fact]
    public async Task DeleteBook_ReturnsNoContentResult()
    {
        // Arrange
        var mockBookService = new Mock<IBookService>();
        var bookId = Guid.NewGuid();

        mockBookService.Setup(service => service.DeleteBookAsync(bookId)).Returns(Task.CompletedTask);
        var controller = new BooksController(mockBookService.Object);

        // Act
        var result = await controller.DeleteBook(bookId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }


}
