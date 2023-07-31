using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Test_IOMundo.Data;
using Test_IOMundo.Models;
using Test_IOMundo.Repository;
using Test_IOMundo.ViewModels;
using Xunit;

namespace Test_IOMundo.tests.Repository
{
    public class OfferRepositoryTets
    {
        private async Task<ApplicationDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Offers.CountAsync() < 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Offers.Add(
                      new Offer()
                      {
                          CheckInDate = DateTime.Now,
                          StayDurationNights = 10,
                          PersonCombination = "10",
                          ServiceCode = "123AB",
                          Price = 50,
                          PricePerAdult = 10,
                          PricePerChild = 5,
                          StrikePrice = 10,
                          StrikePricePerAdult = 10,
                          StrikePricePerChild = 5,
                          ShowStrikePrice = true,
                          LastUpdated = DateTime.Now,                          
                      });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async void OfferRepository_GetByRequstObject_ReturnsOffer()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var offerRepository = new OfferRepository(dbContext);

            RequestObject requestObject = new RequestObject()
            {
                DateForm = DateTime.Now,
                Duration = 10,
                PeopleCount = "10",
            };

            //Act
            var result = offerRepository.GetByRequstObject(requestObject);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<IEnumerable<Offer>>>();
        }
    }
}
