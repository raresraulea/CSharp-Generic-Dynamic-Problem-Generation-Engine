using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemGenerator
{
    class CustomPropertyRangeAsList
    {
        public List<string> Values { get; set; } = new List<string>() { "f", "g", "h" };
        public string ChosenValue { get; set; }
        public CustomPropertyRangeAsList()
        {
        }

    }
}

