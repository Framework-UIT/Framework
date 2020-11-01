using System;
using System.Collections.Generic;

namespace Framework.Models
{
    public partial class Favorite
    {
        public int FavoriteId { get; set; }
        public int UserId { get; set; }
        public int SetId { get; set; }
    }
}
