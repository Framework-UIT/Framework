﻿using System;
using System.Collections.Generic;

namespace Framework.Models
{
    public partial class Card
    {
        public Card()
        {
            CardSet = new HashSet<CardSet>();
        }

        public int CardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<CardSet> CardSet { get; set; }
    }
}
