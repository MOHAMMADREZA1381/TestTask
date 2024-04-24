using AutoMapper;
using System.Reflection;
using Test.Application.IServices;
using Test.Application.PasswordHelper;
using Test.Domain.IRepositories;
using Test.Domain.Models.User;
using Test.Domain.ViewModel;
using Test.Application.PasswordHelper;
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

    public async Task Register(UserViewModel viewModel)
    {
        viewModel.PassWord = PasswordHelper.EncodePassword.EncodePasswordSha256(viewModel.PassWord);
       await _repository.Register(_mapper.Map<User>(viewModel));
       await _repository.SaveChanges();
    }

    public async Task<User> GetUserByEmail(string Email)
    {
       return await _repository.GetUserByEmail(Email);
    }


    public async Task<State> Login(LoginViewModel viewModel)
    {
        var PasswordHashed = PasswordHelper.EncodePassword.EncodePasswordSha256(viewModel.Password);
        var user = await GetUserByEmail(viewModel.Email.ToLower().Trim());
        if (user == null) return State.NotFound;
        if (user.PassWord != PasswordHashed) return State.WrongPassword;

        return State.Successed;
    }

}