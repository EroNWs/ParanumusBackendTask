using BookStore.Dtos.Books;

namespace BookStore.Business.Profiles;

public class BookProfile:Profile
{
    public BookProfile()
    {
        CreateMap<BookCreateDto, Book>();

        // Book -> BookDto
        CreateMap<Book, BookDto>();

        // BookUpdateDto -> Book
        CreateMap<BookUpdateDto, Book>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); 

        // Book -> BookListDto
        CreateMap<Book, BookListDto>();
    }
}
