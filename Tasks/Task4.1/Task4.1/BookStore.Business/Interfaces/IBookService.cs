using BookStore.Dtos.Books;

namespace BookStore.Business.Interfaces;

public interface IBookService
{
    Task<BookDto> AddBookAsync(BookCreateDto bookCreateDto);
    Task<BookDto> GetBookByIdAsync(Guid id);
    Task<IEnumerable<BookListDto>> GetAllBooksAsync();
    Task<BookDto> UpdateBookAsync(Guid id, BookUpdateDto bookUpdateDto);
    Task DeleteBookAsync(Guid id);

}
