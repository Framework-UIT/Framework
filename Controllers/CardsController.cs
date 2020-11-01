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
        private readonly ICardRepo _repo;
        public CardsController(ICardRepo repo)
        {
            _repo = repo;
        }
        // private readonly MockFrameworkRepo _repo = new MockFrameworkRepo();
        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetAllCards()
        {
            var cardItems = _repo.GetCards();
            if (cardItems != null)
                return Ok(cardItems);
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<Card> GetCardById(int id)
        {
            var cardItem = _repo.GetCardById(id);
            if (cardItem != null)
                return Ok(cardItem);
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Card> CreateCard(Card card)
        {
            _repo.CreateCard(card);
            _repo.SaveChanges();
            return Ok(card);
        }
    }
}