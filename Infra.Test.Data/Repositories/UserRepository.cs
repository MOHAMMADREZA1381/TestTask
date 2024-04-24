using Infra.Test.Data.Context;
using Test.Domain.IRepositories;
using Test.Domain.Models.User;

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

    public void Register(User user)
    {
        _taskContext.Users.Add(user);
    }

 

    public void SaveChanges()
    {
        _taskContext.SaveChanges();
    }
}