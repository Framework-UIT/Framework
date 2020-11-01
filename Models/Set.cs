using System;
using System.Collections.Generic;

namespace Framework.Models
{
    public partial class Set
    {
        public Set()
        {
            CardSet = new HashSet<CardSet>();
        }

        public int SetId { get; set; }
        public string SetName { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<CardSet> CardSet { get; set; }
    }
}
