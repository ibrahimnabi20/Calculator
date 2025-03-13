using System;

namespace Calculator.Models
{
    public class CalculationHistory
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int Result { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}