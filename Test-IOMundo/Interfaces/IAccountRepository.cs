using Test_IOMundo.ViewModels;

namespace Test_IOMundo.Interfaces
{
    public interface IAccountRepository
    {
        Task<bool> Login(LoginViewModel loginViewModel);
    }
}
