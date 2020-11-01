using System.Collections.Generic;
using Framework.Models;

namespace Framework.Data
{
    public interface ICarsetRepo
    {
        bool SaveChanges();
        IEnumerable<CardSet> GetCardSets();
        CardSet GetCardSetById(int id);
        void CreateCardSet(CardSet card);
    }
}