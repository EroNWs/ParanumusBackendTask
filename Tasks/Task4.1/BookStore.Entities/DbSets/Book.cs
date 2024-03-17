using BookStore.Core.Entities.Base;

namespace BookStore.Entities.DbSets;

public class Book:AuditableEntity
{
    //Order Detail ile 1 Order Detail'da 1'den çok kitap olur. 1'e çok

    public string Title { get; set; }

    public string  Author { get; set; }

    public string Isbn { get; set; }

    public double ListPrice { get; set; }

    public IEnumerable<Order> Orders { get; set; }



}
