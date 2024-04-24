using Infra.Test.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Test.Application.IServices;
using Test.Application.Services;
using Test.Domain.IRepositories;

namespace Test.Infra.IoC;

public class DependencyContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        //    <---Application LAYER--->
        services.AddScoped<IUserService, UserService>();

        //    <---Data Layer --->
        services.AddScoped<IUserRepository, UserRepository>();

    }
}