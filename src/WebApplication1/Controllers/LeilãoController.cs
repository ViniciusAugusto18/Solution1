using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.UseCases.leiloes.GetCurrent;

namespace WebApplication1.Controllers
{
    
    public class LeilãoController : LeilaoBaseController
    {
        [HttpGet] // tem q colocar assim pra ser uma end point
        [ProducesResponseType(typeof(Auction),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]// 
        public IActionResult GetActionResult([FromServices] GetCurrentLeilao useCase)
        {
            
            var retorno =  useCase.Execute();

            if (retorno is null)

                return NoContent();
            return Ok(retorno);
        }

       
    }
}
