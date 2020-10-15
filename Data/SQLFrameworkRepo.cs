using System.Collections.Generic;
using Framework.Models;
using System.Linq;
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

        public Card GetCardById(int id)
        {
            return _context.Cards.FirstOrDefault(c => c.Id == c.Id);
        }


    }
}