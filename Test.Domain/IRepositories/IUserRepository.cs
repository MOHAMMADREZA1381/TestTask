using Test.Domain.Models.User;

namespace Test.Domain.IRepositories;

public interface IUserRepository
{
    public void Register(User user);
   
    public void SaveChanges();
}