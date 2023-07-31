using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_IOMundo.Controllers;
using Test_IOMundo.Interfaces;
using Test_IOMundo.Models;
using Test_IOMundo.ViewModels;
using Xunit;

namespace Test_IOMundo.tests.Controller
{
    public class OfferControllerTests
    {
        private OfferController _offerController;
        private IOfferRepository _offerRepository;
        private IHttpContextAccessor _httpContextAccessor;
        public OfferControllerTests()
        {
            _offerRepository = A.Fake<IOfferRepository>();
            _httpContextAccessor = A.Fake<HttpContextAccessor>();
            _offerController = new OfferController(_offerRepository);
        }

        [Fact]
        public void OfferController_SearchAvailability_ReturnsSuccess()
        {
            //Arrange
            var offers = A.Fake<IEnumerable<Offer>>();
            RequestObject requestObject = new RequestObject()
            {
                DateForm = DateTime.Now,
                Duration = 10,
                PeopleCount = "10",
            };
            A.CallTo(() => _offerRepository.GetByRequstObject(requestObject)).Returns(offers);
            //Act
            var result = _offerController.SearchAvailability(requestObject);
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
