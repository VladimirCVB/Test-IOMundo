using Microsoft.AspNetCore.Mvc;
using Test_IOMundo.Interfaces;
using Test_IOMundo.Models;
using Test_IOMundo.ViewModels;

namespace Test_IOMundo.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IAccountRepository _accountRepository;

        public OfferController(IOfferRepository offerRepository, IAccountRepository accountRepository)
        {
            _offerRepository = offerRepository;
            _accountRepository = accountRepository;
        }
        public async Task<IActionResult?> SearchAvailability(RequestObject requestObject)
        {
            if (!ModelState.IsValid) return View();

            if (await _accountRepository.Login(requestObject.LoginViewModel) == false) return View();

            IEnumerable<Offer> offers = await _offerRepository.GetByRequstObject(requestObject);
            return View(offers);
        }
    }
}
