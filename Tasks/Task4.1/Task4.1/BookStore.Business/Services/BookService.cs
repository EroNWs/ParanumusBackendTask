using BookStore.Dtos.Books;

namespace BookStore.Business.Services;

public class BookService : IBookService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public BookService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<BookDto> AddBookAsync(BookCreateDto bookCreateDto)
    {
        var book = _mapper.Map<Book>(bookCreateDto);

        _repositoryManager.BookRepository.AddAsync(book);

        await _repositoryManager.SaveAsync();

        return _mapper.Map<BookDto>(book);

    }

    public async Task DeleteBookAsync(Guid id)
    {
        var book = await _repositoryManager.BookRepository.GetByIdAsync(id);

        if (book != null)
        {
            _repositoryManager.BookRepository.DeleteAsync(book);

            await _repositoryManager.SaveAsync();
        }
    }

    public async Task<IEnumerable<BookListDto>> GetAllBooksAsync()
    {
        var books = await _repositoryManager.BookRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<BookListDto>>(books);

    }

    public async Task<BookDto> GetBookByIdAsync(Guid id)
    {
        var book = await _repositoryManager.BookRepository.GetByIdAsync(id);

        return book != null ? _mapper.Map<BookDto>(book) : null;

    }

    public async Task<BookDto> UpdateBookAsync(Guid id, BookUpdateDto bookUpdateDto)
    {
        var book = await _repositoryManager.BookRepository.GetByIdAsync(id, tracking: true);

        if (book == null)
        {
            return null;
        }

        _mapper.Map(bookUpdateDto, book);

        _repositoryManager.BookRepository.UpdateAsync(book);
        await _repositoryManager.SaveAsync();

        return _mapper.Map<BookDto>(book);
    }
}