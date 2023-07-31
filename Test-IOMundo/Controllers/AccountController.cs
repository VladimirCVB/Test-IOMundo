using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Test_IOMundo.Data;
using Test_IOMundo.Interfaces;
using Test_IOMundo.Models;
using Test_IOMundo.ViewModels;

namespace Test_IOMundo.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<bool> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return false;

            return await _accountRepository.Login(loginViewModel);
        }
    }
}
