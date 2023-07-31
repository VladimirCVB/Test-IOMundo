using Microsoft.AspNetCore.Identity;
using Test_IOMundo.Data;
using Test_IOMundo.Interfaces;
using Test_IOMundo.Models;
using Test_IOMundo.ViewModels;

namespace Test_IOMundo.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;
        public AccountRepository(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> Login(LoginViewModel loginViewModel)
        {
            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
    }
}
