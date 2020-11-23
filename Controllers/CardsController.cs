using Microsoft.AspNetCore.Mvc;

using Framework.Models;
using Framework.Data;
using System.Collections.Generic;
using System;

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
        // public ActionResult<IEnumerable<Card>> GetAllCards()
        // {
        //     var cardItem = _repo.GetCards();
        //     if (cardItem != null)
        //         return Ok(cardItem);
        //     return NotFound();
        // }

        public ActionResult<IEnumerable<Card>> GetCardsByCat(int categoryId)
        {
            Console.WriteLine(categoryId);
            IEnumerable<Card> result;
            if (categoryId != 0)

                result = _repo.GetCardsByCategory(categoryId);
            else result = _repo.GetCards();
            if (result != null)
                return Ok(result);
            return NotFound(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Card> GetCardById([FromQuery] int id)
        {
            var cardItem = _repo.GetCardById(id);
            if (cardItem != null)
                return Ok(cardItem);
            return NotFound();
        }

        [HttpGet("{categoryId}")]
        public ActionResult<Card> GetCards([FromBody] int categoryId)

        {
            Console.Write(categoryId);
            if (categoryId > 0)
            {

                var cardItem = _repo.GetCardsByCategory(categoryId);
                Console.WriteLine(cardItem);
                if (cardItem != null)
                    return Ok(cardItem);
            }
            return Ok("Not found");
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