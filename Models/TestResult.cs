using System;
using System.Collections.Generic;

namespace Framework.Models
{
    public partial class TestResult
    {
        public int TestResultId { get; set; }
        public int TestId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public DateTime TakenAt { get; set; }
    }
}
