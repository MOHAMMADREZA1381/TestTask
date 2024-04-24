using Test.Domain.Models.User;
using Test.Domain.ViewModel;

namespace Test.Domain.IRepositories;

public interface IUserRepository
{
    public Task Register(User user);
    public Task<User> GetUserByEmail(string? Email);
    public Task<User> GetUserById(int Id);
    public Task<bool> AlreadyRegister(string Email);
    public Task SaveChanges();
}