﻿using BookStore.Business.Contracts;
using BookStore.Business.Interfaces;
using BookStore.Dtos.Books;
using BookStore.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BookStore.WebApi.Tests.UnitTest;

public class BookControllerTests
{
    private readonly Mock<IInMemoryDataStoreService> _mockStoreService;
    private readonly Mock<IBookService> _mockBookService;
    private readonly BooksController _controller;
    private readonly Mock<ILoggerService> _mockLoggerService;

    public BookControllerTests()
    {
        _mockBookService = new Mock<IBookService>();
        _mockStoreService = new Mock<IInMemoryDataStoreService>();
        _controller = new BooksController(_mockBookService.Object, _mockStoreService.Object, _mockLoggerService.Object);
    }

    [Fact]
    public async Task GetAllBooks_ReturnsOkObjectResult_WithListOfBooks()
    {
        var book1Id = Guid.NewGuid();
        var book2Id = Guid.NewGuid();
     
        var mockBooks = new List<BookListDto>
            {
                new BookListDto { Id = book1Id, Title = "Test Book 1", Author = "Author 1", ListPrice = 10 },
                new BookListDto { Id = book2Id, Title = "Test Book 2", Author = "Author 2", ListPrice = 20 }
            };

        _mockBookService.Setup(service => service.GetAllBooksAsync())
            .ReturnsAsync(mockBooks);
        _mockStoreService.Setup(service => service.Exists(It.IsAny<Guid>())).Returns(true);

        var result = await _controller.GetAllBooks();
         
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedBooks = Assert.IsType<List<BookListDto>>(okResult.Value);

        Assert.Equal(2, returnedBooks.Count);

        _mockStoreService.Verify(service => service.Exists(book1Id), Times.Once);
        _mockStoreService.Verify(service => service.Exists(book2Id), Times.Once);

    }

    [Fact]
    public async Task GetBook_ReturnsOkObjectResult_WithBook()
    {
  
        var bookId = Guid.NewGuid();
        var mockBook = new BookDto { Id = bookId, Title = "Test Book", Author = "Author", Isbn = "ISBN", ListPrice = 100 };

        _mockBookService.Setup(service => service.GetBookByIdAsync(bookId))
            .ReturnsAsync(mockBook);
        _mockStoreService.Setup(service => service.Get(bookId))
                  .Returns(() => _mockStoreService.Object.Get(bookId));


        var result = await _controller.GetBook(bookId);

   
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedBook = Assert.IsType<BookDto>(okResult.Value);

        Assert.Equal(bookId, returnedBook.Id);
    }

    [Fact]
    public async Task AddBook_ReturnsCreatedAtActionResult_WithBookDto()
    {
   
        var bookCreateDto = new BookCreateDto { Title = "New Book", Author = "New Author", Isbn = "ISBN123", ListPrice = 30 };
        var bookDto = new BookDto { Id = Guid.NewGuid(), Title = "New Book", Author = "New Author", Isbn = "ISBN123", ListPrice = 30 };

        _mockStoreService.Setup(x => x.Add(bookDto.Id, It.IsAny<object>()));
        _mockBookService.Setup(service => service.AddBookAsync(It.IsAny<BookCreateDto>()))
            .ReturnsAsync(bookDto);

        var result = await _controller.AddBook(bookCreateDto);

      
        var createdAtAction = Assert.IsType<CreatedAtActionResult>(result);

        Assert.Equal("GetBook", createdAtAction.ActionName);

        var returnedBook = Assert.IsType<BookDto>(createdAtAction.Value);

        Assert.Equal(bookDto.Title, returnedBook.Title);
        Assert.Equal(bookDto.Author, returnedBook.Author);

        _mockStoreService.Verify(x => x.Add(bookDto.Id, It.IsAny<object>()), Times.Once);
    }

    [Fact]
    public async Task UpdateBook_ReturnsOkObjectResult_WithUpdatedBookDto()
    {
  
        var bookId = Guid.NewGuid();
        var bookUpdateDto = new BookUpdateDto { Title = "Book 22", Author = "Author 2", Isbn = "ISBN0002", ListPrice = 25 };
        var bookDto = new BookDto { Id = bookId, Title = bookUpdateDto.Title, Author = bookUpdateDto.Author, Isbn = bookUpdateDto.Isbn, ListPrice = bookUpdateDto.ListPrice };

        _mockStoreService.Setup(x => x.Exists(bookId)).Returns(true);

        var mockBookService = new Mock<IBookService>();
        
        mockBookService.Setup(service => service.UpdateBookAsync(bookId, bookUpdateDto)).ReturnsAsync(bookDto);

        var controller = new BooksController(_mockBookService.Object, _mockStoreService.Object, _mockLoggerService.Object);


        var result = await controller.UpdateBook(bookId, bookUpdateDto);


        var okResult = Assert.IsType<OkObjectResult>(result);
        var updatedBook = Assert.IsType<BookDto>(okResult.Value);

        Assert.Equal(bookDto.Title, updatedBook.Title);
        Assert.Equal(bookDto.Author, updatedBook.Author);
        Assert.Equal(bookDto.Isbn, updatedBook.Isbn);
        Assert.Equal(bookDto.ListPrice, updatedBook.ListPrice);

        _mockStoreService.Verify(x => x.Exists(bookId), Times.Once);
        _mockStoreService.Verify(x => x.Update(bookId, It.IsAny<object>()), Times.Once);
    }

    [Fact]
    public async Task DeleteBook_ReturnsNoContentResult()
    {
     
        var mockBookService = new Mock<IBookService>();
        var bookId = Guid.NewGuid();
        var mockStoreService = new Mock<IInMemoryDataStoreService>();

        mockBookService.Setup(service => service.DeleteBookAsync(It.IsAny<Guid>())).Returns(Task.CompletedTask);
        mockBookService.Setup(service => service.DeleteBookAsync(bookId)).Returns(Task.CompletedTask);
        var controller = new BooksController(_mockBookService.Object, _mockStoreService.Object, _mockLoggerService.Object);


        var result = await controller.DeleteBook(bookId);

    
        Assert.IsType<NoContentResult>(result);
        mockStoreService.Verify(service => service.Delete(bookId), Times.Once, "The book was not deleted from the in-memory store.");

    }

}
