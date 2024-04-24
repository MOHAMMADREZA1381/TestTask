using Test.Domain.Models.Product;
using Test.Domain.ViewModel.Product;

namespace Test.Domain.IRepositories;

public interface IProductRepository
{
    public Task AddProduct(Product product);
    public Task<ICollection<Product>> GetAllProducts();
    public Task DeleteProduct(Product product);
    public Task EditProduct(Product product);
    public Task<Product> GetProductById(int Id);
    public Task<bool> CheckProductOwner(int ProdictId,int UserId);
    public Task<bool> ExistProduct(int Id);
    public Task SaveChange();
}