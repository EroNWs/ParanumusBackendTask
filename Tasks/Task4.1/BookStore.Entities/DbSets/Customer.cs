using BookStore.Core.Entities.Base;

namespace BookStore.Entities.DbSets;

public class Customer: BaseUser
{
    //1'e Çok Bağlı Customer ile Order

    public IEnumerable<Order> Orders { get; set; }

}
