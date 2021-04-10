using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemGenerator
{
    public class CustomProperty
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string Value { get; set; }
        public CustomProperty(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
        public override string ToString()
        {
            return "Generated Value: " + Value + ", Min: " + MinValue + ", Max: " + MaxValue;
        }
    }
}
