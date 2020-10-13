using System;
using System.Threading.Tasks;
using api.Services;
using api.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api {

    [EnableCors("localhostpolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OffersController(IOfferService offerService) {
            _offerService = offerService;
        }

        
        [HttpGet]
        public async Task<ActionResult> GetOffers() {
            var dto = await _offerService.GetOffers();
            return new OkObjectResult(dto);
        }

        [Route("{id:Guid}")]
        [HttpGet]
        public async Task<ActionResult> GetOfferById(Guid id)
        {
            var dto = await _offerService.GetOffersById(id);
            return new OkObjectResult(dto);
        }

        [HttpPut]
        public async Task<ActionResult> EditOffer([FromBody] OfferViewModel offer)
        {
            var dto = await _offerService.EditOffer(offer);
            return new OkObjectResult(dto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOffer([FromBody] OfferViewModel offer)
        {
            var dto = await _offerService.AddOffer(offer);
            return new OkObjectResult(dto);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveOffer([FromBody] OfferViewModel offer)
        {
            var dto = await _offerService.RemoveOffer(offer);
            return new OkObjectResult(dto);
        }

        [Route("{id:Guid}")]
         [HttpDelete]
        public async Task<ActionResult> RemoveOfferById(Guid id)
        {
            var dto = await _offerService.RemoveOfferById(id);
            return new OkObjectResult(dto);
        }    
    }
}