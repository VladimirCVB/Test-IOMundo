using System;
using Test_IOMundo.Models;

namespace Test_IOMundo.Data
{
    public class Seed
    {
        private static List<Offer> GeneratePersonCombination()
        {
            Random rand = new();
            List<Offer> offers = new();

            for (int childernCound = 0; childernCound <= 4; childernCound++) 
            {
                for(int adultCount = 1; adultCount <= 4; adultCount++)
                {
                    int daysCount = rand.Next(1, 10);

                    Price price = CalculatePrice(adultCount, childernCound, daysCount, false);

                    var strike = rand.Next(2) == 1;
                    Price strikePrice = new(50, 25);
                    if (strike) strikePrice = CalculatePrice(adultCount, childernCound, daysCount, true);

                    Offer offer = new()
                    {
                        Id = $"{rand.Next()}-{rand.Next(1, 102)}",
                        CheckInDate = DateTime.Now,
                        StayDurationNights = daysCount,
                        PersonCombination = $"{adultCount}A{childernCound}C",
                        ServiceCode = rand.Next().ToString(),
                        Price = price.TotalPrice,
                        PricePerAdult = price.PricePerAdult,
                        PricePerChild = price.PricePerChild,
                        StrikePrice = strikePrice.TotalPrice,
                        StrikePricePerAdult = strikePrice.PricePerAdult,
                        StrikePricePerChild = strikePrice.PricePerChild,
                        ShowStrikePrice = true,
                        LastUpdated = DateTime.Now,
                    };

                    offers.Add(offer);
                }
            }

            return offers;
        }

        private static Price CalculatePrice(int adultCount, int childrenCount, int daysCount, bool strike)
        {
            Price price = new();
            if (strike) price = new Price(50, 25);

            price.PricePerAdult = price.OneDayPricePerAdult * daysCount * adultCount;

            if (childrenCount != 0)
            {
                price.PricePerChild = price.OneDayPricePerChild * daysCount * childrenCount;
            }

            price.TotalPrice = price.calculateTotalPrice();
            return price;
        }
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();
                
                for(int i = 0; i <= 50; i++)
                {
                    List<Offer> offersPerService = GeneratePersonCombination();

                    context.Offers.AddRange(offersPerService);
                    context.SaveChanges();
                }
            }
        }       
    }
}
