using System.Collections.Generic;
using Framework.Models;
namespace Framework.Data
{
    interface IFrameworkRepo
    {
        IEnumerable<Card> GetCards();
        Card GetCardById(int id);
    }
}