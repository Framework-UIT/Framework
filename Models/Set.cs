using System;
using System.Collections.Generic;

namespace Framework.Models
{
    public partial class Set
    {
        public int SetId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
