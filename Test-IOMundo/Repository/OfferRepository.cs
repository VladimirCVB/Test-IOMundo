using Microsoft.EntityFrameworkCore;
using Test_IOMundo.Data;
using Test_IOMundo.Interfaces;
using Test_IOMundo.Models;
using Test_IOMundo.ViewModels;

namespace Test_IOMundo.Repository
{
    public class OfferRepository : IOfferRepository
    {
        private readonly ApplicationDbContext _context;

        public OfferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Offer>> GetByRequstObject(RequestObject requestObject)
        {
            return await _context.Offers.Where(of => of.CheckInDate == requestObject.DateForm &&
            of.StayDurationNights == requestObject.Duration &&
            of.PersonCombination == requestObject.PeopleCount)
            .ToListAsync();
        }
    }
}
