using Microsoft.AspNetCore.Mvc;

using Framework.Models;
using Framework.Data;
using System.Collections.Generic;

namespace Framework.Controllers
{
    //api/cards
    // [Route("api/[controller]")]
    [Route("/api/cards")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly MockFrameworkRepo _repo = new MockFrameworkRepo();
        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetAllCards()
        {
            var cardItems = _repo.GetCards();
            return Ok(cardItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Card> GetCardById(int id)
        {
            var cardItem = _repo.GetCardById(id);
            return Ok(cardItem);
        }
    }
}