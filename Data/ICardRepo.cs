using System.Collections.Generic;
using System.Linq;
using Framework.Models;
namespace Framework.Data
{
    public interface ICardRepo
    {
        bool SaveChanges();
        // IEnumerable<Card> GetCards();
        // IQueryable<Card> GetCards();
        IEnumerable<Card> GetCards();
        IEnumerable<Card> GetCardsByCategory(int id);
        Card GetCardById(int id);
        void CreateCard(Card card);
    }
}