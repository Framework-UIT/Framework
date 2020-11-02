using System;
using System.Collections.Generic;

namespace Framework.Models
{
    public partial class TestType
    {
        public TestType()
        {
            Test = new HashSet<Test>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Test> Test { get; set; }
    }
}
