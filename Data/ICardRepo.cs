using System.Collections.Generic;
using Framework.Models;
namespace Framework.Data
{
    public interface ICardRepo
    {
        bool SaveChanges();
        IEnumerable<Card> GetCards();
        Card GetCardById(int id);
        void CreateCard(Card card);
    }
}