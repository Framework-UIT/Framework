using System;
using System.Collections.Generic;

namespace Framework.Models
{
    public partial class User
    {
        public User()
        {
            Card = new HashSet<Card>();
            UserCard = new HashSet<UserCard>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Card> Card { get; set; }
        public virtual ICollection<UserCard> UserCard { get; set; }
    }
}
