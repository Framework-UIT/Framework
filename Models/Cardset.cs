using System;
using System.Collections.Generic;

namespace Framework.Models
{
    public partial class CardSet
    {
        public int CardSetId { get; set; }
        public int CardId { get; set; }
        public int SetId { get; set; }

        public virtual Card Card { get; set; }
        public virtual Set Set { get; set; }
    }
}
