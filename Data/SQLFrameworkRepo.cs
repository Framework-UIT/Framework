using System.Collections.Generic;
using Framework.Models;
using System.Linq;
using System;

namespace Framework.Data
{
    public class SQLFrameworkRepo : ICardRepo
    {
        private readonly prod_frameworkContext _context;

        public SQLFrameworkRepo(prod_frameworkContext newContext)
        {
            _context = newContext;
        }
        public IEnumerable<Card> GetCards()
        {
            return _context.Card.ToList();
        }

        public void CreateCard(Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }
            _context.Card.Add(card);
        }
        public Card GetCardById(int id)
        {
            return _context.Card.FirstOrDefault(c => c.CardId == c.CardId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}