using Test.Domain.Models.User;
using Test.Domain.ViewModel.User;

namespace Test.Application.IServices;

public interface IUserService
{
    public Task Register(UserViewModel viewModel);
    public Task<User> GetUserByEmail(string? Email);
    public Task<UserInfoViewModel> GetUserById(int Id);

    public Task<State> Login(LoginViewModel user);

}