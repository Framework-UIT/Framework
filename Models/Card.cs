using System;
using System.Collections.Generic;

namespace Framework.Models
{
    public partial class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int? CategoryId { get; set; }
        public string Pronun { get; set; }
    }
}
