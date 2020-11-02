using System;
using System.Collections.Generic;

namespace Framework.Models
{
    public partial class UserCard
    {
        public int UserCardId { get; set; }
        public int UserId { get; set; }
        public int CardId { get; set; }

        public virtual Card Card { get; set; }
        public virtual User User { get; set; }
    }
}
