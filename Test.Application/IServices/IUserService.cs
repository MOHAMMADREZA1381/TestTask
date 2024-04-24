using Test.Domain.ViewModel;

namespace Test.Application.IServices;

public interface IUserService
{
    public void Register(UserViewModel viewModel);
  
}