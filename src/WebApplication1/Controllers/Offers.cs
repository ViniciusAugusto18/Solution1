using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.communication.Request;
using WebApplication1.Entities;
using WebApplication1.filtters;
using WebApplication1.UseCases.offers.create_offer;

namespace WebApplication1.Controllers
{
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public class Offers : LeilaoBaseController
    {
        [HttpPost]
        [Route("{ItemId}")]
        
        public IActionResult CreateOffer([FromRoute] int ItemId,
            [FromBody] RequestCreatedOfferJson request, [FromServices] CreateOfferUseCase useCase)
        {
             var id = useCase.Execute(ItemId, request);

            return Created(string.Empty, id );
        }

        
    }
}
