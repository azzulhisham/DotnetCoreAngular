using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.ViewModels;

namespace api.Services {
    public interface IOfferService {
        Task<IEnumerable<OfferViewModel>> GetOffers();

        Task<OfferViewModel> GetOffersById(Guid guid);

        Task<OfferViewModel> AddOffer(OfferViewModel offerViewModel);

        Task<OfferViewModel> EditOffer(OfferViewModel offerViewModel);

        Task<OfferViewModel> RemoveOffer(OfferViewModel offerViewModel);
        Task<OfferViewModel> RemoveOfferById(Guid guid);
    }
}