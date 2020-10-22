using System.Collections.Generic;
using Framework.Models;
namespace Framework.Data
{
    public interface IFrameworkRepo
    {
        bool SaveChanges();
        IEnumerable<Card> GetCards();
        Card GetCardById(int id);
        void CreateCard(Card card);
    }
}