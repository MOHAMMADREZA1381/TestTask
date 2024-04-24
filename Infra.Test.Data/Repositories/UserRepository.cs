using Infra.Test.Data.Context;
using Microsoft.EntityFrameworkCore;
using Test.Domain.IRepositories;
using Test.Domain.Models.User;
using Test.Domain.ViewModel;

namespace Infra.Test.Data.Repositories;

public class UserRepository:IUserRepository
{
    #region Context
    private readonly TestTaskContext _taskContext;
    public UserRepository(TestTaskContext taskContext)
    {
        _taskContext = taskContext;
    }
    #endregion

    public async Task Register(User user)
    {
       await _taskContext.Users.AddAsync(user);
    }

    public async Task<User> GetUserByEmail(string? Email)
    {
       return await _taskContext.Users.Where(a => a.Email == Email).FirstOrDefaultAsync();
    }

    public async Task<User> GetUserById(int Id)
    {
        return await _taskContext.Users.Where(a => a.Id == Id).FirstOrDefaultAsync();
    }

    public async Task<bool> AlreadyRegister(string Email)
    {
        return _taskContext.Users.Any(a => a.Email == Email);
    }


    public async Task SaveChanges()
    {
       await _taskContext.SaveChangesAsync();
    }
}