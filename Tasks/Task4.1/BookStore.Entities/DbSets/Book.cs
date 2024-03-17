namespace BookStore.Entities.DbSets;

public class Book:AuditableEntity
{ 

    public string Title { get; set; }

    public string  Author { get; set; }

    public string Isbn { get; set; }

    public double ListPrice { get; set; }

    public IEnumerable<Order> Orders { get; set; }



}
