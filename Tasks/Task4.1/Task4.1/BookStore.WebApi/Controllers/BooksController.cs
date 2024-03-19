using BookStore.Business.Constants;
using BookStore.Business.Contracts;
using BookStore.Business.Interfaces;
using BookStore.Dtos.Books;
using BookStore.Shared.BaseController;
using BookStore.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : CustomBaseController
{
    private readonly IBookService _bookService;
    private readonly IInMemoryDataStoreService _storeService;
    private readonly ILoggerService _loggerService;
    public BooksController(IBookService bookService, IInMemoryDataStoreService storeService, ILoggerService loggerService)
    {
        _bookService = bookService;
        _storeService = storeService;
        _loggerService = loggerService;
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] BookCreateDto bookCreateDto)
    {
        _loggerService.LogInfo($"Attempting to add a new book: {bookCreateDto.Title}");
        if (!ModelState.IsValid)
        {
            _loggerService.LogError("Model state is invalid for adding a new book.");
            var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
            return BadRequest(Response<NoContent>.Fail(errors.ToList(), 400));
        }

        var createdBook = await _bookService.AddBookAsync(bookCreateDto);
        _loggerService.LogInfo($"Book added successfully: {createdBook.Title}");
        return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, Response<BookDto>.Success(createdBook, 201));

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(Guid id)
    {
        _loggerService.LogInfo($"Fetching book with ID: {id}");
        var book = await _bookService.GetBookByIdAsync(id);

        if (book is null)
        {
            _loggerService.LogError($"Book not found: {id}");
            return NotFound(Response<NoContent>.Fail(Messages.BookNotFound, 404));
        }

        _loggerService.LogInfo($"Book fetched successfully: {book.Title}");
        return Ok(Response<BookDto>.Success(book, 200));

    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        _loggerService.LogInfo("Fetching all books");
        var books = await _bookService.GetAllBooksAsync();

        _loggerService.LogInfo($"Fetched all books successfully. Total books: {books.Count()}");
        return Ok(Response<IEnumerable<BookListDto>>.Success(books, 200));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(Guid id, [FromBody] BookUpdateDto bookUpdateDto)
    {
        _loggerService.LogInfo($"Attempting to update book: {id}");
        if (!ModelState.IsValid)
        {
            _loggerService.LogError("Model state is invalid for updating book.");
            var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
            return BadRequest(Response<NoContent>.Fail(errors.ToList(), 400));
        }

        var updatedBook = await _bookService.UpdateBookAsync(id, bookUpdateDto);
        if (updatedBook is null)
        {
            _loggerService.LogError($"Book to update not found: {id}");
            return NotFound(Response<NoContent>.Fail(Messages.BookNotFound, 404));
        }

        _loggerService.LogInfo($"Book updated successfully: {updatedBook.Title}");
        return Ok(Response<BookDto>.Success(updatedBook, 200));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        _loggerService.LogInfo($"Attempting to delete book: {id}");
        await _bookService.DeleteBookAsync(id);

        _loggerService.LogInfo($"Book deleted successfully: {id}");
        return CreateActionResultInstance(Response<NoContent>.Success(204));

    }
}