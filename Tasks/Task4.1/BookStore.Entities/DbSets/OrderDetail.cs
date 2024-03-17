using BookStore.Core.Entities.Base;

namespace BookStore.Entities.DbSets;

internal class OrderDetail: AuditableEntity
{
    //order ile Order detail 1'e1 bağlı
       public Guid BookId { get; set; }

    public Book Book { get; set; }

    public int Count { get; set; }

    public double PaidPrice { get; set; }


}
