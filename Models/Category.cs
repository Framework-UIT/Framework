using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Framework.Models
{
    public partial class Category
    {
        public Category()
        {
            Card = new HashSet<Card>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // [JsonIgnore]
        public virtual ICollection<Card> Card { get; set; }
    }
}
