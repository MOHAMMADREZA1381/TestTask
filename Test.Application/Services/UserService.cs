using AutoMapper;
using Test.Application.IServices;
using Test.Application.PasswordHelper;
using Test.Domain.IRepositories;
using Test.Domain.Models.User;
using Test.Domain.ViewModel;

namespace Test.Application.Services;

public class UserService : IUserService
{
    #region Repositories

    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    #endregion

    public void Register(UserViewModel viewModel)
    {
        
        _repository.Register(_mapper.Map<User>(viewModel));
        _repository.SaveChanges();

    }

}