using System.Collections.Generic;
using Framework.Models;
namespace Framework.Data
{
    public interface IFrameworkRepo
    {
        IEnumerable<Card> GetCards();
        Card GetCardById(int id);
    }
}