using Microsoft.AspNetCore.Mvc;
using Test_IOMundo.Interfaces;
using Test_IOMundo.Models;
using Test_IOMundo.ViewModels;

namespace Test_IOMundo.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferRepository _offerRepository;
        private readonly AccountController _accountController;

        public OfferController(IOfferRepository offerRepository, AccountController accountController)
        {
            _offerRepository = offerRepository;
            _accountController = accountController;
        }
        public async Task<IActionResult?> SearchAvailability(RequestObject requestObject)
        {
            if (await _accountController.Login(requestObject.LoginViewModel) == false) return null;
            IEnumerable<Offer> offers = await _offerRepository.GetByRequstObject(requestObject);
            return View(offers);
        }
    }
}
