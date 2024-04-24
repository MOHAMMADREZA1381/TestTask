using AutoMapper;
using Test.Domain.Models.User;
using Test.Domain.ViewModel.User;

namespace Test.Application.Profiles;

public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<User,UserViewModel>().ReverseMap();
        CreateMap<User, UserInfoViewModel>();

    }
}