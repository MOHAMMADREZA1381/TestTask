using Test.Domain.Models.Product;
using Test.Domain.ViewModel.Product;

namespace Test.Application.IServices;

public interface IProductService
{
    public Task AddProduct(ProductViewModel product);
    public Task<ICollection<ProductsViewModel>> GetAllProducts();
    public Task DeleteProduct(int id);
    public Task<bool> CehckOwner(int ProductId, int UserId);
    public Task<bool> ExistProduct(int Id);
    public Task EditProduct(EditProductViewModel product);
  
}