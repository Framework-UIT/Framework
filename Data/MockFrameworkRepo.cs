using System.Collections.Generic;
using Framework.Models;

namespace Framework.Data
{
    public class MockFrameworkRepo : IFrameworkRepo
    {
        public IEnumerable<Card> GetCards()
        {
            var cards = new List<Card>
            {
                new Card("Hello","Greetings","Greetings English","urlimgblabla"),
                new Card("Hello","Greetings","Greetings English","urlimgblabla"),
                new Card("Hello","Greetings","Greetings English","urlimgblabla"),
                new Card("Hello","Greetings","Greetings English","urlimgblabla"),
            };
            return cards;
        }

        public Card GetCardById(int id)
        {
            return new Card("Hello", "Greetings", "Greetings English", "urlimgblabla");
        }
    }
}