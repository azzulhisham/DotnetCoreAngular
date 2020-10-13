using System.Collections.Generic;
using System.Threading.Tasks;
using api.Context;
using api.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using AutoMapper;
using api.Models;

namespace api.Services {
    public class OfferService : IOfferService
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public OfferService(MyContext myContext,
                            IMapper mapper) {
            _context = myContext;
            _mapper = mapper;
        }

        public async Task<OfferViewModel> AddOffer(OfferViewModel offerViewModel)
        {
            var entity = _context.Set<Offer>().Add(_mapper.Map<Offer>(offerViewModel));
            await _context.SaveChangesAsync();

            return _mapper.Map<OfferViewModel>(entity.Entity);
        }

        public async Task<OfferViewModel> EditOffer(OfferViewModel offerViewModel)
        {
            var entity = _context.Set<Offer>().Update(_mapper.Map<Offer>(offerViewModel));
            entity.State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return _mapper.Map<OfferViewModel>(entity.Entity);
        }

        public async Task<IEnumerable<OfferViewModel>> GetOffers()
        {
            var offers = await _context.Offers.ToListAsync();
            var offersDto = _mapper.Map<IEnumerable<OfferViewModel>>(offers);

            return offersDto;
        }

        public async Task<OfferViewModel> GetOffersById(Guid id)
        {
            var offer = await _context.Set<Offer>().FindAsync(id);
            var offerDto = _mapper.Map<OfferViewModel>(offer);
            return offerDto;
        }

        public async Task<OfferViewModel> RemoveOffer(OfferViewModel offerViewModel)
        {
            var entity = _context.Set<Offer>().Remove(_mapper.Map<Offer>(offerViewModel));
            entity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return _mapper.Map<OfferViewModel>(entity.Entity);
        }

        public async Task<OfferViewModel> RemoveOfferById(Guid id)
        {
            var entity = _context.Set<Offer>().Remove(new Offer() {
                Id = id
            });
            entity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return _mapper.Map<OfferViewModel>(entity.Entity);
        }        
    }
}