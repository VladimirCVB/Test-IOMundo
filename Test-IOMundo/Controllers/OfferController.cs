using Microsoft.AspNetCore.Mvc;
using Test_IOMundo.Interfaces;
using Test_IOMundo.Models;
using Test_IOMundo.ViewModels;

namespace Test_IOMundo.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferRepository _offerRepository;

        public OfferController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public async Task<IActionResult> SearchAvailability(RequestObject requestObject)
        {
            IEnumerable<Offer> offers = await _offerRepository.GetByRequstObject(requestObject);
            return View(offers);
        }
    }
}
