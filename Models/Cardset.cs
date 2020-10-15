using System;
using System.Collections.Generic;

#nullable disable

namespace Framework.Models
{
    public partial class Cardset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string CategoryId { get; set; }
    }
}
