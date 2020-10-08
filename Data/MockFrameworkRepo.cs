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
                new Card(1,"Hello","Greetings","Greetings English","urlimgblabla"),
                new Card(2,"Hello","Greetings","Greetings English","urlimgblabla"),
                new Card(3,"Hello","Greetings","Greetings English","urlimgblabla"),
                new Card(4,"Hello","Greetings","Greetings English","urlimgblabla"),
            };
            return cards;
        }

        public Card GetCardById(int id)
        {
            return new Card(5,"Hello", "Greetings", "Greetings English", "urlimgblabla");
        }
    }
}