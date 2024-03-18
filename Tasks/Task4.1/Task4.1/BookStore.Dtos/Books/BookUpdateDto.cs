namespace BookStore.Dtos.Books;

public class BookUpdateDto
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public double ListPrice { get; set; }
}
