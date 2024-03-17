using BookStore.Core.Entities.Base;
using BookStore.Core.Enums;
using BookStore.Entities.DbSets;
using BookStore.Entity.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Claims;

namespace BookStore.Dal.Contexts;

public class BookStoreDbContext : IdentityDbContext
{

    private readonly IHttpContextAccessor? _contextAccessor;
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options, IHttpContextAccessor contextAccessor) : base(options)
    {
        _contextAccessor = contextAccessor;
    }
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }
    public virtual DbSet<Admin> Admins { get; set; } = null!;
    public virtual DbSet<Book> Books { get; set; } = null!;
    public virtual DbSet<Customer> Customers { get; set; } = null!;
    public virtual DbSet<Order> Orders { get; set; } = null!;
    public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(IEntityConfiguration).Assembly);

        base.OnModelCreating(builder);
    }

    public override int SaveChanges()
    {
        SetBaseProperties();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetBaseProperties();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetBaseProperties()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        var userId = _contextAccessor?.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "NotFound-User";
        foreach (var entry in entries)
        {
            SetIfAdded(entry, userId);
            SetIfModified(entry, userId);
            SetIfDeleted(entry, userId);
        }
    }

    private void SetIfAdded(EntityEntry<BaseEntity> entityEntry, string userId)
    {
        if (entityEntry.State != EntityState.Added)
        {
            return;
        }

        entityEntry.Entity.Status = Status.Added;
        entityEntry.Entity.CreatedDate = DateTime.Now;
        entityEntry.Entity.CreatedBy = userId;
    }

    private void SetIfModified(EntityEntry<BaseEntity> entityEntry, string userId)
    {
        if (entityEntry.State == EntityState.Modified)
        {
            entityEntry.Entity.Status = Status.Modified;
        }
        entityEntry.Entity.ModifiedDate = DateTime.Now;
        entityEntry.Entity.ModifiedBy = userId;
    }

    private void SetIfDeleted(EntityEntry<BaseEntity> entityEntry, string userId)
    {
        if (entityEntry.State is not EntityState.Deleted)
        {
            return;
        }

        if (entityEntry.Entity is not AuditableEntity entity)
        {
            return;
        }

        entityEntry.State = EntityState.Modified;

        entity.Status = Status.Deleted;
        entity.DeletedBy = userId;
        entity.DeletedDate = DateTime.Now;
    }
}