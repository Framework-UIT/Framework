using System;
using System.Collections.Generic;

namespace Framework.Models
{
    public partial class Test
    {
        public int TestId { get; set; }
        public int TypeId { get; set; }
        public int SetId { get; set; }

        public virtual Set Set { get; set; }
        public virtual TestType Type { get; set; }
    }
}
