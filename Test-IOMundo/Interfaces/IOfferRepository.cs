using Test_IOMundo.Models;
using Test_IOMundo.ViewModels;

namespace Test_IOMundo.Interfaces
{
    public interface IOfferRepository
    {
        Task<IEnumerable<Offer>> GetByRequstObject(RequestObject requestObject);
    }
}
