using BookStore.Entities.Enums;

namespace BookStore.Entities.DbSets;

public class Customer: BaseUser
{   
    public CustomerRole CustomerRole { get; set; } = CustomerRole.RegularCustomer;

    public IEnumerable<Order> Orders { get; set; }

}
