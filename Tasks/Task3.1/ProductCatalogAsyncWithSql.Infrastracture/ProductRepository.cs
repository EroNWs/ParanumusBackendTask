﻿using Microsoft.EntityFrameworkCore;
using ProductCatalogAsyncWithSql.DAL.Contexts;
using ProductCatalogAsyncWithSql.Models;

namespace ProductCatalogAsyncWithSql.Infrastracture;

public class ProductRepository:IProductRepository
{
    private readonly ProductCatalogDbContext _context;
    public ProductRepository(ProductCatalogDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product is not null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

        }
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task UpdateAsync(Product updatedProduct)
    {
        var product = await _context.Products.FindAsync(updatedProduct.Id);
        if (product != null)
        {
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            await _context.SaveChangesAsync();
        }
    }
}
