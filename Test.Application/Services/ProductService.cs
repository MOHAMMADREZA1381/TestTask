using AutoMapper;
using Test.Application.IServices;
using Test.Domain.IRepositories;
using Test.Domain.Models.Product;
using Test.Domain.ViewModel.Product;

namespace Test.Application.Services;

public class ProductService : IProductService
{
    #region Repositories
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;
    public ProductService(IMapper mapper, IProductRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    #endregion

    public async Task AddProduct(ProductViewModel product)
    {
        var Product = _mapper.Map<Product>(product);
        await _repository.AddProduct(Product);
        await _repository.SaveChange();
    }

    public async Task<ICollection<ProductsViewModel>> GetAllProducts()
    {
      var product= await _repository.GetAllProducts();
      var ProductViewModel = new List<ProductsViewModel>();
      foreach (var item in product)
      {
          var ViewModel = new ProductsViewModel()
          {
              ManufactureEmail = item.ManufactureEmail,
              Name = item.Name,
              CreateDate =item.CreateDate,
              IsAvailable = item.IsAvailable,
          };
          ProductViewModel.Add(ViewModel);
      }
      return ProductViewModel;
    }

    public async Task DeleteProduct(int id)
    {
        var product = await _repository.GetProductById(id);
        await _repository.DeleteProduct(product);
        await _repository.SaveChange();
    }

    public async Task<bool> CehckOwner(int ProductId, int UserId)
    {
       return await _repository.CheckProductOwner(ProductId, UserId);
    }

    public async Task<bool> ExistProduct(int Id)
    {
       return await _repository.ExistProduct(Id);
    }

    public async Task EditProduct(EditProductViewModel product)
    {
        var productEntity = await _repository.GetProductById(product.Id);
        var EditedProduct = _mapper.Map(product, productEntity);
        await _repository.EditProduct(EditedProduct);
        await _repository.SaveChange();
    }


}