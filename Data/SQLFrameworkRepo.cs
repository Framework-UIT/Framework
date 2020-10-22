using System.Collections.Generic;
using Framework.Models;
using System.Linq;
using System;

namespace Framework.Data
{
    public class SQLFrameworkRepo : IFrameworkRepo
    {
        private readonly FrameworkContext _context;

        public SQLFrameworkRepo(FrameworkContext newContext)
        {
            _context = newContext;
        }
        public IEnumerable<Card> GetCards()
        {
            return _context.Cards.ToList();
        }

        public void CreateCard(Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }
            _context.Cards.Add(card);
        }
        public Card GetCardById(int id)
        {
            return _context.Cards.FirstOrDefault(c => c.Id == c.Id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);

        }

    }
}