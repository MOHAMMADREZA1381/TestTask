using AutoMapper;
using Test.Domain.Models.Product;
using Test.Domain.ViewModel.Product;

namespace Test.Application.Profiles;

public class ProductProfile:Profile
{
    public ProductProfile()
    {
        CreateMap<EditProductViewModel, Product>();
        CreateMap<ProductViewModel, Product>();
        //CreateMap<ICollection<Product>,ICollection<ProductsViewModel>>().ReverseMap();
    }
}