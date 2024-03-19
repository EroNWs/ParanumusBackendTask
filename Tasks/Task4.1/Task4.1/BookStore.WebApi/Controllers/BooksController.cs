using BookStore.Business.Constants;
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

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] BookCreateDto bookCreateDto)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
            return BadRequest(Response<NoContent>.Fail(errors.ToList(), 400));
        }

        var createdBook = await _bookService.AddBookAsync(bookCreateDto);
        return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, Response<BookDto>.Success(createdBook, 201));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(Guid id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        if (book is null)
        {
            return NotFound(Response<NoContent>.Fail(Messages.BookNotFound, 404));
        }
        return Ok(Response<BookDto>.Success(book, 200));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _bookService.GetAllBooksAsync();
        return Ok(Response<IEnumerable<BookListDto>>.Success(books, 200));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(Guid id, [FromBody] BookUpdateDto bookUpdateDto)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
            return BadRequest(Response<NoContent>.Fail(errors.ToList(), 400));
        }

        var updatedBook = await _bookService.UpdateBookAsync(id, bookUpdateDto);
        if (updatedBook is null)
        {
            return NotFound(Response<NoContent>.Fail(Messages.BookNotFound, 404));
        }
        return Ok(Response<BookDto>.Success(updatedBook, 200));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        await _bookService.DeleteBookAsync(id);
        return CreateActionResultInstance(Response<NoContent>.Success(204));
    }
}