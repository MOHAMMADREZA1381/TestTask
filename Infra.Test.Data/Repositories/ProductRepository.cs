using Infra.Test.Data.Context;
using Microsoft.EntityFrameworkCore;
using Test.Domain.IRepositories;
using Test.Domain.Models.Product;

namespace Infra.Test.Data.Repositories;

public class ProductRepository:IProductRepository
{
    #region Context
    private readonly TestTaskContext _context;
    public ProductRepository(TestTaskContext context)
    {
        _context = context;
    }
    #endregion


    public async Task AddProduct(Product product)
    {
        await _context.AddAsync(product);
    }

    public async Task<ICollection<Product>> GetAllProducts()
    {
        return await _context.Products.Where(a => a.IsAvailable == true).ToListAsync();
    }


    public async Task DeleteProduct(Product product)
    {
      _context.Products.Remove(product);
    }

    public async Task EditProduct(Product product)
    {
         _context.Products.Update(product);
    }

    public async Task<Product> GetProductById(int Id)
    {
        return await _context.Products.Where(a => a.Id == Id).FirstOrDefaultAsync();
    }

    public async Task<bool> CheckProductOwner(int ProdictId, int UserId)
    {
        return await _context.Products.AnyAsync(a => a.Id == ProdictId && a.UserId == UserId);
    }

    public async Task<bool> ExistProduct(int Id)
    {
       return await _context.Products.AnyAsync(a => a.Id == Id);
    }

    public async Task SaveChange()
    {
        await _context.SaveChangesAsync();
    }
}